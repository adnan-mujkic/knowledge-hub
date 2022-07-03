using System.Collections.Generic;

namespace knowledge_hub.Models.Model.Requests
{
   public class OrderInsertRequest
   {
      public List<int> Books { get; set; }
      public List<bool> Digital { get; set; }
      public int UserId { get; set; }
      public string UserFullName { get; set; }
      public string OrderDate { get; set; }
      public string AddressLine { get; set; }
      public int CityId { get; set; }
      public string PaymentIntent { get; set; }
   }
}
