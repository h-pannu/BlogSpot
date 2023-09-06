using Blogger.Shared.Models;
using Blogger.SharedUI.Extensions;
using Blogger.SharedUI.ServiceInterfaces;
using Blogger.WebAssembly.Common;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Blogger.WebAssembly.Services
{
    public class CategoryService : ICategoryService
    {
        //public async Task<string> DeleteCategory(int Id)
        //{
        //    var returnResponse = new List<String>();
        //    using (var client = new HttpClient())
        //    {
        //        var url = $"{Setting.BaseUrl}{APIs.DeleteCategory}";

        //        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Setting.UserBasicDetail?.AccessToken}");
        //        var response = await client.GetAsync(url);

        //        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        //        {
        //            bool isTokenRefreshed = await SharedMethods.RefreshToken();
        //            if (isTokenRefreshed) return await DeleteCategory(Id);
        //        }
        //        else
        //        {
        //            if (response.IsSuccessStatusCode)
        //            {
        //                string contentStr = await response.Content.ReadAsStringAsync();
        //                var mainResponse = JsonConvert.DeserializeObject<MainResponse>(contentStr);
        //                if (mainResponse.IsSuccess)
        //                {
        //                    returnResponse = JsonConvert.DeserializeObject<List<String>>(mainResponse.Content.ToString());
        //                }
        //            }
        //        }

        //    }
        //    return returnResponse;
        //}

        public async Task<List<Category>> GetAllCategories()
        {
            var returnResponse = new List<Category>();
            using (var client = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.GetAllCategories}";

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Setting.UserBasicDetail?.AccessToken}");
                var response = await client.GetAsync(url);

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    bool isTokenRefreshed = await SharedMethods.RefreshToken();
                    if (isTokenRefreshed) return await GetAllCategories();
                }
                else
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string contentStr = await response.Content.ReadAsStringAsync();
                        var mainResponse = JsonConvert.DeserializeObject<MainResponse>(contentStr);
                        if (mainResponse.IsSuccess)
                        {
                            returnResponse = JsonConvert.DeserializeObject<List<Category>>(mainResponse.Content.ToString());
                        }
                    }
                }

            }
            return returnResponse;
        }

        public async Task<MethodResult> SaveCategoryAsync(Category category)
        {
            category.Slug = category.Slug.Slugify();

            string returnResponse = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    var url = string.Empty;
                    if (category.Id > 0)
                    {
                        //update category
                        url = $"{Setting.BaseUrl}{APIs.UpdateCategory}";
                    }
                    else
                    {
                        //add category
                        url = $"{Setting.BaseUrl}{APIs.AddCategory}";
                    }


                    var serializedStr = JsonConvert.SerializeObject(category);

                    //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Setting.UserBasicDetail?.AccessToken}");

                    var response = await client.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));

                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        bool isTokenRefreshed = await SharedMethods.RefreshToken();
                        if (isTokenRefreshed) return await SaveCategoryAsync(category);
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
    }
}
