using System;
using System.Collections.Generic;
using System.Linq;
using SimpleBlog.Core.Data;
using SimpleBlog.Core.Model;
using SimpleBlog.Models.Admin;

namespace SimpleBlog.Services
{
    public class AdminService : IAdminService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Post> _postsRepository;
        private readonly IRepository<Category> _categoriesRepository;
        private readonly IRepository<Tag> _tagsRepository;

        public AdminService(IMapper mapper, IRepository<Post> postsRepository, IRepository<Category> categoriesRepository, IRepository<Tag> tagsRepository)
        {
            _mapper = mapper;
            _postsRepository = postsRepository;
            _categoriesRepository = categoriesRepository;
            _tagsRepository = tagsRepository;
        }

        public PostInput GetPost(int id)
        {
            var post = _postsRepository.GetById(id);
            var postInput = _mapper.MapEntityToPostInput(post);
            return postInput;
        }

        public AdminPostsList GetAllPosts()
        {
            return new AdminPostsList
            {
                Posts = _postsRepository.GetAll().ToList()
            };
        }

        public void CreatePost(PostInput postInput)
        {
            postInput.PostedOn = DateTime.Now;
            var post = _mapper.MapPostInputToNewEntity(postInput);
            _postsRepository.Insert(post);
        }

        public void UpdatePost(PostInput postInput)
        {
            postInput.Modified = DateTime.Now;

            var postEntityToUpdate = _postsRepository.GetById(postInput.PostId);

            var post = _mapper.MapPostInputToExistingEntity(postInput, postEntityToUpdate);
            _postsRepository.Update(post);
        }

        public void DeletePost(int id)
        {
            if (_postsRepository.GetById(id) != null)
            {
                _postsRepository.Delete(id);
            }
        }

        public CategoryInput GetCategory(int id)
        {
            var category = _categoriesRepository.GetById(id);
            var categoryInput = _mapper.MapEntityToCategoryInput(category);
            return categoryInput;
        }

        public AdminCategoriesList GetAllCategories()
        {
            return new AdminCategoriesList
                       {
                           Categories = _categoriesRepository.GetAll().ToList()
                       };
        }

        public void CreateCategory(CategoryInput categoryInput)
        {
            var category = _mapper.MapCategoryInputToNewEntity(categoryInput);
            _categoriesRepository.Insert(category);
        }

        public void UpdateCategory(CategoryInput categoryInput)
        {
            var categoryEntityToUpdate = _categoriesRepository.GetById(categoryInput.CategoryId);
            var category = _mapper.MapCategoryInputToExistingEntity(categoryInput, categoryEntityToUpdate);
            _categoriesRepository.Update(category);
        }

        public void DeleteCategory(int id)
        {
            if(_categoriesRepository.GetById(id) != null)
            {
                _categoriesRepository.Delete(id);
            }
        }

        public TagInput GetTag(int id)
        {
            var tag = _tagsRepository.GetById(id);
            var tagInput = _mapper.MapEntityToTagInput(tag);
            return tagInput;
        }

        public AdminTagsList GetAllTags()
        {
            return new AdminTagsList
                       {
                           Tags = _tagsRepository.GetAll().ToList()
                       };
        }

        public void CreateTag(TagInput tagInput)
        {
            var tag = _mapper.MapTagInputToNewEntity(tagInput);
            _tagsRepository.Insert(tag);
        }

        public void UpdateTag(TagInput tagInput)
        {
            var tagEntityToUpdate = _tagsRepository.GetById(tagInput.TagId);
            var tag = _mapper.MapTagInputToExistingEntity(tagInput, tagEntityToUpdate);
            _tagsRepository.Update(tag);
        }

        public void DeleteTag(int id)
        {
            if (_tagsRepository.GetById(id) != null)
            {
                _tagsRepository.Delete(id);
            }
        }

        public IList<Category> GetCategoriesForSelectList()
        {
            return _categoriesRepository.GetAll().ToList();
        }

        public IList<Tag> GetTagsForSelectList()
        {
            return _tagsRepository.GetAll().ToList();
        }

    }
}