using knowledge_hub.WebAPI.Intefraces;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using Microsoft.AspNetCore.Mvc;

namespace knowledge_hub.WebAPI.Controllers
{
   public class TransactionController : CRUDController<TransactionResponse, TransactionInsertRequest, TransactionInsertRequest>
   {
      public readonly ITransactionService _service;
      public TransactionController(ITransactionService service)
         : base(service) {
         _service = service;
      }

      [HttpGet("Search")]
      public async Task<List<TransactionResponse>> Search(string username) {
         return await _service.Search(username);
      }
   }
}
