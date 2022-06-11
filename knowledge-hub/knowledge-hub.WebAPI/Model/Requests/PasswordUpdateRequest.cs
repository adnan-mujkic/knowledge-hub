namespace knowledge_hub.WebAPI.Model.Requests
{
   public class PasswordUpdateRequest
   {
      public int UserId { get; set; }
      public string OldPassword { get; set; }
      public string NewPassword { get; set; }
      public string ConfirmPassword { get; set; }
   }
}
