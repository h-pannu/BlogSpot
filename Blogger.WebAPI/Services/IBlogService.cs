using Blogger.Shared.DTO;
using Blogger.Shared.Models;
using Blogger.WebAPI.DTO.Category;

namespace Blogger.WebAPI.Services
{
    public interface IBlogService
    {
        Task<MainResponse> AddBlog(BlogDTO BlogDTO);
        Task<MainResponse> UpdateBlog(BlogDTO BlogDTO);
        Task<MainResponse> DeleteBlog(int id);
        Task<MainResponse> GetAllBlogs();
        Task<MainResponse> GetBlogByBlogID(int BlogID);
    }
}
