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
         return _mapper.Map<List<BookResponse>>(databaseEntities);
      }
   }
}
