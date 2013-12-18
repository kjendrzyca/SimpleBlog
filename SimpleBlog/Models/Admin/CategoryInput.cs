using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Models.Admin
{
    public class CategoryInput
    {
        [Required]
        public int CategoryId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required]
        public string UrlSlug { get; set; }
    }
}