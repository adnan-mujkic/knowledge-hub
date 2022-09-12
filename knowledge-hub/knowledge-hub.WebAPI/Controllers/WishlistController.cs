using knowledge_hub.WebAPI.Database;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using knowledge_hub.WebAPI.Intefraces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace knowledge_hub.WebAPI.Controllers
{
   public class WishlistController : CRUDController<WishlistResponse, WishlistInsertRequest, WishlistInsertRequest>
   {
      private readonly IWishlistService _service;
      public WishlistController(IWishlistService service)
         : base(service) {
         _service = service;
      }
      [HttpGet("WishlistByUserId")]
      public async Task<List<BookResponse>> GetByUserId(int userId) {
         return await _service.GetByUserId(userId);
      }
      [HttpGet("Check")]
      public async Task<bool> Check(WishlistInsertRequest request) {
         return await _service.Check(request);
      }

      [HttpDelete]
      [Authorize(Roles = "Admin,User")]
      public override Task<bool> Delete(int ID) {
         return base.Delete(ID);
      }
    }
}
