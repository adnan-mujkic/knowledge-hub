using System.ComponentModel.DataAnnotations;

namespace knowledge_hub.WebAPI.Database
{
   public class Login
   {
      [Key]
      public int LoginId { get; set; }

      [Required]
      public string Email { get; set; }

      [Required]
      public string PasswordHash { get; set; }

      [Required]
      public string PasswordSalt { get; set; }
   }
}
