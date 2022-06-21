namespace knowledge_hub.WebAPI.Database
{
   public class Address
   {
      public int AddressId { get; set; }
      public string FullName { get; set; }
      public string AddressLine { get; set; }
      public int CityId { get; set; }
      public City City { get; set; }
      public int UserId { get; set; }
      public User User { get; set; }
   }
}
