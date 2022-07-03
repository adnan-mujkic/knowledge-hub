using knowledge_hub.WebAPI.Database;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using knowledge_hub.WebAPI.Services;

namespace knowledge_hub.WebAPI.Intefraces
{
   public interface ITransactionService : ICRUDService<TransactionResponse, TransactionInsertRequest, TransactionInsertRequest>
   {
      Task<List<TransactionResponse>> Search(string username);
   }
}
