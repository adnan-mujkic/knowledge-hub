using System.ComponentModel.DataAnnotations;

namespace knowledge_hub.WebAPI.Database
{
   public class Book
   {
      [Key]
      public int BookId { get; set; }

      [Required]
      public string Name { get; set; }

      [Required]
      public string Author { get; set; }

      [Required]
      public string Description { get; set; }


      public string ImagePath { get; set; }

      [Required]
      public string FilePath { get; set; }

      public double PricePhysical { get; set; }

      public double PriceDigital { get; set; }

      public double Score { get; set; }

      public int LanguageId { get; set; }
      public virtual Language language { get; set; }

      public int CategoryId { get; set; }
      public virtual Category category { get; set; }

   }
}
