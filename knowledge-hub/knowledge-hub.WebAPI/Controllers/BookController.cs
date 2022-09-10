using AutoMapper;
using knowledge_hub.WebAPI.Intefraces;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace knowledge_hub.WebAPI.Controllers
{
   public class BookController : CRUDController<BookResponse, BookInsertRequest, BookInsertRequest>
   {
      public readonly IBookService _service;
      public BookController(IBookService service)
         :base(service) {
         _service = service;
      }

      [HttpGet("RecommenedCourses")]
      public async Task<List<BookResponse>> GetRecommenedCourses(int userId) {
         return await _service.GetRecommenedCourses(userId);
      }
   }
}
