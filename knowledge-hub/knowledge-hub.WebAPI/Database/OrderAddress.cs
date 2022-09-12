using System.ComponentModel.DataAnnotations;

namespace knowledge_hub.WebAPI.Database
{
    public class OrderAddress
    {
        [Key]
        public int OrderAddressId { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string? Comment { get; set; }
        public string? AddressLine { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
