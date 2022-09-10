﻿using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;

namespace knowledge_hub.WebAPI.Intefraces
{
   public interface IBookService: ICRUDService<BookResponse, BookInsertRequest, BookInsertRequest>
   {
      Task<List<BookResponse>> GetRecommenedCourses(int userId);
   }
}
