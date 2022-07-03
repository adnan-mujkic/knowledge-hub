namespace knowledge_hub.Models.Model.Requests
{
   public class AddPaymentInfo
   {
      public int UserId { get; set; }
      public string FullName { get; set; }
      public string CardNumber { get; set; }
      public string Date { get; set; }
      public string Cvc { get; set; }
   }
}
