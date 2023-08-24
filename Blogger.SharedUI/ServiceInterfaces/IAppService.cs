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
        public Task<string> AuthenticateUser(LoginModel loginModel);
        public Task<(bool IsSuccess, string ErrorMessage)> RegisterUser(RegistrationModel registrationModel);
        public Task<string> SetSecureStorage(UserBasicDetail userBasicDetail);
        public Task<string> GetSecureStorage();
        public void DeleteSecureStorage();
    }
}
