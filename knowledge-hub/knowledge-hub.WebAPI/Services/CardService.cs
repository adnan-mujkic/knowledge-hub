using AutoMapper;
using knowledge_hub.WebAPI.Database;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;

namespace knowledge_hub.WebAPI.Services
{
   public class CardService: CRUDService<PaymentInfoResponse, UserPaymentInfoRequest, AddPaymentInfo, AddPaymentInfo, CardInfo>
   {
      private readonly databaseContext _dbContext;
      private readonly IMapper _mapper;
      public CardService(databaseContext dbContext, IMapper mapper): base(dbContext, mapper) {
         _dbContext = dbContext;
         _mapper = mapper;
      }

      public override async Task<PaymentInfoResponse> Insert(AddPaymentInfo request) {
         var user = await _dbContext.Users.FindAsync(request.UserId);
         if (user == null) return null;

         var cardToInsert = _mapper.Map<CardInfo>(request);
         await _dbContext.Cards.AddAsync(cardToInsert);

         return _mapper.Map<PaymentInfoResponse>(cardToInsert);
      }
   }
}
