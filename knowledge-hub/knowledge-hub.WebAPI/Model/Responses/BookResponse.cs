namespace knowledge_hub.WebAPI.Model.Responses
{
   public class BookResponse
   {
      public int BookId { get; set; }
      public string Name { get; set; }
      public string Author { get; set; }
      public string Description { get; set; }
      public string ImagePath { get; set; }
      public double PricePhysical { get; set; }
      public double PriceDigital { get; set; }
      public double Score { get; set; }
      public string Language { get; set; }
      public string Category { get; set; }
   }
}
