using knowledge_hub.WebAPI.Database;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using knowledge_hub.WebAPI.Intefraces;

namespace knowledge_hub.WebAPI.Controllers
{
   public class WishlistController : CRUDController<BookResponse, WishlistRequest, WishlistRequest, WishlistRequest>
   {
      public WishlistController(ICRUDService<BookResponse, WishlistRequest, WishlistRequest, WishlistRequest> service)
         : base(service) {

      }
   }
}
