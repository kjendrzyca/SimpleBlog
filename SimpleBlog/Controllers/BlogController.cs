using System.Web;
using System.Web.Mvc;
using SimpleBlog.Services;

namespace SimpleBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostViewModelCreator _postViewModelCreator;
        private const int PageSize = 2;

        public BlogController(IPostViewModelCreator postViewModelCreator)
        {
            _postViewModelCreator = postViewModelCreator;
        }

        public ActionResult Index()
        {
            return Posts();
        }

        public ActionResult Post(int year, int month, int day, string title)
        {
            var postViewModel = _postViewModelCreator.GetSinglePost(year, month, day, title);

            //TODO: null object model?
            if (postViewModel.Post == null)
                throw new HttpException(404, "Post not found");

            if (postViewModel.Post.Published == false /*&& User.Identity.IsAuthenticated == false*/)
                throw new HttpException(401, "The post is not published");

            return View(postViewModel);
        }

        public ViewResult Posts(int page = 1)
        {
            var postsListViewModel = _postViewModelCreator.GetPostsList(page, PageSize);

            return View("List", postsListViewModel);
        }

        public ActionResult Category(string category, int page = 1)
        {
            var postsListViewModel = _postViewModelCreator.GetPostsForCategory(category, page, PageSize);

            //TODO: null object model

            return View("List", postsListViewModel);
        }

        public ActionResult Tag(string tag, int page = 1)
        {
            var postsListViewModel = _postViewModelCreator.GetPostsForTag(tag, page, PageSize);

            //TODO: null object model

            return View("List", postsListViewModel);
        }

        public ActionResult Search(string searchString, int page = 1)
        {
            var postsListViewModel = _postViewModelCreator.GetPostsForSearch(searchString, page, PageSize);
            
            return View("List", postsListViewModel);
        }
    }
}
