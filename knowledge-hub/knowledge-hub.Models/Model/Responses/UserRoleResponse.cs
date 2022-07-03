namespace knowledge_hub.Models.Model.Responses
{
   public class UserRoleResponse
   {
      public int UserRoleID { get; set; }
      public int UserID { get; set; }
      public int RoleID { get; set; }
      public RoleResponse Role { get; set; }
   }
}
