using AutoMapper;
using knowledge_hub.WebAPI.Database;
using knowledge_hub.WebAPI.Intefraces;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using Microsoft.EntityFrameworkCore;
using knowledge_hub.WebAPI.Helpers;
using System.Net;

namespace knowledge_hub.WebAPI.Services
{
   public class UserService : CRUDService<UserResponse, UserSearchRequest, UserInsertRequest, UserInsertRequest, User>, IUserService
   {
      private readonly databaseContext _dbContext;
      private readonly IMapper _mapper;
      public UserService(databaseContext context, IMapper mapper): base(context, mapper) {
         _dbContext = context;
         _mapper = mapper;
      }

      public override Task<UserResponse> Insert(UserInsertRequest request) {
         return base.Insert(request);
      }
      public override Task<UserResponse> Update(int ID, UserInsertRequest request) {
         return base.Update(ID, request);
      }
      public async Task<UserDataResponse> Login(AuthenticationRequest request) {
         var login = await _dbContext.Logins
            .Include(x => x.User)
            .ThenInclude(u => u.UserRole)
            .ThenInclude(r => r.Role)
            .FirstOrDefaultAsync(x => x.Email == request.Email);

         if(login != null)
         {
            var checkHash = PasswordHelper.GeneratePasswordHash(login.PasswordSalt, request.Password);
            if(checkHash == login.PasswordHash)
            {
               var addressData = await _dbContext.Addresses.Where(x => x.UserId == login.UserId).FirstOrDefaultAsync();
               var paymentData = await _dbContext.Cards.Where(x => x.UserId == login.UserId).FirstOrDefaultAsync();
               var wishlist = await _dbContext.Whishlist
                  .Where(x => x.UserId == login.UserId)
                  .Include(x => x.Book)
                  .ThenInclude(x => x.category)
                  .Include(x => x.Book)
                  .ThenInclude(x => x.language)
                  .ToListAsync();
               var cart = await _dbContext.Orders.Where(x => x.UserId == login.UserId).Include(x => x.City).ToListAsync();

               var userData = new UserDataResponse();
               userData.authData = new LoginData();
               userData.authData.email = request.Email;
               userData.authData.password = request.Password;

               userData.userData = _mapper.Map<UserResponse>(login.User);
               userData.addressData = _mapper.Map<AddressResponse>(addressData);
               userData.paymentData = _mapper.Map<PaymentInfoResponse>(paymentData);
               userData.wishlist = new List<BookResponse>();
               foreach (var item in wishlist)
               {
                  userData.wishlist.Add(_mapper.Map<BookResponse>(item.Book));
               }
               userData.cart = _mapper.Map<List<OrderResponse>>(cart);

               return userData;
            }
         }

         return new UserDataResponse();
      }
      public async Task<RegisterResponse> Register(LoginRegisterRequest request) {
         if (request.Password != request.ConfirmPassword)
            return new RegisterResponse() { Message = "Passwords do not match!"};

         var emailExists = _dbContext.Logins.Select(l => l.Email).Contains(request.Email);
         if (emailExists)
            return new RegisterResponse() { Message = "Email already exists!" };

         var dbLoginEntity = _mapper.Map<Login>(request);
         dbLoginEntity.PasswordSalt = PasswordHelper.GeneratePasswordSalt();
         dbLoginEntity.PasswordHash = PasswordHelper.GeneratePasswordHash(dbLoginEntity.PasswordSalt, request.Password);

         await _dbContext.Logins.AddAsync(dbLoginEntity);
         await _dbContext.SaveChangesAsync();

         return new RegisterResponse() { LoginId = dbLoginEntity.LoginId };
      }
      public async Task<UserResponse> RegisterUser(UserRegisterRequest request) {
         var userEntity = _mapper.Map<User>(request);
         userEntity.ImagePath = "";
         await _dbContext.Users.AddAsync(userEntity);
         await _dbContext.SaveChangesAsync();

         var userRole = new UserRoles()
         {
            UserID = userEntity.UserId,
            RoleID = 2,
         };
         await _dbContext.UserRoles.AddAsync(userRole);

         var login = await _dbContext.Logins.SingleOrDefaultAsync(l => l.LoginId == request.LoginId);
         if (login != null) {
            login.UserId = userEntity.UserId;
         }
         await _dbContext.SaveChangesAsync();

         var userResponse = _mapper.Map<UserResponse>(userEntity);
         userResponse.UserRole = (await _dbContext.Roles.FindAsync(userRole.RoleID)).Name;

         return userResponse;
      }
      public async Task<HttpStatusCode> UpdatePassword(PasswordUpdateRequest request) {
         if(request.NewPassword != request.ConfirmPassword) return HttpStatusCode.BadRequest;

         var user = await _dbContext.Users.FindAsync(request.UserId);
         if (user == null) return HttpStatusCode.NotFound;

         var login = await _dbContext.Logins.FindAsync(user.LoginId);
         if (login == null) return HttpStatusCode.NotFound;

         var salt = PasswordHelper.GeneratePasswordSalt();
         login.PasswordSalt = salt;
         login.PasswordHash = PasswordHelper.GeneratePasswordHash(salt, request.NewPassword);
         _dbContext.Update(login);
         await _dbContext.SaveChangesAsync();

         return HttpStatusCode.OK;
      }
      public async Task<PaymentInfoResponse> UpdatePayment(UserPaymentInfoRequest request) {
         var card = await _dbContext.Cards
            .Where(c => c.UserId == request.UserId).FirstOrDefaultAsync();

         if (card == null)
         {
            card = _mapper.Map<CardInfo>(request);
           await _dbContext.Cards.AddAsync(card);
         }
         else
         {
            card = _mapper.Map<CardInfo>(request);
         }

         await _dbContext.SaveChangesAsync();
         return _mapper.Map<PaymentInfoResponse>(card);
      }
      public async Task<AddressResponse> UpdateAddress(UserAddressUpdateRequest request) {
         var address = await _dbContext.Addresses.Where(a => a.UserId == request.UserId).FirstOrDefaultAsync();
         if (address == null) {
            address = _mapper.Map<Address>(request);
            address.CityId = (await _dbContext.Cities.Where(x => x.Name == request.City).FirstOrDefaultAsync()).CityId;
            await _dbContext.Addresses.AddAsync(address);
         }
         else
         {
            address = _mapper.Map<Address>(request);
         }
         await _dbContext.SaveChangesAsync();

         return _mapper.Map<AddressResponse>(address);
      }
   }
}
