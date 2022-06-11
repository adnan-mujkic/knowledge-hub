using System.Security.Cryptography;
using System.Text;

namespace knowledge_hub.WebAPI.Helpers
{
   public class PasswordHelper
   {
      public static string GeneratePasswordSalt() {
         var saltBuffer = RandomNumberGenerator.GetBytes(16);
         return Convert.ToBase64String(saltBuffer);
      }
      public static string GeneratePasswordHash(string salt, string password) {
         byte[] srcSalt = Convert.FromBase64String(salt);
         byte[] passwordBytes = Encoding.Unicode.GetBytes(password);
         byte[] finalHash = new byte[srcSalt.Length + passwordBytes.Length];

         Buffer.BlockCopy(srcSalt, 0, finalHash, 0, srcSalt.Length);
         Buffer.BlockCopy(passwordBytes, 0, finalHash, srcSalt.Length, passwordBytes.Length);
         HashAlgorithm algo = HashAlgorithm.Create("SHA1");
         byte[] aloBytes = algo.ComputeHash(finalHash);

         return Convert.ToBase64String(aloBytes);
      }
   }
}
