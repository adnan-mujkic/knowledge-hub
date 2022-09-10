using knowledge_hub.WebAPI.Intefraces;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace knowledge_hub.WebAPI.Services
{
   public class AuthService : AuthenticationHandler<AuthenticationSchemeOptions>
   {
      private readonly IUserService _userService;

      public AuthService(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUserService userService)
            : base(options, logger, encoder, clock) {
         _userService = userService;
      }

      protected override async Task<AuthenticateResult> HandleAuthenticateAsync() {
         if (!Request.Headers.ContainsKey("Authorization"))
            return AuthenticateResult.Fail("Missing auth header");

         UserDataResponse user = null;
         try
         {
            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var base64String = Convert.FromBase64String(authHeader.Parameter);
            var userNamePass = UTF8Encoding.UTF8.GetString(base64String);
            var credentials = userNamePass.Split(':');
            var request = new AuthenticationRequest
            {
               Email = credentials[0],
               Password = credentials[1]
            };
            user = await _userService.Login(request);
         }
         catch
         {
            return AuthenticateResult.Fail("Invalid auth header");
         }

         if (user == null)
            return AuthenticateResult.Fail("Invalid email or password");

         var claims = new List<Claim>
         {
            new Claim(ClaimTypes.Email, user.authData.email),
            new Claim(ClaimTypes.Name, user.userData.Username),
         };

         claims.Add(new Claim(ClaimTypes.Role, user.userData.UserRole));
         var identity = new ClaimsIdentity(claims, Scheme.Name);
         var principal = new ClaimsPrincipal(identity);
         var ticket = new AuthenticationTicket(principal, Scheme.Name);

         return AuthenticateResult.Success(ticket);
      }
   }
}
