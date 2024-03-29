﻿using knowledge_hub.WebAPI.Intefraces;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace knowledge_hub.WebAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class UserController : CRUDController<UserResponse, UserInsertRequest, UserInsertRequest>
   {
      private readonly IUserService _service;

      public UserController(IUserService service): base(service){
         _service = service;
      }

      [HttpPost("Login")]
      public async Task<UserDataResponse> Login(AuthenticationRequest request) {
         return await _service.Login(request);
      }

      [HttpPost("Register")]
      public async Task<RegisterResponse> Register(LoginRegisterRequest request) {
         return await _service.Register(request);
      }
      [HttpPost("RegisterUser")]
      public async Task<UserResponse> RegisterUser(UserRegisterRequest request) {
         return await _service.RegisterUser(request);
      }
      [HttpPost("UpdatePayment")]
      [Authorize]
      public async Task<PaymentInfoResponse> UpdatePayment(UserPaymentInfoRequest request) {
         return await _service.UpdatePayment(request);
      }
      [HttpPut("UpdatePassword")]
      [Authorize]
      public async Task<HttpStatusCode> UpdatePassword(PasswordUpdateRequest request) {
         return await _service.UpdatePassword(request);
      }
      [HttpPost("UpdateAddress")]
      [Authorize]
      public async Task<AddressResponse> UpdateAddress(UserAddressUpdateRequest request) {
         return await _service.UpdateAddress(request);
      }

      [HttpPut("UserUpdateInfo")]
      [Authorize]
      public async Task<bool> UserUpdateInfo(UserResponse userInfo) {
         return await _service.UserUpdateInfo(userInfo);
      }

      [HttpGet("GetDetailedUserInfo")]
      [Authorize]
      public async Task<UserDataResponse> GetDetailedUserInfo(int ID) {
         return await _service.GetDetailedUserInfo(ID);
      }
   }
}
