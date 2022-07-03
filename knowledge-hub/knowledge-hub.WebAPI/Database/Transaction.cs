using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace knowledge_hub.WebAPI.Database
{
   public class Transaction
   {
      [Key]
      public int TransactionId { get; set; }
      public int? OrderId { get; set; }
      [ForeignKey("OrderId")]
      public virtual Order Order { get; set; }
      public int? CardInfoId { get; set; }
      [ForeignKey("CardInfoId")]
      public virtual CardInfo CardInfo { get; set; }
      public DateTime TransactionTime { get; set; }
      public double Price { get; set; }
   }
}
