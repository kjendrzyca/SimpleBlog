using System.Collections.Generic;
using SimpleBlog.Core.Model;

namespace SimpleBlog.Core.Data
{
    public interface ICategoriesRepository
    {
        Category GetCategory(string categorySlug);
        IList<Category> GetAllCategories();
    }
}