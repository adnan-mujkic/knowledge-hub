namespace knowledge_hub.WebAPI.Model.Responses
{
   public class PaymentInfoResponse
   {
      public int cardInfoId { get; set; }
      public string FullName { get; set; }
      public string CardNumber { get; set; }
      public string Date { get; set; }
      public string Cvc { get; set; }
   }
}
