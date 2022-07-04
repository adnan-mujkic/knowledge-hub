using knowledge_hub.WebAPI.Intefraces;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using Microsoft.AspNetCore.Mvc;

namespace knowledge_hub.WebAPI.Controllers
{
   public class OrderController : CRUDController<OrderResponse, OrderInsertRequest, OrderUpdateRequest>
   {
      private readonly IOrderService _service;
      public OrderController(IOrderService service)
         :base(service){
         _service = service;
      }

      [HttpPost("InsertMany")]
      public async Task<List<OrderResponse>> InsertMany(OrderInsertRequest request) {
         return await _service.InsertMany(request);
      }
      [HttpPost("InitiatePayment")]
      public async Task<string> InitiatePayment(OrderInsertRequest request) {
         return await _service.InitiatePayment(request);
      }

      [HttpGet("GetBoughtBooksByUser")]
      public async Task<List<BookResponse>> GetBoughtBooksByUser(int ID) {
         return await _service.GetBoughtBooksByUser(ID);
      }
      [HttpGet("GetByUser")]
      public async Task<List<OrderResponse>> GetByUser(int ID) {
         return await _service.GetByUser(ID);
      }
   }
}
