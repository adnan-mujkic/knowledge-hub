
namespace knowledge_hub.WebAPI.Model.Responses
{
   public class UserDataResponse
   {
      public LoginData authData { get; set; }
      public UserResponse userData { get; set; }
      public AddressResponse? addressData { get; set; }
      public PaymentInfoResponse? paymentData { get; set; }
      public List<BookResponse>? myBooks { get; set; }
      public List<BookResponse>? wishlist { get; set; }
   }

   public class LoginData {
      public string email { get; set; }
      public string password { get; set; }
   }
}
