using AutoMapper;
using knowledge_hub.WebAPI.Database;
using knowledge_hub.WebAPI.Intefraces;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using Microsoft.EntityFrameworkCore;

namespace knowledge_hub.WebAPI.Services
{
   public class ReviewService : CRUDService<ReviewResponse, ReviewSearchRequest, ReviewAddRequest, ReviewAddRequest, Review>, IReviewService
   {
      private readonly databaseContext _dbContext;
      private readonly IMapper _mapper;
      public ReviewService(databaseContext dbContext, IMapper mapper) : base(dbContext, mapper) {
         _dbContext = dbContext;
         _mapper = mapper;
      }

      public async Task<List<ReviewResponse>> GetByBook(int bookId) {
         var books = await _dbContext.Reviews
            .Where(x => x.BookId == bookId)
            .Include(x => x.user)
            .ToListAsync();

         var bookResponseList = new List<ReviewResponse>();
         foreach (var book in books)
         {
            bookResponseList.Add(_mapper.Map<ReviewResponse>(book));
         }

         return bookResponseList;
      }
   }
}
