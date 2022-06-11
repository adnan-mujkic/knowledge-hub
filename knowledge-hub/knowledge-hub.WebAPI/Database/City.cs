using System.ComponentModel.DataAnnotations;

namespace knowledge_hub.WebAPI.Database
{
   public class City
   {
      [Key]
      public int CityId { get; set; }
      public string Name { get; set; }
      public string ZipCode { get; set; }
      public string Country { get; set; }
   }
}
