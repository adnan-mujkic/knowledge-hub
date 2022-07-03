using AutoMapper;
using knowledge_hub.WebAPI.Database;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;

namespace knowledge_hub.WebAPI.Services
{
   public class CategoryService : CRUDService<CategoryResponse, CategoryInsertRequest, CategoryInsertRequest, Category>
   {
      private readonly databaseContext _dbContext;
      private readonly IMapper _mapper;
      public CategoryService(databaseContext dbContext, IMapper mapper) : base(dbContext, mapper) {
         _dbContext = dbContext;
         _mapper = mapper;
      }
   }
}
