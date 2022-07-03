namespace knowledge_hub.WebAPI.Intefraces
{
   public interface ICRUDService<T, TInsert, TUpdate>
   {
      Task<List<T>> Get();
      Task<T> GetById(int ID, string serverPath);
      Task<T> Insert(TInsert request);
      Task<T> Update(int ID, TUpdate reuqest);
      Task<bool> Delete(int ID);
   }
}
