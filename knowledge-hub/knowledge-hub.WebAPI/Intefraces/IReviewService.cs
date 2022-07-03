using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;

namespace knowledge_hub.WebAPI.Intefraces
{
   public interface IReviewService: ICRUDService<ReviewResponse, ReviewAddRequest, ReviewAddRequest>
   {
      Task<List<ReviewResponse>> GetByBook(int bookId);
   }
}
