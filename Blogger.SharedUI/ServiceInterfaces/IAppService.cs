using Blogger.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.SharedUI.ServiceInterfaces
{
    public interface IAppService
    {
        public Task<MainResponse> AuthenticateUser(LoginModel loginModel);
        Task<Boolean> RefreshToken();
        Task<(bool IsSuccess, string ErrorMessage)> RegisterUser(RegistrationModel registrationModel);
        public Task<string> SetSecureStorage(string userBasicInfoStr);
        public Task<string> GetSecureStorage();
        public void DeleteSecureStorage();
        Task<(string Avatar, string ImageBase)> DisplayAction(string _userAvatar, string _imageBase64Data);
    }
}
