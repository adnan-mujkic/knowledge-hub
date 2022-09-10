using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Helpers
{
   public static class Validation
   {
      public static bool IsEmail(string text) {
         string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";
         return Regex.IsMatch(text, emailPattern);
      }
      public static bool IsPassword(string text) {
         Regex hasNumber = new Regex(@"[0-9]+");
         Regex hasUpperChar = new Regex(@"[A-Z]+");
         Regex hasMinimum8Chars = new Regex(@".{8,}");

         return hasNumber.IsMatch(text) && hasUpperChar.IsMatch(text) && hasMinimum8Chars.IsMatch(text);
      }
   }
}
