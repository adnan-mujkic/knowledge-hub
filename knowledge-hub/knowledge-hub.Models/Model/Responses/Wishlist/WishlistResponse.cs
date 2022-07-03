namespace knowledge_hub.Models.Model.Responses
{
   public class WishlistResponse
   {
      public int BookUserWishlistId { get; set; }
      public int BookId { get; set; }
      public BookResponse Book { get; set; }
      public int UserId { get; set; }
      public UserResponse User { get; set; }
   }
}
