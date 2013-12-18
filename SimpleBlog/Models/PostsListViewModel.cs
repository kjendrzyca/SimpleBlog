using System.Collections.Generic;
using SimpleBlog.Core.Model;

namespace SimpleBlog.Models
{
    public class PostsListViewModel
    {
        public IList<Post> Posts { get; set; }
        public Category Category { get; set; }
        public Tag Tag { get; set; }
        public int TotalPosts { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public string Title { get; set; }
    }
}