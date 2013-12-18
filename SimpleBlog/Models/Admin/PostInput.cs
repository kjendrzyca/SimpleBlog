using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SimpleBlog.Models.Admin
{
    public class PostInput
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Meta { get; set; }

        [Required]
        public string UrlSlug { get; set; }

        [Required]
        public bool Published { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }

        public DateTime? Modified { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public List<int> TagsIds { get; set; }

        public IEnumerable<SelectListItem> AvailableCategories { get; set; }

        public IEnumerable<SelectListItem> AvailableTags { get; set; }
    }
}