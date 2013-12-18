using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Models.Admin
{
    public class TagInput
    {
        [Required]
        public int TagId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required]
        public string UrlSlug { get; set; }
    }
}