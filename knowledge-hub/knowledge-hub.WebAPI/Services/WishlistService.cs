using AutoMapper;
using knowledge_hub.WebAPI.Database;
using knowledge_hub.WebAPI.Intefraces;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using Microsoft.EntityFrameworkCore;

namespace knowledge_hub.WebAPI.Services
{
   public class WishlistService: CRUDService<WishlistResponse, WishlistInsertRequest, WishlistInsertRequest, BookUserWishlist>, IWishlistService
   {
      private readonly databaseContext _dbContext;
      private readonly IMapper _mapper;
      public WishlistService(databaseContext dbContext, IMapper mapper) : base(dbContext, mapper) {
         _dbContext = dbContext;
         _mapper = mapper;
      }

      public override Task<List<WishlistResponse>> Get(string search) {
         return Task.FromResult(new List<WishlistResponse>());
      }

      public async Task<List<BookResponse>> GetByUserId(int userId) {
         var userWishlist = await _dbContext.Whishlist
            .Where(x => x.UserId == userId)
            .Include(x => x.Book).ThenInclude(x => x.language)
            .Include(x => x.Book).ThenInclude(x => x.category)
            .ToListAsync();
         if (userWishlist == null || userWishlist.Count == 0) return null;

         List<BookResponse> bookList = new List<BookResponse>();
         foreach (var wishlistItem in userWishlist)
         {
            bookList.Add(_mapper.Map<BookResponse>(wishlistItem.Book));
         }

         return bookList;
      }

      public override async Task<WishlistResponse> Insert(WishlistInsertRequest request) {
         if (request.UserId == 0 || request.BookId == 0) return null;

         var wishlistItem = _mapper.Map<BookUserWishlist>(request);
         _dbContext.Whishlist.Add(wishlistItem);
         await _dbContext.SaveChangesAsync();

         var book = await _dbContext.Books
            .Where(x => x.BookId == wishlistItem.BookId)
            .Include(x => x.language)
            .Include(x => x.category)
            .FirstOrDefaultAsync();
         var response = _mapper.Map<WishlistResponse>(wishlistItem);
         response.Book = _mapper.Map<BookResponse>(book);

         return response;
      }

      public async Task<bool> Check(WishlistInsertRequest request) {
         return (await _dbContext.Whishlist
            .Where(x => x.BookId == request.BookId && x.UserId == request.UserId)
            .CountAsync()) > 0;
      }

      public override async Task<bool> Delete(int ID) {
         var databaseEntity = await _dbContext.Whishlist.Where(x => x.BookId == ID).FirstOrDefaultAsync();
         try
         {
            _dbContext.Whishlist.Remove(databaseEntity);
            await _dbContext.SaveChangesAsync();
            return true;
         }
         catch (Exception e)
         {
            return false;
         }
      }
   }
}
