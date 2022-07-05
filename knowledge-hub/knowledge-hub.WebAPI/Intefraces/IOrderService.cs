using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;

namespace knowledge_hub.WebAPI.Intefraces
{
   public interface IOrderService : ICRUDService<OrderResponse, OrderInsertRequest, OrderUpdateRequest>
   {
      Task<List<OrderResponse>> InsertMany(OrderInsertRequest request);
      Task<string> InitiatePayment(OrderInsertRequest request);
      Task<List<OrderResponse>> GetByUser(int UserId);
      Task<List<OrderResponse>> GetPhysical();
      Task<List<BookResponse>> GetBoughtBooksByUser(int ID);
   }
}
