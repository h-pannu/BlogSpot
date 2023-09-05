using System.ComponentModel.DataAnnotations;

namespace Blogger.WebAPI.DTO.Category
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;

    }
}
