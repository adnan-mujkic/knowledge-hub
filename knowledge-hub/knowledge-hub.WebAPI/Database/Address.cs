using System.ComponentModel.DataAnnotations;

namespace knowledge_hub.WebAPI.Database
{
   public class Address
   {
      public int AddressId { get; set; }

      [Required]
      public string FullName { get; set; }

      [Required]
      public string AddressLine { get; set; }

      public int CityId { get; set; }
      public City City { get; set; }

      public int UserId { get; set; }
      public User User { get; set; }
   }
}
