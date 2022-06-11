using System.ComponentModel.DataAnnotations;

namespace knowledge_hub.WebAPI.Database
{
   public class Transaction
   {
      [Key]
      public int TransactionId { get; set; }
      public int OrderId { get; set; }
      public Order Order { get; set; }
      public int CardInfoId { get; set; }
      public CardInfo CardInfo { get; set; }
      public DateTime TransactionTime { get; set; }
      public double Price { get; set; }
   }
}
