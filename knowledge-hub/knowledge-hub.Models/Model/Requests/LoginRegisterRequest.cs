using System.ComponentModel.DataAnnotations;

namespace knowledge_hub.WebAPI.Model.Requests
{
   public class LoginRegisterRequest
   {
      [Required]
      public string Email { get; set; }
      [Required]
      public string Password { get; set; }
      [Required]
      public string ConfirmPassword { get; set; }
   }
}
