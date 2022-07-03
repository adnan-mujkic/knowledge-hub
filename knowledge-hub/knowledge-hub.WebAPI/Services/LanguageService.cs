using AutoMapper;
using knowledge_hub.WebAPI.Database;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;

namespace knowledge_hub.WebAPI.Services
{
   public class LanguageService : CRUDService<LanguageResponse, LanguageInsertRequest, LanguageInsertRequest, Language>
   {
      private readonly databaseContext _dbContext;
      private readonly IMapper _mapper;
      public LanguageService(databaseContext dbContext, IMapper mapper) : base(dbContext, mapper) {
         _dbContext = dbContext;
         _mapper = mapper;
      }
   }
}
