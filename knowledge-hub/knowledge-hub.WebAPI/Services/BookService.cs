using AutoMapper;
using knowledge_hub.WebAPI.Database;
using knowledge_hub.WebAPI.Intefraces;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace knowledge_hub.WebAPI.Services
{
   public class BookService: CRUDService<BookResponse, BookInsertRequest, BookInsertRequest, Book>, IBookService
   {
      private readonly databaseContext _dbContext;
      private readonly IMapper _mapper;
      private readonly IWebHostEnvironment _env;

      public BookService(databaseContext dbContext, IMapper mapper, IWebHostEnvironment env) : base(dbContext, mapper) {
         _dbContext = dbContext;
         _mapper = mapper;
         _env = env;
      }
      public override async Task<List<BookResponse>> Get() {
         var databaseEntities = await _dbContext.Set<Book>()
            .Include(c => c.category)
            .Include(l => l.language)
            .ToListAsync();
         
         var booksWithReviews = new List<BookResponse>();
         for (int i = 0; i < databaseEntities.Count; i++)
         {
            var book = _mapper.Map<BookResponse>(databaseEntities[i]);
            book.ImagePath = Path.Combine("http://localhost:5000/BookImages/", databaseEntities[i].ImagePath);

            var comments = await _dbContext.Reviews
            .Where(x => x.BookId == databaseEntities[i].BookId)
            .ToListAsync();

            book.Reviews = _mapper.Map<List<ReviewResponse>>(comments);
            booksWithReviews.Add(book);
         }
         
         return booksWithReviews;
      }

      public override async Task<BookResponse> GetById(int ID, string serverPath) {
         var databaseEntity = await _dbContext.Books
            .Include(x => x.language)
            .Include(x => x.category)
            .Where(x => x.BookId == ID)
            .FirstOrDefaultAsync();

         if (databaseEntity == null) return null;

         var bookWithReview = _mapper.Map<BookResponse>(databaseEntity);
         bookWithReview.ImagePath = Path.Combine("http://localhost:5000/BookImages/", databaseEntity.ImagePath);

         var comments = await _dbContext.Reviews
         .Where(x => x.BookId == databaseEntity.BookId)
         .ToListAsync();
         bookWithReview.Reviews = _mapper.Map<List<ReviewResponse>>(comments);

         return bookWithReview;
      }

      public override async Task<BookResponse> Update(int ID, BookInsertRequest request) {
         //Remove old image and setup new one
         var book = await _dbContext.Books.FindAsync(ID);
         if (book == null) return null;

         string oldImagePath = book.ImagePath;
         string oldFilePath = book.FilePath;
         book = _mapper.Map(request, book);

         string fullOldFilePath = Path.Combine(_env.WebRootPath, oldImagePath);
         File.Delete(fullOldFilePath);
         string imageName = Guid.NewGuid().ToString();
         string imagePath = Path.Combine(_env.WebRootPath, "BookImages", imageName) + ".png";
         await File.WriteAllBytesAsync(imagePath, request.ImagePath);

         if (request.BookFile.Length > 0) {
            File.Delete(Path.Combine(_env.WebRootPath, oldFilePath));
            string bookFileName = Guid.NewGuid().ToString();
            string bookFilePath = Path.Combine(_env.WebRootPath, "BookFiles", bookFileName) + ".pdf";
            await File.WriteAllBytesAsync(bookFilePath, request.BookFile);
            book.FilePath = bookFileName + ".pdf";
         }
         else
         {
            book.FilePath = (await _dbContext.Books.FindAsync(ID)).FilePath;
         }

         book.ImagePath = imageName + ".png";

         await _dbContext.SaveChangesAsync();
         return _mapper.Map<BookResponse>(book);
      }

      public override async Task<BookResponse> Insert(BookInsertRequest request) {
         var bookToInsert = _mapper.Map<Book>(request);
         
         string imageName = Guid.NewGuid().ToString();
         string imagePath = Path.Combine(_env.WebRootPath, "BookImages", imageName) + ".png";
         await File.WriteAllBytesAsync(imagePath, request.ImagePath);

         string bookFileName = Guid.NewGuid().ToString();
         string bookFilePath = Path.Combine(_env.WebRootPath, "BookFiles", bookFileName) + ".pdf";
         await File.WriteAllBytesAsync(bookFilePath, request.BookFile);

         bookToInsert.ImagePath = imageName + ".png";
         bookToInsert.FilePath = bookFileName + ".pdf";

         await _dbContext.Books.AddAsync(bookToInsert);
         await _dbContext.SaveChangesAsync();
         return _mapper.Map<BookResponse>(bookToInsert);
      }
      private static Image ByteArrayToSystemDrawing(byte[] byteArrayIn) {
         MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
         ms.Write(byteArrayIn, 0, byteArrayIn.Length);
         return Image.FromStream(ms, true);
      }

      public async Task<List<BookResponse>> GetBooksWithIds(string ids) {
         string[] idMap = ids.Split(",");
         List<int> idList = new List<int>();
         for (int i = 0; i < idMap.Length; i++)
         {
            idList.Add(Convert.ToInt32(idMap[i]));
         }
         return _mapper.Map<List<BookResponse>>(_dbContext.Books.Where(x => idList.Contains(x.BookId)).ToList());
      }

      public async Task<List<BookResponse>> SearchBooks(string search) {
         var booksSelected = await _dbContext.Books
            .Where(x => x.Name.Contains(search))
            .ToListAsync();

         return _mapper.Map<List<BookResponse>>(booksSelected);
      }
   }
}
