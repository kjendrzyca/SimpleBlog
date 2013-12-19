using System.Collections.Generic;
using SimpleBlog.Core.Entities;

namespace SimpleBlog.Models.Admin
{
    public class AdminTagsList
    {
        public IList<Tag> Tags { get; set; }
    }
}