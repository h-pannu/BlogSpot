using Blogger.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.SharedUI.ServiceInterfaces
{
    public interface IBlogService
    {
        Task<List<Blog>> GetAllBlogs();
        Task<MethodResult> SaveBlogAsync(Blog blog);
        Task<MethodResult> DeleteBlog(int Id);
    }
}
