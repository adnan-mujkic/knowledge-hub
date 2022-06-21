namespace knowledge_hub.WebAPI.Model.Responses
{
   public class ReviewResponse
   {
      public int ReviewId { get; set; }
      public int UserId { get; set; }
      public string Username { get; set; }
      public int BookId { get; set; }
      public string CommentText { get; set; }
      public double Rating { get; set; }
      public string Date { get; set; }
   }
}
