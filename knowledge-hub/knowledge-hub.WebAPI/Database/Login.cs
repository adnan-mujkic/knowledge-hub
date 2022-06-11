using System.ComponentModel.DataAnnotations;

namespace knowledge_hub.WebAPI.Database
{
   public class Login
   {
      [Key]
      public int LoginId { get; set; }
      public int? UserId { get; set; }
      public User User { get; set; }
      public string Email { get; set; }
      public string PasswordHash { get; set; }
      public string PasswordSalt { get; set; }
   }
}
