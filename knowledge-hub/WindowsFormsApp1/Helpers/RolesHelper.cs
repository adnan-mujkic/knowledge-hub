using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knowledge_hub.Desktop.Helpers
{
   public class RolesHelper
   {
      public static int RoleIdFromString(string role) {
         switch (role)
         {
            case "Admin":
               return 1;
            case "User":
               return 2;
            case "Delivery":
               return 3;
            default:
               return 2;
         }
      }
   }
}
