using System.Web;
using System.Web.Mvc;
using SimpleBlog.Services;

namespace SimpleBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostViewModelBuilder _postViewModelBuilder;
        private const int PageSize = 2;

        public BlogController(IPostViewModelBuilder postViewModelBuilder)
        {
            _postViewModelBuilder = postViewModelBuilder;
        }

        public ActionResult Post(int year, int month, int day, string title)
        {
            var postViewModel = _postViewModelBuilder.GetSinglePost(year, month, day, title);

            //TODO: null object model?
            if (postViewModel.Post == null)
                throw new HttpException(404, "Post not found");

            if (postViewModel.Post.Published == false /*&& User.Identity.IsAuthenticated == false*/)
                throw new HttpException(401, "The post is not published");

            return View(postViewModel);
        }

        public ViewResult Posts(int page = 1)
        {
            var postsListViewModel = _postViewModelBuilder.GetPostsList(page, PageSize);

            return View("List", postsListViewModel);
        }

        public ActionResult Category(string category, int page = 1)
        {
            var postsListViewModel = _postViewModelBuilder.GetPostsForCategory(category, page, PageSize);

            //TODO: null object model

            return View("List", postsListViewModel);
        }

        public ActionResult Tag(string tag, int page = 1)
        {
            var postsListViewModel = _postViewModelBuilder.GetPostsForTag(tag, page, PageSize);

            //TODO: null object model

            return View("List", postsListViewModel);
        }

        public ActionResult Search(string searchString, int page = 1)
        {
            var postsListViewModel = _postViewModelBuilder.GetPostsForSearch(searchString, page, PageSize);
            
            return View("List", postsListViewModel);
        }
    }
}
