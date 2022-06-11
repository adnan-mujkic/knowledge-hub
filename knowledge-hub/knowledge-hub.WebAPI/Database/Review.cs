using System.ComponentModel.DataAnnotations;

namespace knowledge_hub.WebAPI.Database
{
   public class Review
   {
      [Key]
      public int ReviewId { get; set; }
      public int UserId { get; set; }
      public virtual User user { get; set; }
      public int BookId { get; set; }
      public virtual Book book { get; set; }
      public string Comment { get; set; }
      public double Score { get; set; }
      public DateTime PostDate { get; set; }
   }
}
