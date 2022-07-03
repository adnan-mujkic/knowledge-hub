using System.ComponentModel.DataAnnotations;

namespace knowledge_hub.WebAPI.Database
{
   public class CardInfo
   {
      [Key]
      public int CardInfoId { get; set; }
      public string FullName { get; set; }
      public string CardNumber { get; set; }
      public string CardDate { get; set; }
      public int UserId { get; set; }
      public User User { get; set; }
   }
}
