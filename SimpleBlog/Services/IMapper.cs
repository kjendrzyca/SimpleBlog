using SimpleBlog.Core.Model;
using SimpleBlog.Models.Admin;

namespace SimpleBlog.Services
{
    public interface IMapper
    {
        Post MapPostInputToNewEntity(PostInput postInput);
        PostInput MapEntityToPostInput(Post post);
        Post MapPostInputToExistingEntity(PostInput postInput, Post postEntityToUpdate);
        CategoryInput MapEntityToCategoryInput(Category category);
        Category MapCategoryInputToExistingEntity(CategoryInput categoryInput, Category categoryEntityToUpdate);
        Category MapCategoryInputToNewEntity(CategoryInput categoryInput);
        Tag MapTagInputToNewEntity(TagInput tagInput);
        TagInput MapEntityToTagInput(Tag tag);
        Tag MapTagInputToExistingEntity(TagInput tagInput, Tag tagEntityToUpdate);
    }
}