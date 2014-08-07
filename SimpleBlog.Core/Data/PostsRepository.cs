using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimpleBlog.Core.Entities;

namespace SimpleBlog.Core.Data
{
    public class PostsRepository : IPostsRepository
    {
        protected readonly DbContext DbContext;
        protected readonly DbSet<Post> DbSet;

        public PostsRepository(IDbContextFactory dbContextFactory)
        {
            DbContext = dbContextFactory.GetContext();
            DbSet = DbContext.Set<Post>();
        }

        public Post GetPost(int year, int month, int day, string slug)
        {
            var post = DbSet.Where(p => p.PostedOn.Year == year
                && p.PostedOn.Month == month
                && p.PostedOn.Day == day
                && p.UrlSlug.Equals(slug));

            return post.FirstOrDefault();
        }

        public IList<Post> GetAllPosts(int pageNumber, int pageSize)
        {
            return DbSet
                .Where(p => p.Published)
                .OrderByDescending(p => p.PostedOn)
                .Skip(pageNumber * pageSize)
                .Take(pageSize).ToList();
        }

        public IList<Post> GetPostsForCategory(string categorySlug, int pageNumber, int pageSize)
        {
            var posts = DbSet
                .Where(p => p.Published && p.Category.UrlSlug.Equals(categorySlug))
                .OrderByDescending(p => p.PostedOn)
                .Skip(pageNumber * pageSize)
                .Take(pageSize).ToList();

            return posts;
        }

        public IList<Post> GetPostsForTag(string tagSlug, int pageNumber, int pageSize)
        {
            var posts = DbSet
                .Where(p => p.Published && p.Tags.Any(t => t.UrlSlug.Equals(tagSlug)))
                .OrderByDescending(p => p.PostedOn)
                .Skip(pageNumber*pageSize)
                .Take(pageSize).ToList();

            return posts;
        }

        public IList<Post> GetPostsForSearch(string searchString, int pageNumber, int pageSize)
        {
            var posts = DbSet
                .Where(p => p.Published && (p.Title.Contains(searchString)
                                            || p.Category.Name.Equals(searchString)
                                            || p.Tags.Any(t => t.Name.Equals(searchString))))
                .OrderByDescending(p => p.PostedOn)
                .Skip(pageNumber*pageSize)
                .Take(pageSize).ToList();

            return posts;
        }

        public int TotalPosts()
        {
            return DbSet.Count(p => p.Published);
        }

        public int TotalPostsForCategory(string categorySlug)
        {
            return DbSet.Count(p => p.Published && p.Category.UrlSlug.Equals(categorySlug));
        }

        public int TotalPostsForTag(string tagSlug)
        {
            return DbSet.Count(p => p.Published && p.Tags.Any(t => t.UrlSlug.Equals(tagSlug)));
        }

        public int TotalPostsForSearchString(string searchString)
        {
            return DbSet.Count(p => p.Published && (p.Title.Contains(searchString)
                                            || p.Category.Name.Equals(searchString)
                                            || p.Tags.Any(t => t.Name.Equals(searchString))));
        }

        public IList<Post> GetLatestPosts(int count)
        {
            var posts = DbSet
                .Where(p => p.Published)
                .OrderByDescending(p => p.PostedOn)
                .Take(count).ToList();

            return posts;
        }
    }
}
