using knowledge_hub.WebAPI.Database;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using knowledge_hub.WebAPI.Services;

namespace knowledge_hub.WebAPI.Intefraces
{
   public interface IWishlistService: ICRUDService<WishlistResponse, WishlistSearchRequest, WishlistInsertRequest, WishlistInsertRequest>
   {
      Task<List<BookResponse>> GetByUserId(int userId);
      Task<bool> Check(WishlistInsertRequest request);
      }
   }
