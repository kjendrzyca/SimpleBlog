using SimpleBlog.Models;

namespace SimpleBlog.Services
{
    public interface IPostViewModelCreator
    {
        PostViewModel GetSinglePost(int year, int month, int day, string title);
        PostsListViewModel GetPosts(int page, int pageSize);
        PostsListViewModel GetPostsForCategory(string categorySlug, int page, int pageSize);
        PostsListViewModel GetPostsForTag(string tagSlug, int page, int pageSize);
        PostsListViewModel GetPostsForSearch(string searchString, int pageSize);
    }
}