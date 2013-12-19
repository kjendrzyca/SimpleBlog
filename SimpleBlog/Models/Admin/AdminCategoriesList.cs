using System.Collections.Generic;
using SimpleBlog.Core.Entities;

namespace SimpleBlog.Models.Admin
{
    public class AdminCategoriesList
    {
        public IList<Category> Categories { get; set; }
    }
}