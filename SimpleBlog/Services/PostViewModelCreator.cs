using System;
using System.Web;
using SimpleBlog.Core.Data;
using SimpleBlog.Models;

namespace SimpleBlog.Services
{
    public class PostViewModelCreator : IPostViewModelCreator
    {
        private readonly IPostsRepository _postsRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly ITagsRepository _tagsRepository;

        public PostViewModelCreator(IPostsRepository postsRepository, ICategoriesRepository categoriesRepository, ITagsRepository tagsRepository)
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

        public PostsListViewModel GetPosts(int page, int pageSize)
        {
            var model = new PostsListViewModel
                            {
                                Posts = _postsRepository.GetAllPosts(page - 1, pageSize),
                                TotalPosts = _postsRepository.TotalPosts()
                            };

            return model;
        }

        public PostsListViewModel GetPostsForCategory(string categorySlug, int page, int pageSize)
        {
            var model = new PostsListViewModel
                            {
                                Posts = _postsRepository.GetPostsForCategory(categorySlug, page - 1, pageSize),
                                TotalPosts = _postsRepository.TotalPostsForCategory(categorySlug),
                                Category = _categoriesRepository.GetCategory(categorySlug)
                            };

            return model;
        }

        public PostsListViewModel GetPostsForTag(string tagSlug, int page, int pageSize)
        {
            var model = new PostsListViewModel
                            {
                                Posts = _postsRepository.GetPostsForTag(tagSlug, page - 1, pageSize),
                                TotalPosts = _postsRepository.TotalPostsForTag(tagSlug),
                                Tag = _tagsRepository.GetTag(tagSlug)
                            };

            return model;
        }

        public PostsListViewModel GetPostsForSearch(string searchString, int pageSize)
        {
            var model = new PostsListViewModel
                            {
                                Posts = _postsRepository.GetPostsForSearch(searchString, 0, pageSize)
                            };

            return model;
        }
    }
}