using Blogger.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.SharedUI.ServiceInterfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<MethodResult> SaveCategoryAsync(Category category);
        Task<MethodResult> DeleteCategory(int Id);
    }
}
