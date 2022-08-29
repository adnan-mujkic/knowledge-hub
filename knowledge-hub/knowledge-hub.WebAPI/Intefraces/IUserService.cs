using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace knowledge_hub.WebAPI.Intefraces
{
   public interface IUserService: ICRUDService<UserResponse, UserInsertRequest, UserInsertRequest>
   {
      Task<UserDataResponse> Login(AuthenticationRequest request);
      Task<RegisterResponse> Register(LoginRegisterRequest request);
      Task<UserResponse> RegisterUser(UserRegisterRequest request);
      Task<PaymentInfoResponse> UpdatePayment(UserPaymentInfoRequest request);
      Task<HttpStatusCode> UpdatePassword(PasswordUpdateRequest request);
      Task<AddressResponse> UpdateAddress(UserAddressUpdateRequest request);
      Task<bool> UserUpdateInfo(UserResponse userInfo);
      Task<UserDataResponse> GetDetailedUserInfo(int ID);
      Task<List<UserResponse>> SearchUser(string search);
   }
}
