using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Shared.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        [Required, MaxLength(100)]
        public string Slug { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        [Required, MaxLength(250)]
        public string Introduction { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
    }
}
