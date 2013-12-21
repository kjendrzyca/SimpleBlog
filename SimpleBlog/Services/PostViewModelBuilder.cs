using System;
using SimpleBlog.Core.Data;
using SimpleBlog.Models;

namespace SimpleBlog.Services
{
    public class PostViewModelBuilder : IPostViewModelBuilder
    {
        private readonly IPostsRepository _postsRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly ITagsRepository _tagsRepository;

        public PostViewModelBuilder(IPostsRepository postsRepository, ICategoriesRepository categoriesRepository, ITagsRepository tagsRepository)
        {
            _postsRepository = postsRepository;
            _categoriesRepository = categoriesRepository;
            _tagsRepository = tagsRepository;
        }

        public PostViewModel GetSinglePost(int year, int month, int day, string title)
        {
            var model = new PostViewModel
                            {
                                Post = _postsRepository.GetPost(year, month, day, title)
                            };

            return model;
        }

        public PostsListViewModel GetPostsList(int page, int pageSize)
        {
            var model = new PostsListViewModel
                            {
                                Posts = _postsRepository.GetAllPosts(page - 1, pageSize),
                                TotalPosts = _postsRepository.TotalPosts(),
                                PageSize = pageSize,
                                CurrentPage = page,
                                Title = "Latest posts",
                                PageType = EPageType.Default
                            };

            model.TotalPages = Convert.ToInt32(Math.Ceiling((double) model.TotalPosts/pageSize));

            return model;
        }

        public PostsListViewModel GetPostsForCategory(string categorySlug, int page, int pageSize)
        {
            var category = _categoriesRepository.GetCategory(categorySlug);

            var model = new PostsListViewModel
                            {
                                Posts = _postsRepository.GetPostsForCategory(categorySlug, page - 1, pageSize),
                                TotalPosts = _postsRepository.TotalPostsForCategory(categorySlug),
                                PageSize = pageSize,
                                CurrentPage = page,
                                PageType = EPageType.CategoriesList,
                                RouteValue = category.Name
                            };

            model.TotalPages = Convert.ToInt32(Math.Ceiling((double)model.TotalPosts / pageSize));
            model.Title = String.Format(@"Latest posts on category ""{0}""", category.Name);

            return model;
        }

        public PostsListViewModel GetPostsForTag(string tagSlug, int page, int pageSize)
        {
            var tag = _tagsRepository.GetTag(tagSlug);

            var model = new PostsListViewModel
                            {
                                Posts = _postsRepository.GetPostsForTag(tagSlug, page - 1, pageSize),
                                TotalPosts = _postsRepository.TotalPostsForTag(tagSlug),
                                PageSize = pageSize,
                                CurrentPage = page,
                                PageType = EPageType.TagsList,
                                RouteValue = tag.UrlSlug
                            };

            model.TotalPages = Convert.ToInt32(Math.Ceiling((double)model.TotalPosts / pageSize));
            model.Title = String.Format(@"Latest posts tagged on ""{0}""", tag.Name);

            return model;
        }

        public PostsListViewModel GetPostsForSearch(string searchString, int page, int pageSize)
        {
            var model = new PostsListViewModel
                            {
                                Posts = _postsRepository.GetPostsForSearch(searchString, page - 1, pageSize),
                                TotalPosts = _postsRepository.TotalPostsForSearchString(searchString),
                                PageSize = pageSize,
                                CurrentPage = page,
                                PageType = EPageType.SearchStringList,
                                RouteValue = searchString
                            };
            
            model.TotalPages = Convert.ToInt32(Math.Ceiling((double)model.TotalPosts / pageSize));
            model.Title = String.Format(@"Post for search string ""{0}""", searchString);

            return model;
        }
    }
}