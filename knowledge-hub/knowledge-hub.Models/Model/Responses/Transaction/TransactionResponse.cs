namespace knowledge_hub.Models.Model.Responses
{
   public class TransactionResponse
   {
      public int transactionId { get; set; }
      public int orderId { get; set; }
      public OrderResponse order { get; set; }
      public string bookName { get; set; }
      public string userFullName { get; set; }
      public string cardLastDigits { get; set; }
      public string transactionDate { get; set; }
      public double price { get; set; }
   }
}
