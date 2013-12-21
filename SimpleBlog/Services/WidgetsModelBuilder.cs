using SimpleBlog.Core.Data;
using SimpleBlog.Models;

namespace SimpleBlog.Services
{
    public class WidgetsModelBuilder : IWidgetsModelBuilder
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IPostsRepository _postsRepository;
        private readonly ITagsRepository _tagsRepository;

        public WidgetsModelBuilder(IPostsRepository postsRepository, ICategoriesRepository categoriesRepository, ITagsRepository tagsRepository)
        {
            _categoriesRepository = categoriesRepository;
            _postsRepository = postsRepository;
            _tagsRepository = tagsRepository;
        }

        public CatgoriesListViewModel GetAllCategories()
        {
            var model = new CatgoriesListViewModel
                            {
                                Categories = _categoriesRepository.GetAllCategories()
                            };

            return model;
        }

        public TagsListViewModel GetAllTags()
        {
            var model = new TagsListViewModel
                            {
                                Tags = _tagsRepository.GetAllTags()
                            };

            return model;
        }

        public PostsListViewModel GetLatestPosts(int count)
        {
            var model = new PostsListViewModel
                            {
                                Posts = _postsRepository.GetLatestPost(count)
                            };

            return model;
        }
    }
}