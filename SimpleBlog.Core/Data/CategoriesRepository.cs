using System.Collections.Generic;
using System.Linq;
using SimpleBlog.Core.Model;

namespace SimpleBlog.Core.Data
{
    public class CategoriesRepository : Repository<Category>, ICategoriesRepository
    {
        public CategoriesRepository(IDbContextFactory dbContextFactory) 
            : base(dbContextFactory)
        {
        }

        public Category GetCategory(string categorySlug)
        {
            return DbSet.FirstOrDefault(t => t.UrlSlug.Equals(categorySlug));
        }

        public IList<Category> GetAllCategories()
        {
            return DbSet.OrderBy(c => c.Name).ToList();
        }
    }
}
