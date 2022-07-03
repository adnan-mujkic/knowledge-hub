namespace knowledge_hub.WebAPI.Model.Requests
{
   public class BookInsertRequest
   {
      public string Name { get; set; }
      public string Author { get; set; }
      public string Description { get; set; }
      public byte[] ImagePath { get; set; }
      public byte[] BookFile { get; set; }
      public double PricePhysical { get; set; }
      public double PriceDigital { get; set; }
      public double Score { get; set; }
      public int LanguageId { get; set; }
      public int CategoryId { get; set; }
   }
}
