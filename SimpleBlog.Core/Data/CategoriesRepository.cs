using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimpleBlog.Core.Entities;

namespace SimpleBlog.Core.Data
{
    public class CategoriesRepository : ICategoriesRepository
    {
        protected readonly DbContext DbContext;
        protected readonly DbSet<Category> DbSet;

        public CategoriesRepository(IDbContextFactory dbContextFactory) 
        {
            DbContext = dbContextFactory.GetContext();
            DbSet = DbContext.Set<Category>();
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
