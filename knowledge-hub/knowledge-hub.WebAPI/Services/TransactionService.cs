using AutoMapper;
using knowledge_hub.WebAPI.Database;
using knowledge_hub.WebAPI.Intefraces;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using Microsoft.EntityFrameworkCore;

namespace knowledge_hub.WebAPI.Services
{
   public class TransactionService : CRUDService<TransactionResponse, TransactionInsertRequest, TransactionInsertRequest, Transaction>, ITransactionService
   {
      private readonly databaseContext _dbContext;
      private readonly IMapper _mapper;

      public TransactionService(databaseContext dbContext, IMapper mapper) : base(dbContext, mapper) {
         _dbContext = dbContext;
         _mapper = mapper;
      }

      public override async Task<List<TransactionResponse>> Get() {
         try
         {
            var transactions = await _dbContext.Transactions
               .Include(x => x.Order)
               .ThenInclude(x => x.User)
               .Include(x => x.Order)
               .ThenInclude(x => x.Book)
               .Include(x => x.CardInfo)
               .ToListAsync();


            return _mapper.Map<List<TransactionResponse>>(transactions);
         }
         catch (Exception e)
         {
            return null;
         }
      }

      public override async Task<TransactionResponse> GetById(int ID, string serverPath) {
         try
         {
            var transaction = await _dbContext.Transactions
               .Include(x => x.Order)
               .ThenInclude(x => x.User)
               .Include(x => x.Order)
               .ThenInclude(x => x.Book)
               .Include(x => x.CardInfo)
               .FirstOrDefaultAsync();

            return _mapper.Map<TransactionResponse>(transaction); ;
         }
         catch (Exception e)
         {
            return null;
         }
      }

      public async Task<List<TransactionResponse>> Search(string username) {
         var transactions = await _dbContext.Transactions
            .Include(x => x.Order)
            .ThenInclude(x => x.Book)
            .Include(x => x.Order)
            .ThenInclude(x => x.User)
            .Include(x => x.CardInfo)
            .Where(x => x.Order.UserFullName.Contains(username))
            .ToListAsync();

         return _mapper.Map<List<TransactionResponse>>(transactions);
      }
   }
}
