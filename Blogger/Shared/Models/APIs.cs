using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Shared.Models
{
    public class APIs
    {
        public const string AuthenticateUser = "/api/Users/AuthenticateUser";
        public const string RegisterUser = "/api/Users/RegisterUser";
        public const string RefreshToken = "/api/Users/RefreshToken";
        public const string GetAllCategories = "/api/Category/GetAllCategories";
        public const string DeleteCategory = "/api/Category/DeleteCategory";
        public const string AddCategory = "/api/Category/AddCategory";
        public const string UpdateCategory = "/api/Category/UpdateCategory";
    }
}
