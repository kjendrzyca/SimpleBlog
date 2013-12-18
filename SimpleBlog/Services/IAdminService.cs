using System.Collections.Generic;
using SimpleBlog.Core.Model;
using SimpleBlog.Models.Admin;

namespace SimpleBlog.Services
{
    public interface IAdminService
    {
        PostInput GetPost(int id);
        void CreatePost(PostInput postInput);
        void UpdatePost(PostInput postInput);
        void DeletePost(int id);
        AdminPostsList GetAllPosts();
        IList<Category> GetCategoriesForSelectList();
        IList<Tag> GetTagsForSelectList();
        AdminCategoriesList GetAllCategories();
        CategoryInput GetCategory(int id);
        void CreateCategory(CategoryInput categoryInput);
        void UpdateCategory(CategoryInput categoryInput);
        void DeleteCategory(int id);
        AdminTagsList GetAllTags();
        TagInput GetTag(int id);
        void CreateTag(TagInput tagInput);
        void UpdateTag(TagInput tagInput);
        void DeleteTag(int id);
    }
}