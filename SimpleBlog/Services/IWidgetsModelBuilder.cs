using SimpleBlog.Models;

namespace SimpleBlog.Services
{
    public interface IWidgetsModelBuilder
    {
        CatgoriesListViewModel GetAllCategories();
        TagsListViewModel GetAllTags();
        PostsListViewModel GetLatestPosts(int count);
    }
}