namespace knowledge_hub.WebAPI.Intefraces
{
   public interface ICRUDService<T, TSearch, TInsert, TUpdate>
   {
      Task<List<T>> Get();
      Task<T> GetById(int ID);
      Task<T> Insert(TInsert request);
      Task<T> Update(int ID, TUpdate reuqest);
      Task<bool> Delete(int ID);
   }
}
