using AutoMapper;
using Blogger.Shared.DTO;
using Blogger.Shared.Models;
using Blogger.WebAPI.DBContext;
using Blogger.WebAPI.DTO.Category;
using Microsoft.EntityFrameworkCore;

namespace Blogger.WebAPI.Services
{
    public class BlogService : IBlogService
    {
        private readonly BloggerDBContext _context;
        private readonly IMapper _mapper;

        public BlogService(BloggerDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<MainResponse> AddBlog(BlogDTO BlogDTO)
        {
            var response = new MainResponse();
            try
            {
                if (_context.Blogs.Any(f => f.Title.ToLower() == BlogDTO.Title.ToLower()))
                {
                    response.ErrorMessage = "Blog title already exist";
                    response.IsSuccess = false;
                }
                else
                {
                    Blog blog = _mapper.Map<Blog>(BlogDTO);
                    await _context.AddAsync(blog);
                    await _context.SaveChangesAsync();

                    response.IsSuccess = true;
                    response.Content = "Blog Added";
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<MainResponse> DeleteBlog(int id)
        {
            var response = new MainResponse();
            try
            {
                if (id < 0)
                {
                    response.ErrorMessage = "Please pass Blog ID";
                    return response;
                }

                var existingBlog = _context.Blogs.Where(f => f.Id == id).FirstOrDefault();

                if (existingBlog != null)
                {
                    _context.Remove(existingBlog);
                    await _context.SaveChangesAsync();

                    response.IsSuccess = true;
                    response.Content = "Blog Deleted";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Content = "Blog not found with specify blog ID";
                }

            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<MainResponse> GetAllBlogs()
        {
            var response = new MainResponse();
            try
            {
                response.Content = await _context.Blogs.ToListAsync();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<MainResponse> GetBlogByBlogID(int BlogID)
        {
            var response = new MainResponse();
            try
            {
                response.Content = await _context.Blogs.Where(f => f.Id == BlogID).FirstOrDefaultAsync();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<MainResponse> UpdateBlog(BlogDTO BlogDTO)
        {
            var response = new MainResponse();
            try
            {
                if (BlogDTO.Id < 0)
                {
                    response.ErrorMessage = "Please pass blog ID";
                    return response;
                }

                var existingBlog = _context.Blogs.Where(f => f.Id == BlogDTO.Id).FirstOrDefault();

                if (existingBlog != null)
                {
                    //existingBlog = _mapper.Map<Blog>(BlogDTO);
                    existingBlog.Title = BlogDTO.Title;
                    existingBlog.Slug = BlogDTO.Slug;
                    existingBlog.CategoryId = BlogDTO.CategoryId;
                    //existingBlog.UserId = BlogDTO.UserId;
                    existingBlog.Introduction= BlogDTO.Introduction;
                    existingBlog.Content = BlogDTO.Content;
                    existingBlog.IsPublished = BlogDTO.IsPublished;
                    //existingBlog.PublishedOn = BlogDTO.PublishedOn;
                    //existingBlog.ModifiedOn = BlogDTO.ModifiedOn;
                    await _context.SaveChangesAsync();

                    response.IsSuccess = true;
                    response.Content = "Record Updated";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Content = "Blog not found with specify blog ID";
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
