using SimpleBlog.Models;

namespace SimpleBlog.Services
{
    public interface IWidgetsModelCreator
    {
        CatgoriesListViewModel GetAllCategories();
        TagsListViewModel GetAllTags();
        PostsListViewModel GetLatestPosts(int count);
    }
}