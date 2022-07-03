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
      public static string Email = "admin@knowledgehubtest.com";
      public static string Password = "admin";

      public async static Task<UserDataResponse> Authenticate(AuthenticationRequest request) {
         string url = $"{Properties.Settings.Default.ApiUrl}/User/Login";
         try
         {
            return await url.PostJsonAsync(request).ReceiveJson<UserDataResponse>();
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
   }
}
