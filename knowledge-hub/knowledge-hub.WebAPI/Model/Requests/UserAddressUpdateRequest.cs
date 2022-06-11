namespace knowledge_hub.WebAPI.Model.Requests
{
   public class UserAddressUpdateRequest
   {
      public int UserID { get; set; }
      public string FullName { get; set; }
      public string AddressLine { get; set; }
      public string City { get; set; }
      public string Postcode { get; set; }
   }
}
