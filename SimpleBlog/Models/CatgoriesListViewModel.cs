using System.Collections.Generic;
using SimpleBlog.Core.Entities;

namespace SimpleBlog.Models
{
    public class CatgoriesListViewModel
    {
        public IList<Category> Categories { get; set; }
    }
}