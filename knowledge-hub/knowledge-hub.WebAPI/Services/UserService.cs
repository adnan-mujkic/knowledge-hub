using AutoMapper;
using knowledge_hub.WebAPI.Database;
using knowledge_hub.WebAPI.Intefraces;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using Microsoft.EntityFrameworkCore;
using knowledge_hub.WebAPI.Helpers;
using System.Net;

namespace knowledge_hub.WebAPI.Services
{
   public class UserService : CRUDService<UserResponse, UserInsertRequest, UserInsertRequest, User>, IUserService
   {
      private readonly databaseContext _dbContext;
      private readonly IMapper _mapper;
      public UserService(databaseContext context, IMapper mapper): base(context, mapper) {
         _dbContext = context;
         _mapper = mapper;
      }

      public override async Task<List<UserResponse>> Get() {
         List<User> users = new List<User>();
         List<Role> roles = await _dbContext.Roles.ToListAsync();
         List<UserRoles> userRoles = new List<UserRoles>();
         users = await _dbContext.Users
               .ToListAsync();
         userRoles = await _dbContext.UserRoles
            .ToListAsync();

         var response = new List<UserResponse>();
         foreach (var user in users)
         {
            var res = _mapper.Map<UserResponse>(user);
            var userRole = userRoles.Where(x => x.UserID == user.UserId).FirstOrDefault();
            res.UserRole = roles
               .Where(x => x.RoleID == userRole.RoleID)
               .FirstOrDefault().Name;
            res.Email = (await _dbContext.Logins
               .Where(x => x.LoginId == user.LoginId)
               .FirstOrDefaultAsync()).Email;
            response.Add(res);
         }

         return response;
      }

      public async Task<List<UserResponse>> SearchUser(string search) {
         List<User> users = new List<User>();
         List<Role> roles = await _dbContext.Roles.ToListAsync();
         List<UserRoles> userRoles = new List<UserRoles>();
         users = await _dbContext.Users
            .Where(x => x.Username.Contains(search))
            .ToListAsync();
         userRoles = await _dbContext.UserRoles
            .ToListAsync();

         var response = new List<UserResponse>();
         foreach (var user in users)
         {
            var res = _mapper.Map<UserResponse>(user);
            var userRole = userRoles.Where(x => x.UserID == user.UserId).FirstOrDefault();
            res.UserRole = roles
               .Where(x => x.RoleID == userRole.RoleID)
               .FirstOrDefault().Name;
            res.Email = (await _dbContext.Logins
               .Where(x => x.LoginId == user.LoginId)
               .FirstOrDefaultAsync()).Email;
            response.Add(res);
         }

         return response;
      }

      public override Task<UserResponse> Insert(UserInsertRequest request) {
         return base.Insert(request);
      }
      public override Task<UserResponse> Update(int ID, UserInsertRequest request) {
         return base.Update(ID, request);
      }
      public async Task<UserDataResponse> Login(AuthenticationRequest request) {
         var login = await _dbContext.Logins
            .FirstOrDefaultAsync(x => x.Email == request.Email);
         if (login == null) return null;

         var user = await _dbContext.Users
            .Where(x => x.LoginId == login.LoginId)
            .FirstOrDefaultAsync();

         var userRole = await _dbContext.UserRoles
            .Where(x => x.UserID == user.UserId)
            .Include(x => x.Role)
            .FirstOrDefaultAsync();

         if(login != null && user != null && userRole != null)
         {
            var checkHash = PasswordHelper.GeneratePasswordHash(login.PasswordSalt, request.Password);
            if(checkHash == login.PasswordHash)
            {
               var addressData = await _dbContext.Addresses
                  .Where(x => x.UserId == user.UserId)
                  .Include(x => x.City)
                  .FirstOrDefaultAsync();
               var paymentData = await _dbContext.Cards.Where(x => x.UserId == user.UserId).FirstOrDefaultAsync();
               var wishlist = await _dbContext.Whishlist
                  .Where(x => x.UserId == user.UserId)
                  .Include(x => x.Book)
                  .ThenInclude(x => x.category)
                  .Include(x => x.Book)
                  .ThenInclude(x => x.language)
                  .ToListAsync();

               var userData = new UserDataResponse();
               userData.authData = new LoginData();
               userData.authData.email = request.Email;
               userData.authData.password = request.Password;

               user.UserRole = userRole;
               userData.userData = _mapper.Map<UserResponse>(user);
               userData.addressData = _mapper.Map<AddressResponse>(addressData);
               userData.paymentData = _mapper.Map<PaymentInfoResponse>(paymentData);
               userData.wishlist = new List<BookResponse>();
               foreach (var item in wishlist)
               {
                  userData.wishlist.Add(_mapper.Map<BookResponse>(item.Book));
               }

               return userData;
            }
         }

         return new UserDataResponse();
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
         await _dbContext.Users.AddAsync(userEntity);
         await _dbContext.SaveChangesAsync();

         var userRole = new UserRoles()
         {
            UserID = userEntity.UserId,
            RoleID = 2,
         };
         await _dbContext.UserRoles.AddAsync(userRole);

         var login = await _dbContext.Logins.SingleOrDefaultAsync(l => l.LoginId == request.LoginId);
         await _dbContext.SaveChangesAsync();

         var userResponse = _mapper.Map<UserResponse>(userEntity);
         userResponse.UserRole = (await _dbContext.Roles.FindAsync(userRole.RoleID)).Name;

         return userResponse;
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
            .Where(c => c.UserId == request.UserId).FirstOrDefaultAsync();

         if (card == null)
         {
            card = _mapper.Map<CardInfo>(request);
           await _dbContext.Cards.AddAsync(card);
         }
         else
         {
            card = _mapper.Map<CardInfo>(request);
         }

         await _dbContext.SaveChangesAsync();
         return _mapper.Map<PaymentInfoResponse>(card);
      }
      public async Task<AddressResponse> UpdateAddress(UserAddressUpdateRequest request) {
         var address = await _dbContext.Addresses.Where(a => a.UserId == request.UserId).FirstOrDefaultAsync();
         if (address == null) {
            address = _mapper.Map<Address>(request);
            address.CityId = (await _dbContext.Cities.Where(x => x.Name == request.City).FirstOrDefaultAsync()).CityId;
            await _dbContext.Addresses.AddAsync(address);
         }
         else
         {
            address = _mapper.Map<Address>(request);
         }
         await _dbContext.SaveChangesAsync();

         return _mapper.Map<AddressResponse>(address);
      }

      public override async Task<bool> Delete(int ID) {
         try
         {
            var user = await _dbContext.Users.FindAsync(ID);
            if (user == null) return false;

            var userRole = await _dbContext.UserRoles
               .Where(x => x.UserID == user.UserId)
               .FirstOrDefaultAsync();

            _dbContext.UserRoles.Remove(userRole);

            var login = await _dbContext.Logins.FindAsync(user.LoginId);
            _dbContext.Logins.Remove(login);

            _dbContext.Users.Remove(user);

            await _dbContext.SaveChangesAsync();
            return true;
         }
         catch (Exception e)
         {
            Console.Write(e.StackTrace);
            return false;
         }
      }

      public async Task<bool> UserUpdateInfo(UserResponse userInfo) {
         try
         {
            var roles = await _dbContext.Roles.ToListAsync();
            var userRole = await _dbContext.UserRoles
               .Where(x => x.UserID == userInfo.UserId)
               .Include(x => x.Role)
               .FirstOrDefaultAsync();
            if (userRole == null) return false;

            var user = await _dbContext.Users.FindAsync(userInfo.UserId);
            if (user == null) return false;

            var login = await _dbContext.Logins.FindAsync(user.LoginId);
            if (login == null) return false;

            if (userRole.Role.Name != userInfo.UserRole)
            {
               _dbContext.UserRoles.Remove(userRole);
               await _dbContext.AddAsync(new UserRoles
               {
                  UserID = user.UserId,
                  RoleID = roles
                     .Where(x => x.Name == userInfo.UserRole)
                     .FirstOrDefault().RoleID
               });
            }

            user.Username = userInfo.Username;
            user.Biography = userInfo.Biography;
            login.Email = userInfo.Email;

            await _dbContext.SaveChangesAsync();
            return true;
         }
         catch (Exception e)
         {
            Console.Write(e.StackTrace);
            return false;
         }
      }

      public async Task<UserDataResponse> GetDetailedUserInfo(int ID) {
         var user = await _dbContext.Users.FindAsync(ID);
         if (user == null) return null;

         var login = await _dbContext.Logins.FindAsync(user.LoginId);
         if (login == null) return null;

         var userRole = await _dbContext.UserRoles
            .Where(x => x.UserID == user.UserId)
            .Include(x => x.Role)
            .FirstOrDefaultAsync();

         var addressData = await _dbContext.Addresses
                  .Where(x => x.UserId == user.UserId)
                  .Include(x => x.City)
                  .FirstOrDefaultAsync();
         var paymentData = await _dbContext.Cards.Where(x => x.UserId == user.UserId).FirstOrDefaultAsync();
         var wishlist = await _dbContext.Whishlist
            .Where(x => x.UserId == user.UserId)
            .Include(x => x.Book)
            .ThenInclude(x => x.category)
            .Include(x => x.Book)
            .ThenInclude(x => x.language)
            .ToListAsync();

         var userData = new UserDataResponse();
         userData.authData = new LoginData();
         userData.authData.email = login.Email;
         userData.authData.password = "";

         user.UserRole = userRole;
         userData.userData = _mapper.Map<UserResponse>(user);
         userData.userData.Email = login.Email;
         userData.addressData = _mapper.Map<AddressResponse>(addressData);
         userData.paymentData = _mapper.Map<PaymentInfoResponse>(paymentData);
         userData.wishlist = new List<BookResponse>();
         foreach (var item in wishlist)
         {
            userData.wishlist.Add(_mapper.Map<BookResponse>(item.Book));
         }

         return userData;
      }
   }
}
