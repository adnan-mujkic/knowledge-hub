using System.ComponentModel.DataAnnotations;

namespace knowledge_hub.WebAPI.Database
{
   public class City
   {
      [Key]
      public int CityId { get; set; }

      [Required]
      public string Name { get; set; }

      [Required]
      public string ZipCode { get; set; }

      [Required]
      public string Country { get; set; }
   }
}
