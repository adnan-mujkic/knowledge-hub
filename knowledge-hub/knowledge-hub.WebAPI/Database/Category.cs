using System.ComponentModel.DataAnnotations;

namespace knowledge_hub.WebAPI.Database
{
   public class Category
   {
      [Key]
      public int CategoryId { get; set; }
      public string Name { get; set; }
   }
}
