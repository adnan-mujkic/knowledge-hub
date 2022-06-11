namespace knowledge_hub.WebAPI.Database
{
   public class BookUserWishlist
   {
      public int BookUserWishlistId { get; set; }
      public int BookId { get; set; }
      public Book Book { get; set; }
      public int UserId { get; set; }
      public User User { get; set; }
   }
}
