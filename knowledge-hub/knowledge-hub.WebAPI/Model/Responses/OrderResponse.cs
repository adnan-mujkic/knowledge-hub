namespace knowledge_hub.WebAPI.Model.Responses
{
   public class OrderResponse
   {
      public int OrderId { get; set; }
      public string OrderNumber { get; set; }
      public string UserFullName { get; set; }
      public int BookId { get; set; }
      public DateTime OrderDate { get; set; }
      public DateTime ShippingDate { get; set; }
      public int OrderStatus { get; set; }
      public string Comment { get; set; }
      public string AddressLine { get; set; }
      public string City { get; set; }
   }
}
