using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;

namespace knowledge_hub.WebAPI.Intefraces
{
   public interface IBookService: ICRUDService<BookResponse, BookInsertRequest, BookInsertRequest>
   {
      Task<List<BookResponse>> GetBooksWithIds(string ids);
      Task<List<BookResponse>> SearchBooks(string search);
      Task<List<BookResponse>> GetRecommenedCourses(int userId);
   }
}
