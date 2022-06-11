using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace knowledge_hub.WebAPI.Intefraces
{
   public interface IUserService: ICRUDService<UserResponse, UserSearchRequest, UserInsertRequest, UserInsertRequest>
   {
      Task<UserResponse> Login(AuthenticationRequest request);
      Task<RegisterResponse> Register(LoginRegisterRequest request);
      Task<UserResponse> RegisterUser(UserRegisterRequest request);
      Task<UserResponse> UpdateAddress(UserAddressUpdateRequest request);
      Task<PaymentInfoResponse> UpdatePayment(UserPaymentInfoRequest request);
      Task<HttpStatusCode> UpdatePassword(PasswordUpdateRequest request);
   }
}
