using Blogger.Shared.Models;
using Blogger.SharedUI.ServiceInterfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blogger.MAUI.Services
{
    public class AppService : IAppService
    {
        private string _baseUrl = "https://ckhp49fh-7231.usw3.devtunnels.ms";
        public async Task<string> AuthenticateUser(LoginModel loginModel)
        {
            string returnStr = string.Empty;
            using(var httpClient = new HttpClient())
            {
                var url = $"{_baseUrl}{APIs.AuthenticateUser}";

                var serializedStr = JsonConvert.SerializeObject(loginModel) ;
                var response = await httpClient.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    returnStr = await response.Content.ReadAsStringAsync();
                }
            }
            return returnStr;
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> RegisterUser(RegistrationModel registrationModel)
        {
            string errorMessage = string.Empty;
            bool isSuccess = false;
            using (var httpClient = new HttpClient())
            {
                var url = $"{_baseUrl}{APIs.RegisterUser}";

                var serializedStr = JsonConvert.SerializeObject(registrationModel);
                var response = await httpClient.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    isSuccess = true;
                }
                else
                {
                    errorMessage=await response.Content.ReadAsStringAsync();
                }
            }
            return (isSuccess, errorMessage);
        }
    }
}
