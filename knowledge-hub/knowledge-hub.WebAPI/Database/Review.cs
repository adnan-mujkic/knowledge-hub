using System.ComponentModel.DataAnnotations;

namespace knowledge_hub.WebAPI.Database
{
   public class Review
   {
      [Key]
      public int ReviewId { get; set; }

      [Required]
      public int UserId { get; set; }
      public virtual User user { get; set; }

      [Required]
      public int BookId { get; set; }
      public virtual Book book { get; set; }
      public string Comment { get; set; }
      public double Score { get; set; }
      public DateTime PostDate { get; set; }
   }
}
