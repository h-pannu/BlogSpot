using Blogger.Shared.Models;
using Blogger.SharedUI.Extensions;
using Blogger.SharedUI.ServiceInterfaces;
using Blogger.WebAssembly.Common;
using Newtonsoft.Json;
using System.Text;

namespace Blogger.WebAssembly.Services
{
    public class BlogService : IBlogService
    {


        public async Task<List<Blog>> GetAllBlogs()
        {
            var returnResponse = new List<Blog>();
            using (var client = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.GetAllBlogs}";

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Setting.UserBasicDetail?.AccessToken}");
                var response = await client.GetAsync(url);

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    bool isTokenRefreshed = await SharedMethods.RefreshToken();
                    if (isTokenRefreshed) return await GetAllBlogs();
                }
                else
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string contentStr = await response.Content.ReadAsStringAsync();
                        var mainResponse = JsonConvert.DeserializeObject<MainResponse>(contentStr);
                        if (mainResponse.IsSuccess)
                        {
                            returnResponse = JsonConvert.DeserializeObject<List<Blog>>(mainResponse.Content.ToString());
                        }
                    }
                }

            }
            return returnResponse;
        }

        public async Task<MethodResult> SaveBlogAsync(Blog blog)
        {
            blog.Slug = blog.Slug.Slugify();
            try
            {
                using (var client = new HttpClient())
                {
                    var url = string.Empty;
                    var response = new HttpResponseMessage();
                    var serializedStr = JsonConvert.SerializeObject(blog);
                    //serializedStr = "'{\r\n  \"id\": 0,\r\n  \"title\": \"string\",\r\n  \"slug\": \"string\",\r\n  \"categoryId\": 0,\r\n  \"userId\": 0,\r\n  \"introduction\": \"string\",\r\n  \"content\": \"string\",\r\n  \"createdOn\": \"2023-09-06T23:14:28.853Z\",\r\n  \"isPublished\": true,\r\n  \"publishedOn\": \"2023-09-06T23:14:28.853Z\",\r\n  \"modifiedOn\": \"2023-09-06T23:14:28.853Z\",\r\n  \"category\": {\r\n    \"id\": 0,\r\n    \"name\": \"string\",\r\n    \"slug\": \"string\"\r\n  }\r\n}'";
                    if (blog.Id > 0)
                    {
                        //update category
                        url = $"{Setting.BaseUrl}{APIs.UpdateBlog}";
                        response = await client.PutAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));
                    }
                    else
                    {
                        //add category
                        url = $"{Setting.BaseUrl}{APIs.AddBlog}";
                        response = await client.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));
                    }

                    //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Setting.UserBasicDetail?.AccessToken}");



                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        bool isTokenRefreshed = await SharedMethods.RefreshToken();
                        if (isTokenRefreshed) return await SaveBlogAsync(blog);
                    }
                    else
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string contentStr = await response.Content.ReadAsStringAsync();
                            var mainResponse = JsonConvert.DeserializeObject<MainResponse>(contentStr);

                            //if (mainResponse.IsSuccess)
                            //{
                            //    returnResponse = JsonConvert.DeserializeObject<string>(mainResponse.Content.ToString());
                            //}
                        }
                    }
                    return MethodResult.Success();
                }
            }
            catch (Exception ex)
            {
                // log exception
                return MethodResult.Failure(ex.Message);
            }
            //return returnResponse;
        }

        public async Task<MethodResult> DeleteBlog(int Id)
        {
            using (var client = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.DeleteBlog}/{Id}";

                //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Setting.UserBasicDetail?.AccessToken}");
                var response = await client.DeleteAsync(url);

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    bool isTokenRefreshed = await SharedMethods.RefreshToken();
                    if (isTokenRefreshed) return await DeleteBlog(Id);
                }
                else
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string contentStr = await response.Content.ReadAsStringAsync();
                        var mainResponse = JsonConvert.DeserializeObject<MainResponse>(contentStr);
                        //if (mainResponse.IsSuccess)
                        //{
                        //    returnResponse = JsonConvert.DeserializeObject<List<String>>(mainResponse.Content.ToString());
                        //}
                    }
                }
                return MethodResult.Success();
            }
        }
    }
}
