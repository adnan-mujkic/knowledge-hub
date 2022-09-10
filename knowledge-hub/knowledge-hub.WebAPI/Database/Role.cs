using System.ComponentModel.DataAnnotations;

namespace knowledge_hub.WebAPI.Database
{
   public class Role
   {
      public int RoleID { get; set; }

      [Required]
      public string Name { get; set; }
      public virtual ICollection<UserRoles> UserRoles { get; set; }
   }
}
