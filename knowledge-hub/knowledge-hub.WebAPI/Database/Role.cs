namespace knowledge_hub.WebAPI.Database
{
   public class Role
   {
      public int RoleID { get; set; }
      public string Name { get; set; }
      public virtual ICollection<UserRoles> UserRoles { get; set; }
   }
}
