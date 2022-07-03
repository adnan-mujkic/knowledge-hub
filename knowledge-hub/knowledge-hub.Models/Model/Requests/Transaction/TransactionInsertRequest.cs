using System;

namespace knowledge_hub.Models.Model.Requests
{
   public class TransactionInsertRequest
   {
      public string fullName { get; set; }
      public int orderId { get; set; }
      public int cardInfoId { get; set; }
      public DateTime transactionTime { get; set; }
      public double price { get; set; }
   }
}
