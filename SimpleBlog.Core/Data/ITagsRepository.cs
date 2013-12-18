using System.Collections.Generic;
using SimpleBlog.Core.Model;

namespace SimpleBlog.Core.Data
{
    public interface ITagsRepository
    {
        Tag GetTag(string tagSlug);
        IList<Tag> GetAllTags();
    }
}