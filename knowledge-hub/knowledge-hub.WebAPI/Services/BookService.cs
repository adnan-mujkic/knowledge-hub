using AutoMapper;
using knowledge_hub.WebAPI.Database;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using Microsoft.EntityFrameworkCore;

namespace knowledge_hub.WebAPI.Services
{
   public class BookService: CRUDService<BookResponse, BookSearchRequest, BookInsertRequest, BookInsertRequest, Book>
   {
      private readonly databaseContext _dbContext;
      private readonly IMapper _mapper;
      public BookService(databaseContext dbContext, IMapper mapper):base(dbContext,mapper) {
         _dbContext = dbContext;
         _mapper = mapper;
      }
      public override async Task<List<BookResponse>> Get() {
         var databaseEntities = await _dbContext.Set<Book>()
            .Include(c => c.category)
            .Include(l => l.language)
            .ToListAsync();
         
         var booksWithReviews = new List<BookResponse>();
         for (int i = 0; i < databaseEntities.Count - 1; i++)
         {
            var book = _mapper.Map<BookResponse>(databaseEntities[i]);

            var comments = await _dbContext.Reviews
            .Where(x => x.BookId == databaseEntities[i].BookId)
            .ToListAsync();

            book.Reviews = _mapper.Map<List<ReviewResponse>>(comments);
            booksWithReviews.Add(book);
         }
         
         return booksWithReviews;
      }
   }
}
