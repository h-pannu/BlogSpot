namespace Blogger.WebAPI.DTO.Category
{
    public class UpdateCategoryDTO
    {
        public int CategoryID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Address { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
    }
}
