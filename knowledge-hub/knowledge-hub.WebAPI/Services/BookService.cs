﻿using AutoMapper;
using knowledge_hub.WebAPI.Database;
using knowledge_hub.WebAPI.Intefraces;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace knowledge_hub.WebAPI.Services
{
   public class BookService : CRUDService<BookResponse, BookInsertRequest, BookInsertRequest, Book>, IBookService
   {
      private readonly databaseContext _dbContext;
      private readonly IMapper _mapper;
      private readonly IWebHostEnvironment _env;

      public BookService(databaseContext dbContext, IMapper mapper, IWebHostEnvironment env) : base(dbContext, mapper) {
         _dbContext = dbContext;
         _mapper = mapper;
         _env = env;
      }
      public override async Task<List<BookResponse>> Get(string? search) {
         var databaseEntities = await (string.IsNullOrEmpty(search)?
            _dbContext.Books:
            _dbContext.Books.Where(x => x.Name.Contains(search)))
            .Include(c => c.category)
            .Include(l => l.language)
            .ToListAsync();

         var booksWithReviews = new List<BookResponse>();
         for (int i = 0; i < databaseEntities.Count; i++)
         {
            var book = _mapper.Map<BookResponse>(databaseEntities[i]);
            book.ImagePath = databaseEntities[i].ImagePath;

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
         bookWithReview.ImagePath = databaseEntity.ImagePath;

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

         if (request.BookFile.Length > 0)
         {
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

      public async Task<List<BookResponse>> GetRecommenedCourses(int userId) {
         try
         {
            if (userId == 0)
               throw new Exception();

            var reviews = await _dbContext.Reviews
               .Where(x => x.UserId == userId)
               .Include(x => x.user)
               .Include(x => x.book)
               .ThenInclude(x => x.language)
               .Include(x => x.book)
               .ThenInclude(x => x.category)
               .ToListAsync();

            if (reviews == null)
               throw new Exception();

            var bestUserReviews = reviews.Where(x => x.Score >= 4).ToList();

            if (bestUserReviews.Count > 0)
            {
               var bookCategories = new List<Category>();

               foreach (var review in bestUserReviews)
               {
                  var bookCategoriesFiltered = await _dbContext.Books
                     .Where(x => x.CategoryId == review.book.CategoryId)
                     .Select(x => x.category)
                     .ToListAsync();

                  foreach (var filter in bookCategoriesFiltered)
                  {
                     bool adding = !bookCategories.Select(x => x.Name).Contains(filter.Name);
                     if (adding)
                        bookCategories.Add(filter);
                  }
               }


               List<Book> finalBookList = new List<Book>();
               var userBoughtBooks = await _dbContext.Orders
                     .Where(x => x.UserId == userId)
                     .Include(x => x.Book)
                     .ThenInclude(x => x.language)
                     .Include(x => x.Book)
                     .ThenInclude(x => x.category)
                     .Select(x => x.Book)
                     .ToListAsync();

               if (userBoughtBooks == null)
                  throw new Exception();

               foreach (var item in bookCategories)
               {
                  var categoryBook = await _dbContext.Books
                     .Where(x => x.CategoryId == item.CategoryId)
                     .ToListAsync();

                  foreach (var book in categoryBook)
                  {
                     bool adding = true;
                     bool doesContain = userBoughtBooks.Where(x => x.BookId == book.BookId).Any();
                     if (!doesContain)
                     {
                        for (int i = 0; i < finalBookList.Count; i++)
                        {
                           if (book.Name == finalBookList[i].Name)
                              adding = false;
                        }
                        foreach (var score in reviews)
                        {
                           if (book.Name == score.book.Name)
                              adding = false;
                        }
                        if (adding)
                           finalBookList.Add(book);
                     }
                  }
               }

               finalBookList = finalBookList.OrderBy(x => Guid.NewGuid()).Take(5).ToList();

               return _mapper.Map<List<BookResponse>>(finalBookList);
            }
            throw new Exception();
         }
         catch
         {
            return _mapper.Map<List<BookResponse>>(null);
         }
      }
   }
}
