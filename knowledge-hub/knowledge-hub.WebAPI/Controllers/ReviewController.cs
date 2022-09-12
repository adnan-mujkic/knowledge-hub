using knowledge_hub.WebAPI.Intefraces;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace knowledge_hub.WebAPI.Controllers
{
   public class ReviewController : CRUDController<ReviewResponse, ReviewAddRequest, ReviewAddRequest>
   {
      private readonly IReviewService _service;
      public ReviewController(IReviewService service)
         : base(service) {
         _service = service;
      }

      [HttpGet("GetByBook")]
      public async Task<List<ReviewResponse>> GetByBook(int bookId) {
         return await _service.GetByBook(bookId);
      }
        [HttpDelete]
        [Authorize]
        public override Task<bool> Delete(int ID)
        {
            return base.Delete(ID);
        }
    }
}
