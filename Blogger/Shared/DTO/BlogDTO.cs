using Blogger.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Shared.DTO
{
    public class BlogDTO
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string? Title { get; set; }
        [Required, MaxLength(100)]
        public string? Slug { get; set; }
        public int CategoryId { get; set; }
        [Required, MaxLength(250)]
        public string? Introduction { get; set; }
        public string? Content { get; set; }
        public bool IsPublished { get; set; }
    }
}
