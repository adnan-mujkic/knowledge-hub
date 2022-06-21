using knowledge_hub.WebAPI.Intefraces;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;

namespace knowledge_hub.WebAPI.Controllers
{
   public class CardController : CRUDController<PaymentInfoResponse, UserPaymentInfoRequest, AddPaymentInfo, AddPaymentInfo>
   {
      public CardController(ICRUDService<PaymentInfoResponse, UserPaymentInfoRequest, AddPaymentInfo, AddPaymentInfo> service)
         : base(service) {

      }
   }
}
