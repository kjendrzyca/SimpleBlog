using System;
using System.Web;
using System.Web.Mvc;
using SimpleBlog.Services;

namespace SimpleBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostViewModelCreator _postViewModelCreator;
        private const int PageSize = 5;

        public BlogController(IPostViewModelCreator postViewModelCreator)
        {
            _postViewModelCreator = postViewModelCreator;
        }

        public ActionResult Index()
        {
            return Posts();
        }

        public ViewResult Posts(int page = 1)
        {
            var postsListViewModel = _postViewModelCreator.GetPosts(page, PageSize);

            postsListViewModel.PageSize = PageSize;
            postsListViewModel.CurrentPage = page;
            postsListViewModel.TotalPages = Convert.ToInt32(Math.Ceiling((double)postsListViewModel.TotalPosts / PageSize));
            postsListViewModel.Title = "Latest posts";

            return View("List", postsListViewModel);
        }

        public ActionResult Post(int year, int month, int day, string title)
        {
            var postViewModel = _postViewModelCreator.GetSinglePost(year, month, day, title);

            if(postViewModel.Post == null)
                throw new HttpException(404, "Post not found");

            if (postViewModel.Post.Published == false /*&& User.Identity.IsAuthenticated == false*/)
                throw new HttpException(401, "The post is not published");

            return View(postViewModel);
        }

        public ActionResult Category(string category, int page = 1)
        {
            var postsListViewModel = _postViewModelCreator.GetPostsForCategory(category, page, PageSize);

            if(postsListViewModel.Category == null)
                throw new HttpException(404, "Category not found");

            postsListViewModel.PageSize = PageSize;
            postsListViewModel.CurrentPage = page;
            postsListViewModel.TotalPages = Convert.ToInt32(Math.Ceiling((double)postsListViewModel.TotalPosts / PageSize));
            postsListViewModel.Title = String.Format(@"Latest posts on category ""{0}""",
                        postsListViewModel.Category.Name);

            return View("List", postsListViewModel);
        }

        //TODO: paginacja
        public ActionResult Tag(string tag, int page = 1)
        {
            var postsListViewModel = _postViewModelCreator.GetPostsForTag(tag, page, PageSize);

            if (postsListViewModel.Tag == null)
                throw new HttpException(404, "Tag not found");

            postsListViewModel.PageSize = PageSize;
            postsListViewModel.CurrentPage = page;
            postsListViewModel.TotalPages = Convert.ToInt32(Math.Ceiling((double)postsListViewModel.TotalPosts / PageSize));
            postsListViewModel.Title = String.Format(@"Latest posts tagged on ""{0}""",
                postsListViewModel.Tag.Name);

            return View("List", postsListViewModel);
        }

        //TODO: paginacja
        public ActionResult Search(string searchString)
        {
            var postsListViewModel = _postViewModelCreator.GetPostsForSearch(searchString, PageSize);
            
            return View("List", postsListViewModel);
        }
    }
}
