using Blogger.Shared.Models;
using Blogger.WebAPI.DTO.Category;

namespace Blogger.WebAPI.Services
{
    public interface ICategoryService
    {
        Task<MainResponse> AddCategory(CategoryDTO CategoryDTO);
        Task<MainResponse> UpdateCategory(CategoryDTO CategoryDTO);
        Task<MainResponse> DeleteCategory(DeleteCategoryDTO CategoryDTO);
        Task<MainResponse> GetAllCategory();
        Task<MainResponse> GetCategoryByCategoryID(int CategoryID);
    }
}
