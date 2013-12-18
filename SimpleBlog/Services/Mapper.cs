using System.Collections.Generic;
using System.Linq;
using SimpleBlog.Core.Data;
using SimpleBlog.Core.Model;
using SimpleBlog.Models.Admin;

namespace SimpleBlog.Services
{
    public class Mapper : IMapper
    {
        private readonly IRepository<Category> _categoriesRepository;
        private readonly IRepository<Tag> _tagsRepository;

        public Mapper(IRepository<Category> categoriesRepository, IRepository<Tag> tagsRepository)
        {
            _categoriesRepository = categoriesRepository;
            _tagsRepository = tagsRepository;
        }

        public PostInput MapEntityToPostInput(Post post)
        {
            return new PostInput
            {
                CategoryId = post.Category.CategoryId,
                Description = post.Description,
                Meta = post.Meta,
                Modified = post.Modified,
                PostedOn = post.PostedOn,
                PostId = post.PostId,
                Published = post.Published,
                ShortDescription = post.ShortDescription,
                TagsIds = ExtractTagsIdsFromTagsList(post.Tags),
                Title = post.Title,
                UrlSlug = post.UrlSlug
            };
        }
        
        public Post MapPostInputToNewEntity(PostInput postInput)
        {
            return new Post
                       {
                           Category = MapCategory(postInput.CategoryId),
                           Description = postInput.Description,
                           Meta = postInput.Meta,
                           Modified = postInput.Modified,
                           PostedOn = postInput.PostedOn,
                           Published = postInput.Published,
                           ShortDescription = postInput.ShortDescription,
                           Tags = MapTags(postInput.TagsIds),
                           Title = postInput.Title,
                           UrlSlug = postInput.UrlSlug
                       };
        }

        public Post MapPostInputToExistingEntity(PostInput postInput, Post postEntityToUpdate)
        {
            postEntityToUpdate.Category = MapCategory(postInput.CategoryId);
            postEntityToUpdate.Description = postInput.Description;
            postEntityToUpdate.Meta = postInput.Meta;
            postEntityToUpdate.Modified = postInput.Modified;
            postEntityToUpdate.PostedOn = postInput.PostedOn;
            postEntityToUpdate.Published = postInput.Published;
            postEntityToUpdate.ShortDescription = postInput.ShortDescription;
            postEntityToUpdate.Tags = MapTags(postInput.TagsIds);
            postEntityToUpdate.Title = postInput.Title;
            postEntityToUpdate.UrlSlug = postInput.UrlSlug;

            return postEntityToUpdate;
        }

        public CategoryInput MapEntityToCategoryInput(Category category)
        {
            return new CategoryInput
                       {
                           CategoryId = category.CategoryId,
                           Description = category.Description,
                           Name = category.Name,
                           UrlSlug = category.UrlSlug
                       };
        }

        public Category MapCategoryInputToNewEntity(CategoryInput categoryInput)
        {
            return new Category
            {
                Description = categoryInput.Description,
                Name = categoryInput.Name,
                UrlSlug = categoryInput.UrlSlug
            };
        }
        
        public Category MapCategoryInputToExistingEntity(CategoryInput categoryInput, Category categoryEntityToUpdate)
        {
            categoryEntityToUpdate.Description = categoryInput.Description;
            categoryEntityToUpdate.Name = categoryInput.Name;
            categoryEntityToUpdate.UrlSlug = categoryInput.UrlSlug;

            return categoryEntityToUpdate;
        }

        public TagInput MapEntityToTagInput(Tag tag)
        {
            return new TagInput
            {
                TagId = tag.TagId,
                Description = tag.Description,
                Name = tag.Name,
                UrlSlug = tag.UrlSlug
            };
        }
        
        public Tag MapTagInputToNewEntity(TagInput tagInput)
        {
            return new Tag
            {
                Description = tagInput.Description,
                Name = tagInput.Name,
                UrlSlug = tagInput.UrlSlug
            };
        }

        public Tag MapTagInputToExistingEntity(TagInput tagInput, Tag tagEntityToUpdate)
        {
            tagEntityToUpdate.Description = tagInput.Description;
            tagEntityToUpdate.Name = tagInput.Name;
            tagEntityToUpdate.UrlSlug = tagInput.UrlSlug;

            return tagEntityToUpdate;
        }

        private List<int> ExtractTagsIdsFromTagsList(IEnumerable<Tag> tags)
        {
            return tags.Select(tag => tag.TagId).ToList();
        }

        private Category MapCategory(int categoryId)
        {
            return _categoriesRepository.GetById(categoryId);
        }

        private ICollection<Tag> MapTags(IEnumerable<int> tagIds)
        {
            return tagIds.Select(id => _tagsRepository.GetById(id)).ToList();
        }
    }
}