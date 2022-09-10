using System.ComponentModel.DataAnnotations;

namespace knowledge_hub.WebAPI.Database
{
   public class Order
   {
      [Key]
      public int OrderId { get; set; }

      [Required]
      public string OrderNumber { get; set; }

      [Required]
      public bool Digital { get; set; }

      [Required]
      public int UserId { get; set; }
      public User User { get; set; }

      [Required]
      public string UserFullName { get; set; }

      public int BookId { get; set; }
      public Book Book { get; set; }

      public DateTime OrderDate { get; set; }

      public DateTime ShippingDate { get; set; }

      public int OrderStatus { get; set; }

      public string? Comment { get; set; }
      public string? AddressLine { get; set; }
      public int? CityId { get; set; }
      public City City { get; set; }
   }
}
