using System.ComponentModel.DataAnnotations;

namespace knowledge_hub.WebAPI.Database
{
   public class UserRoles
   {
      [Key]
      public int UserRoleID { get; set; }

      [Required]
      public int UserID { get; set; }
      public virtual User User { get; set; }

      [Required]
      public int RoleID { get; set; }
      public virtual Role Role { get; set; }
   }
}
