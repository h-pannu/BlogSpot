using Blogger.Shared.DTO;
using Blogger.Shared.Models;
using Blogger.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [HttpGet("GetAllBlogs")]
        public async Task<IActionResult> GetAllBlogs()
        {
            try
            {
                var response = await _blogService.GetAllBlogs();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetBlogByBlogID/{BlogID}")]
        public async Task<IActionResult> GetBlogByBlogID(int BlogID)
        {
            try
            {
                var response = await _blogService.GetBlogByBlogID(BlogID);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddBlog")]
        public async Task<IActionResult> AddBlog([FromBody] BlogDTO BlogInfo)
        {
            try
            {
                var response = await _blogService.AddBlog(BlogInfo);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("UpdateBlog")]
        public async Task<IActionResult> UpdateBlog([FromBody] BlogDTO BlogInfo)
        {
            try
            {
                var response = await _blogService.UpdateBlog(BlogInfo);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("DeleteBlog/{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            try
            {
                var response = await _blogService.DeleteBlog(id);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
