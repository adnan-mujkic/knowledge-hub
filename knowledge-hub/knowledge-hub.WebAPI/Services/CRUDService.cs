using AutoMapper;
using knowledge_hub.WebAPI.Database;
using knowledge_hub.WebAPI.Intefraces;
using Microsoft.EntityFrameworkCore;

namespace knowledge_hub.WebAPI.Services
{
   public class CRUDService<T, TInsert, TUpdate, TDatabase> : ICRUDService<T, TInsert, TUpdate>
      where TDatabase : class
   {
      private readonly databaseContext _dbContext;
      private readonly IMapper _mapper;
      public CRUDService(databaseContext context, IMapper mapper){
         _dbContext = context;
         _mapper = mapper;
      }

      public virtual async Task<bool> Delete(int ID) {
         var databaseEntity = await _dbContext.Set<TDatabase>().FindAsync(ID);
         try
         {
            _dbContext.Set<TDatabase>().Remove(databaseEntity);
            await _dbContext.SaveChangesAsync();
            return true;
         }
         catch (Exception e)
         {
            return false;
         }
      }

      public virtual async Task<List<T>> Get(string? search) {
         var databaseEntities = await _dbContext.Set<TDatabase>().ToListAsync();
         return _mapper.Map<List<T>>(databaseEntities);
      }

      public virtual async Task<T> GetById(int ID, string serverPath) {
         var databaseEntity = await _dbContext.Set<TDatabase>().FindAsync(ID);
         return _mapper.Map<T>(databaseEntity);
      }

      public virtual async Task<T> Insert(TInsert request) {
         var insertEntity = _mapper.Map<TDatabase>(request);
         _dbContext.Set<TDatabase>().Add(insertEntity);
         await _dbContext.SaveChangesAsync();

         return _mapper.Map<T>(insertEntity);
      }

      public virtual async Task<T> Update(int ID, TUpdate request) {
         var databaseEntity = await _dbContext.Set<TDatabase>().FindAsync(ID);

         if (databaseEntity == null) return default(T);

         _dbContext.Set<TDatabase>().Attach(databaseEntity);
         _dbContext.Set<TDatabase>().Update(databaseEntity);

         _mapper.Map(request, databaseEntity);
         await _dbContext.SaveChangesAsync();

         return _mapper.Map<T>(databaseEntity);
      }
   }
}
