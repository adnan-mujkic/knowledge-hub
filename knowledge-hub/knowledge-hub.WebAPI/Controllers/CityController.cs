using knowledge_hub.WebAPI.Intefraces;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using Microsoft.AspNetCore.Mvc;

namespace knowledge_hub.WebAPI.Controllers
{
   public class CityController : CRUDController<CityResponse, CitySearchRequest, CityInsertRequest, CityInsertRequest>
   {
      public CityController(ICRUDService<CityResponse, CitySearchRequest, CityInsertRequest, CityInsertRequest> service)
         : base(service) {

      }
   }
}
