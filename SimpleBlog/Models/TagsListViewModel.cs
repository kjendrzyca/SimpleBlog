using System.Collections.Generic;
using SimpleBlog.Core.Entities;

namespace SimpleBlog.Models
{
    public class TagsListViewModel
    {
        public IList<Tag> Tags { get; set; }
    }
}