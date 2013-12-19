using System.Collections.Generic;
using SimpleBlog.Core.Entities;

namespace SimpleBlog.Core.Data
{
    public interface ITagsRepository
    {
        Tag GetTag(string tagSlug);
        IList<Tag> GetAllTags();
    }
}