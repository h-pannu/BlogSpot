using Azure;
using Blogger.WebAPI.DTO.Category;
using Blogger.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
                _categoryService = categoryService;
        }

        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            try
            {
                var response = await _categoryService.GetAllCategory();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCategoryByCategoryID/{CategoryID}")]
        public async Task<IActionResult> GetCategoryByCategoryID(int CategoryID)
        {
            try
            {
                var response = await _categoryService.GetCategoryByCategoryID(CategoryID);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDTO categoryInfo)
        {
            try
            {
                var response = await _categoryService.AddCategory(categoryInfo);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryDTO categoryInfo)
        {
            try
            {
                var response = await _categoryService.UpdateCategory(categoryInfo);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryDTO categoryInfo)
        {
            try
            {
                var response = await _categoryService.DeleteCategory(categoryInfo);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
