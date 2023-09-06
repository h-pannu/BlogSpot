using AutoMapper;
using Blogger.Shared.Models;
using Blogger.WebAPI.Data;
using Blogger.WebAPI.DBContext;
using Blogger.WebAPI.DTO.Category;
using Blogger.WebAPI.DTO.User;
using Microsoft.EntityFrameworkCore;

namespace Blogger.WebAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BloggerDBContext _context;
        private readonly IMapper _mapper;

        public CategoryService(BloggerDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MainResponse> AddCategory(CategoryDTO categoryDTO)
        {
            var response = new MainResponse();
            try
            {
                if (_context.Categories.Any(f => f.Name.ToLower() == categoryDTO.Name.ToLower()))
                {
                    response.ErrorMessage = "Category name already exist";
                    response.IsSuccess = false;
                }
                else
                {
                    Category category = _mapper.Map<Category>(categoryDTO);
                    await _context.AddAsync(category);
                    await _context.SaveChangesAsync();

                    response.IsSuccess = true;
                    response.Content = "Category Added";
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<MainResponse> DeleteCategory(DeleteCategoryDTO categoryDTO)
        {
            var response = new MainResponse();
            try
            {
                if (categoryDTO.CategoryID < 0)
                {
                    response.ErrorMessage = "Please pass Category ID";
                    return response;
                }

                var existingCategory = _context.Categories.Where(f => f.Id == categoryDTO.CategoryID).FirstOrDefault();

                if (existingCategory != null)
                {
                    _context.Remove(existingCategory);
                    await _context.SaveChangesAsync();

                    response.IsSuccess = true;
                    response.Content = "Category Deleted";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Content = "Category not found with specify category ID";
                }

            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<MainResponse> GetAllCategories()
        {
            var response = new MainResponse();
            try
            {
                response.Content = await _context.Categories.ToListAsync();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<MainResponse> GetCategoryByCategoryID(int categoryID)
        {
            var response = new MainResponse();
            try
            {
                response.Content = await _context.Categories.Where(f => f.Id == categoryID).FirstOrDefaultAsync();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<MainResponse> UpdateCategory(CategoryDTO categoryDTO)
        {
            var response = new MainResponse();
            try
            {
                if (categoryDTO.Id < 0)
                {
                    response.ErrorMessage = "Please pass category ID";
                    return response;
                }

                var existingCategory = _context.Categories.Where(f => f.Id == categoryDTO.Id).FirstOrDefault();

                if (existingCategory != null)
                {
                    //existingCategory = _mapper.Map<Category>(categoryDTO);
                    existingCategory.Name = categoryDTO.Name;
                    existingCategory.Slug = categoryDTO.Slug;
                    await _context.SaveChangesAsync();

                    response.IsSuccess = true;
                    response.Content = "Record Updated";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Content = "Category not found with specify category ID";
                }

            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }
    }
}
