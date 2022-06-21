namespace knowledge_hub.WebAPI.Model.Requests
{
   public class ReviewAddRequest
   {
      public int UserId { get; set; }
      public int BookId { get; set; }
      public double Rating { get; set; }
      public string CommentText { get; set; }
   }
}
