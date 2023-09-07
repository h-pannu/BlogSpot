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

        #region Category
        public const string GetAllCategories = "/api/Category/GetAllCategories";
        public const string DeleteCategory = "/api/Category/DeleteCategory";
        public const string AddCategory = "/api/Category/AddCategory";
        public const string UpdateCategory = "/api/Category/UpdateCategory";
        #endregion

        #region Blog
        public const string GetAllBlogs = "/api/Blog/GetAllBlogs";
        public const string DeleteBlog = "/api/Blog/DeleteBlog";
        public const string AddBlog = "/api/Blog/AddBlog";
        public const string UpdateBlog = "/api/Blog/UpdateBlog";
        #endregion
    }
}
