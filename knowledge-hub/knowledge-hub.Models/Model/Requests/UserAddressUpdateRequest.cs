namespace knowledge_hub.Models.Model.Requests
{
   public class UserAddressUpdateRequest
   {
      public int UserId { get; set; }
      public string FullName { get; set; }
      public string AddressLine { get; set; }
      public string City { get; set; }
   }
}
