using System.Collections.Generic;
using SimpleBlog.Core.Entities;

namespace SimpleBlog.Models.Admin
{
    public class AdminPostsList
    {
        public IList<Post> Posts { get; set; }
    }
}