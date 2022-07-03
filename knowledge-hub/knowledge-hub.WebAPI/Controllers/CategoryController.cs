using knowledge_hub.WebAPI.Intefraces;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using Microsoft.AspNetCore.Mvc;

namespace knowledge_hub.WebAPI.Controllers
{
   public class CategoryController : CRUDController<CategoryResponse, CategoryInsertRequest, CategoryInsertRequest>
   {
      public CategoryController(ICRUDService<CategoryResponse, CategoryInsertRequest, CategoryInsertRequest> service)
         : base(service) {

      }
   }
}
