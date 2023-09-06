using Blogger.Shared.Models;
using Blogger.SharedUI.ServiceInterfaces;
using Blogger.WebAssembly.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blogger.WebAssembly.Services
{
    public class AppService : IAppService
    {
        public async Task<MainResponse> AuthenticateUser(LoginModel loginModel)
        {
            var returnResponse = new MainResponse();
            using (var client = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.AuthenticateUser}";

                var serializedStr = JsonConvert.SerializeObject(loginModel);

                var response = await client.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    string contentStr = await response.Content.ReadAsStringAsync();
                    returnResponse = JsonConvert.DeserializeObject<MainResponse>(contentStr);
                }
            }
            return returnResponse;
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> RegisterUser(RegistrationModel registerUser)
        {
            string errorMessage = string.Empty;
            bool isSuccess = false;
            using (var client = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.RegisterUser}";

                var serializedStr = JsonConvert.SerializeObject(registerUser);
                var response = await client.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    isSuccess = true;
                }
                else
                {
                    errorMessage = await response.Content.ReadAsStringAsync();
                }
            }
            return (isSuccess, errorMessage);
        }

        public async Task<string> SetSecureStorage(string userBasicInfoStr)
        {
            //await SecureStorage.SetAsync(nameof(Setting.UserBasicDetail), userBasicInfoStr);
            return "Set Secure Storage";
        }

        public async Task<string> GetSecureStorage()
        {
            //string userDetailsStr = await SecureStorage.GetAsync(nameof(Setting.UserBasicDetail));
            string userDetailsStr = "";
            return userDetailsStr;
        }

        public void DeleteSecureStorage()
        {
            //SecureStorage.RemoveAll();
            Setting.UserBasicDetail = null;
        }

        public async Task<bool> RefreshToken()
        {
            bool isTokenRefreshed = await SharedMethods.RefreshToken();
           
            return isTokenRefreshed;
        }

        public async Task<(string Avatar, string ImageBase)> DisplayAction(string _userAvatar, string _imageBase64Data)
        {
            string result = string.Empty;
            //string response = await App.Current.MainPage.DisplayActionSheet("Select Option", "OK", null, "Take Photo", "Add Photo");
            string response = "";

            if (response == "Take Photo")
            {
                //if (MediaPicker.Default.IsCaptureSupported)
                //{
                //    var photo = await MediaPicker.Default.CapturePhotoAsync();
                //    if (photo != null)
                //    {
                //        byte[] imageBytes;
                //        var newFile = System.IO.Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                //        var stream = await photo.OpenReadAsync();

                //        using (MemoryStream ms = new MemoryStream())
                //        {
                //            stream.CopyTo(ms);
                //            imageBytes = ms.ToArray();
                //        }
                //        _imageBase64Data = Convert.ToBase64String(imageBytes);
                //        _userAvatar = string.Format("data:image/png;base64,{0}", _imageBase64Data);
                //        result= _userAvatar;
                //        //this.StateHasChanged();
                //    }
                //}
            }
            else if (response == "Add Photo")
            {
                //var photo = await MediaPicker.Default.PickPhotoAsync();
                //if (photo != null)
                //{
                //    byte[] imageBytes;
                //    var newFile = System.IO.Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                //    var stream = await photo.OpenReadAsync();

                //    using (MemoryStream ms = new MemoryStream())
                //    {
                //        stream.CopyTo(ms);
                //        imageBytes = ms.ToArray();
                //    }
                //    _imageBase64Data = Convert.ToBase64String(imageBytes);
                //    _userAvatar = string.Format("data:image/png;base64,{0}", _imageBase64Data);
                //    result = _userAvatar;
                //    //this.StateHasChanged();
                //}
            }
            return (_userAvatar,_imageBase64Data);
        }

    }
}
