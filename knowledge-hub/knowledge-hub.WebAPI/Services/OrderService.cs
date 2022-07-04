using AutoMapper;
using knowledge_hub.WebAPI.Database;
using knowledge_hub.WebAPI.Intefraces;
using knowledge_hub.WebAPI.Model;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using Microsoft.EntityFrameworkCore;
using Stripe;
using static knowledge_hub.WebAPI.Model.Enums;

namespace knowledge_hub.WebAPI.Services
{
   public class OrderService:CRUDService<OrderResponse, OrderInsertRequest, OrderUpdateRequest, Database.Order>, IOrderService
   {
      private readonly databaseContext _dbContext;
      private readonly IMapper _mapper;
      public OrderService(databaseContext dbContext, IMapper mapper) : base(dbContext, mapper) {
         _dbContext = dbContext;
         _mapper = mapper;
      }

      public override async Task<OrderResponse> GetById(int ID, string serverPath) {
         var order = await _dbContext.Orders
            .Include(x => x.Book)
            .Include(x => x.City)
            .FirstOrDefaultAsync();

         if (order == null) return null;

         var orderResponse = _mapper.Map<OrderResponse>(order);
         orderResponse.City = order.City.Name;

         return orderResponse;
      }

      public override async Task<OrderResponse> Insert(OrderInsertRequest request) {
         var newOrder = _mapper.Map<Database.Order>(request);
         newOrder.ShippingDate = DateTime.UtcNow;
         newOrder.OrderStatus = (int)Enums.OrderStatus.Placed;
         newOrder.BookId = request.Books[0];
         newOrder.Digital = request.Digital[0];

         await _dbContext.Orders.AddAsync(newOrder);
         await _dbContext.SaveChangesAsync();

         return _mapper.Map<OrderResponse>(newOrder);

      }

      public async Task<List<OrderResponse>> InsertMany(OrderInsertRequest request) {
         var paymentIntentService = new PaymentIntentService();
         var payentIntent = await paymentIntentService.GetAsync(request.PaymentIntent);

         var paymentMethodService = new PaymentMethodService();
         var paymentMethod = await paymentMethodService.GetAsync(payentIntent.PaymentMethodId);
         PaymentMethodCard card = paymentMethod.Card;

         var ordersToInsert = new List<Database.Order>();
         var transactionsToInsert = new List<Transaction>();
         var responseMap = new List<OrderResponse>();
         string orderNumber = Guid.NewGuid().ToString();

         for (int i = 0; i < request.Books.Count; i++)
         {
            var newOrder = _mapper.Map<Database.Order>(request);
            newOrder.ShippingDate = DateTime.UtcNow;
            newOrder.OrderStatus = (int)Enums.OrderStatus.Placed;
            newOrder.BookId = request.Books[i];
            newOrder.Digital = request.Digital[i];
            newOrder.OrderNumber = orderNumber;
            newOrder.Comment = "";
            if (request.Digital[i])
            {
               newOrder.OrderStatus = (int)OrderStatus.Completed;
            }
            ordersToInsert.Add(newOrder);
            _dbContext.Add(newOrder);
            await _dbContext.SaveChangesAsync();

            var book = _dbContext.Books.Find(request.Books[i]);
            var existingCard = await _dbContext.Cards
               .Where(x => x.UserId == request.UserId && x.CardNumber == card.Last4)
               .FirstAsync();
            if(existingCard == null)
            {
               existingCard = new CardInfo()
               {
                  UserId = request.UserId,
                  CardDate = card.ExpMonth.ToString() + "/" + card.ExpYear.ToString(),
                  CardNumber = card.Last4,
                  FullName = request.UserFullName,
               };
               await _dbContext.Cards.AddAsync(existingCard);
               await _dbContext.SaveChangesAsync();
            }

            Transaction t = new Transaction()
            {
               OrderId = newOrder.OrderId,
               TransactionTime = DateTime.UtcNow,
               Price = book == null? 0 : 
                  (newOrder.Digital? book.PriceDigital : book.PricePhysical),
               CardInfoId = existingCard.CardInfoId
            };
            await _dbContext.Transactions.AddAsync(t);
            await _dbContext.SaveChangesAsync();
         }

         await _dbContext.SaveChangesAsync();

         foreach (var order in ordersToInsert)
         {
            responseMap.Add(_mapper.Map<OrderResponse>(order));
         }

         return responseMap;
      }

      public async Task<string> InitiatePayment(OrderInsertRequest request) {
         Customer customer;

         //Fetch user login info
         var user = await _dbContext.Users.FindAsync(request.UserId);
         if (user == null) return "";
         var login = await _dbContext.Logins.FindAsync(user.LoginId);
         if (login == null) return "";

         long paymentAmount = 0;
         var books = _dbContext.Books.Where(x => request.Books.Contains(x.BookId));
         foreach (var book in books)
         {
            var bookIndex = request.Books.IndexOf(book.BookId);
            paymentAmount += (long)((request.Digital[bookIndex] ? book.PriceDigital : book.PricePhysical) * 100.00f);
         }

         //Fetch Stripe customer or create new one
         var customerService = new CustomerService();
         var customers = await customerService.ListAsync(new CustomerListOptions { Email = login.Email });
         if (customers == null || customers.Count() == 0) {
            customer = await customerService.CreateAsync(new CustomerCreateOptions {
               Email = login.Email,

            });
         }
         else
         {
            customer = customers.First();
         }

         //Create Ephermal key for customer
         var ephermalKeyService = new EphemeralKeyService();
         var ephermalKey = await ephermalKeyService.CreateAsync(new EphemeralKeyCreateOptions
         {
            Customer = customer.Id
         });

         //Create payment intent
         var paymentIntentService = new PaymentIntentService();
         var paymentIntent = await paymentIntentService.CreateAsync(new PaymentIntentCreateOptions { 
            Customer = customer.Id,
            Amount = paymentAmount,
            Currency = "usd",
            PaymentMethodTypes = new List<string>() { "card" }
         });

         return Newtonsoft.Json.JsonConvert.SerializeObject(new {
            paymentIntent = paymentIntent.Id,
            clientSecret = paymentIntent.ClientSecret,
            ephermalKey = ephermalKey.Secret,
            customer = customer.Id
         });
      }

      public async Task<List<OrderResponse>> GetByUser(int UserId) {
         List<Database.Order> databaseEntities = new List<Database.Order>();

         if (UserId != 0) {
            databaseEntities = await _dbContext.Orders
            .Where(x => x.UserId == UserId)
            .Include(x => x.Book)
            .ToListAsync();
         }
         else
         {
            databaseEntities = await _dbContext.Orders
            .Where(x => x.UserId == UserId)
            .Include(x => x.Book)
            .ToListAsync();
         }
         
         return _mapper.Map<List<OrderResponse>>(databaseEntities);
      }

      public override async Task<OrderResponse> Update(int ID, OrderUpdateRequest request) {
         var order = await _dbContext.Orders.FindAsync(ID);
         if (order == null) return null;

         order.Comment = request.Comment;
         order.OrderStatus = request.OrderStatus;
         if (order.OrderStatus == 1) order.ShippingDate = DateTime.UtcNow;

         await _dbContext.SaveChangesAsync();

         return _mapper.Map<OrderResponse>(order);
      }
      
      public async Task<List<BookResponse>> GetBoughtBooksByUser(int ID) {
         var orders = await _dbContext.Orders
            .Where(x => x.UserId == ID)
            .Include(x => x.Book)
            .ThenInclude(x => x.language)
            .Include(x => x.Book)
            .ThenInclude(x => x.category)
            .GroupBy(x => x.BookId)
            .Select(x => x.FirstOrDefault())
            .ToListAsync();

         return _mapper.Map<List<BookResponse>>(orders.Select(x => x.Book).ToList());
      }
   }
}
