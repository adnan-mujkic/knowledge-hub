using AutoMapper;
using knowledge_hub.WebAPI.Database;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;

namespace knowledge_hub.WebAPI.Services
{
   public class WishlistService: CRUDService<BookResponse, WishlistRequest, WishlistRequest, WishlistRequest, BookUserWishlist>
   {
      private readonly databaseContext _dbContext;
      private readonly IMapper _mapper;
      public WishlistService(databaseContext dbContext, IMapper mapper) : base(dbContext, mapper) {
         _dbContext = dbContext;
         _mapper = mapper;
      }
   }
}
