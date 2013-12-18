using System.Collections.Generic;
using SimpleBlog.Core.Model;

namespace SimpleBlog.Core.Data
{
    public interface IPostsRepository
    {
        Post GetPost(int year, int month, int day, string slug);
        IList<Post> GetAllPosts(int pageNumber, int pageSize);
        IList<Post> GetPostsForCategory(string categorySlug, int pageNumber, int pageSize);
        IList<Post> GetPostsForTag(string tagSlug, int pageNumber, int pageSize);
        int TotalPosts();
        int TotalPostsForCategory(string categorySlug);
        int TotalPostsForTag(string tagSlug);
        IList<Post> GetPostsForSearch(string searchString, int pageNumber, int pageSize);
        IList<Post> GetLatestPost(int count);
        int TotalPostsForSearchString(string searchString);
    }
}