using Flurl.Http;
using knowledge_hub.Models.Model.Requests;
using knowledge_hub.Models.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
   public class APIService
   {
      public static string Email;
      public static string Password;

      public async static Task<UserDataResponse> Authenticate(AuthenticationRequest request) {
         string url = $"{Properties.Settings.Default.ApiUrl}/User/Login";
         try
         {
            var result = await url.PostJsonAsync(request).ReceiveJson<UserDataResponse>();
            if(result != null)
            {
               Email = request.Email;
               Password = request.Password;
            }
            return result;
         }
         catch (Exception e)
         {
            MessageBox.Show("Error logging in");
            return null;
         }
      }
   
      public async static Task<T> GetFromUrlWithAuth<T>(string url) {
         var formattedUrl = $"{Properties.Settings.Default.ApiUrl}/{url}";
         return await formattedUrl
            .WithHeader("Authorization", $"Basic {Email}:{Password}")
            .GetJsonAsync<T>();
      }
      public async static Task<bool> DeleteFromUrlWithAuth(string url, int ID) {
         var formattedUrl = $"{Properties.Settings.Default.ApiUrl}/{url}?ID={ID}";
         var result = await formattedUrl
            .WithHeader("Authorization", $"Basic {Email}:{Password}")
            .DeleteAsync();
         return result.StatusCode == 200;
      }

      public async static Task<T> PutFromUrlWithAuth<T>(string url, object data) {
         var formattedUrl = $"{Properties.Settings.Default.ApiUrl}/{url}";
         return await formattedUrl
            .WithHeader("Authorization", $"Basic {Email}:{Password}")
            .PutJsonAsync(data)
            .ReceiveJson<T>();
      }
      public async static Task<T> PostFromUrlWithAuth<T>(string url, object data) {
         var formattedUrl = $"{Properties.Settings.Default.ApiUrl}/{url}";
         return await formattedUrl
            .WithHeader("Authorization", $"Basic {Email}:{Password}")
            .PostJsonAsync(data)
            .ReceiveJson<T>();
      }
   }
}
