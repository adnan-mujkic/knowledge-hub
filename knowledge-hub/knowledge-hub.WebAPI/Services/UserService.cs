using AutoMapper;
using knowledge_hub.WebAPI.Database;
using knowledge_hub.WebAPI.Intefraces;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using knowledge_hub.WebAPI.Helpers;
using System.Net;

namespace knowledge_hub.WebAPI.Services
{
   public class UserService : CRUDService<UserResponse, UserSearchRequest, UserInsertRequest, UserInsertRequest, User>, IUserService
   {
      private readonly databaseContext _dbContext;
      private readonly IMapper _mapper;
      public UserService(databaseContext context, IMapper mapper): base(context, mapper) {
         _dbContext = context;
         _mapper = mapper;
      }
      public async Task<UserResponse> Login(AuthenticationRequest request) {
         var login = await _dbContext.Logins
            .Include(x => x.User)
            .ThenInclude(u => u.UserRole)
            .FirstOrDefaultAsync(x => x.Email == request.Email);

         if(login != null)
         {
            var checkHash = PasswordHelper.GeneratePasswordHash(login.PasswordSalt, request.Password);
            if(checkHash == login.PasswordHash)
            {
               return _mapper.Map<UserResponse>(login);
            }
         }

         return new UserResponse() { Message = "Account does not exist!" };
      }
      public async Task<RegisterResponse> Register(LoginRegisterRequest request) {
         if (request.Password != request.ConfirmPassword)
            return new RegisterResponse() { Message = "Passwords do not match!"};

         var emailExists = _dbContext.Logins.Select(l => l.Email).Contains(request.Email);
         if (emailExists)
            return new RegisterResponse() { Message = "Email already exists!" };

         var dbLoginEntity = _mapper.Map<Login>(request);
         dbLoginEntity.PasswordSalt = PasswordHelper.GeneratePasswordSalt();
         dbLoginEntity.PasswordHash = PasswordHelper.GeneratePasswordHash(dbLoginEntity.PasswordSalt, request.Password);

         await _dbContext.Logins.AddAsync(dbLoginEntity);
         await _dbContext.SaveChangesAsync();

         return new RegisterResponse() { LoginId = dbLoginEntity.LoginId };
      }
      public async Task<UserResponse> RegisterUser(UserRegisterRequest request) {
         var userEntity = _mapper.Map<User>(request);
         userEntity.ImagePath = "";
         userEntity.Biography = "";
         await _dbContext.Users.AddAsync(userEntity);
         await _dbContext.SaveChangesAsync();

         var userRole = new UserRoles()
         {
            UserID = userEntity.UserId,
            RoleID = 2,
         };
         await _dbContext.UserRoles.AddAsync(userRole);

         var login = await _dbContext.Logins.SingleOrDefaultAsync(l => l.LoginId == request.LoginId);
         if (login != null) {
            login.UserId = userEntity.UserId;
         }
         await _dbContext.SaveChangesAsync();

         var userResponse = _mapper.Map<UserResponse>(userEntity);
         userResponse.UserRole = userRole.RoleID;

         return userResponse;
      }

      public async Task<UserResponse> UpdateAddress(UserAddressUpdateRequest request) {
         var user = await _dbContext.Users.FindAsync(request.UserID);
         if (user == null) return null;

         user.FullName = request.FullName;
         user.AddressLine = request.AddressLine;
         user.City = request.City;
         user.ZipCode = request.Postcode;
         
         _dbContext.Update(user);
         await _dbContext.SaveChangesAsync();

         return _mapper.Map<UserResponse>(user);
      }
      public async Task<HttpStatusCode> UpdatePassword(PasswordUpdateRequest request) {
         if(request.NewPassword != request.ConfirmPassword) return HttpStatusCode.BadRequest;

         var user = await _dbContext.Users.FindAsync(request.UserId);
         if (user == null) return HttpStatusCode.NotFound;

         var login = await _dbContext.Logins.FindAsync(user.LoginId);
         if (login == null) return HttpStatusCode.NotFound;

         var salt = PasswordHelper.GeneratePasswordSalt();
         login.PasswordSalt = salt;
         login.PasswordHash = PasswordHelper.GeneratePasswordHash(salt, request.NewPassword);
         _dbContext.Update(login);
         await _dbContext.SaveChangesAsync();

         return HttpStatusCode.OK;
      }
      public async Task<PaymentInfoResponse> UpdatePayment(UserPaymentInfoRequest request) {
         var card = await _dbContext.Cards
            .Where(c => c.UserId == request.UserId)
            .FirstAsync();
         if (card == null) return null;

         card = _mapper.Map<CardInfo>(request);
         await _dbContext.SaveChangesAsync();

         return _mapper.Map<PaymentInfoResponse>(card);
      }
   }
}
