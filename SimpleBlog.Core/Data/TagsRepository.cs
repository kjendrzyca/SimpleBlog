using System.Collections.Generic;
using System.Linq;
using SimpleBlog.Core.Entities;

namespace SimpleBlog.Core.Data
{
    public class TagsRepository : Repository<Tag>, ITagsRepository
    {
        public TagsRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public Tag GetTag(string tagSlug)
        {
            return DbSet.FirstOrDefault(t => t.UrlSlug.Equals(tagSlug));
        }

        public IList<Tag> GetAllTags()
        {
            return DbSet.OrderBy(t => t.Name).ToList();
        }
    }
}
