using knowledge_hub.WebAPI.Intefraces;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using Microsoft.AspNetCore.Mvc;

namespace knowledge_hub.WebAPI.Controllers
{
   public class BookController : CRUDController<BookResponse, BookSearchRequest, BookInsertRequest, BookInsertRequest>
   {
      public BookController(ICRUDService<BookResponse, BookSearchRequest, BookInsertRequest, BookInsertRequest> service)
         :base(service) {

      }
   }
}
