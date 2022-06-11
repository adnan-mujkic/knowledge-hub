namespace knowledge_hub.WebAPI.Model.Requests
{
   public class UserPaymentInfoRequest
   {
      public int UserId { get; set; }
      public string FullName { get; set; }
      public string CardNumber { get; set; }
      public string Date { get; set; }
      public string Cvc { get; set; }
   }
}
