using knowledge_hub.WebAPI.Intefraces;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using Microsoft.AspNetCore.Mvc;

namespace knowledge_hub.WebAPI.Controllers
{
   public class LanguageController : CRUDController<LanguageResponse, LanguageInsertRequest, LanguageInsertRequest>
   {
      public LanguageController(ICRUDService<LanguageResponse, LanguageInsertRequest, LanguageInsertRequest> service)
         : base(service) {

      }
   }
}
