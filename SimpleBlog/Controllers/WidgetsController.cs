using System;
using System.Web;
using System.Web.Mvc;
using SimpleBlog.Services;

namespace SimpleBlog.Controllers
{
    public class WidgetsController : Controller
    {
        private readonly IWidgetsModelCreator _widgetsModelCreator;
        private const int LatestPostsListSize = 10;

        public WidgetsController(IWidgetsModelCreator widgetsModelCreator)
        {
            _widgetsModelCreator = widgetsModelCreator;
        }

        [ChildActionOnly]
        public PartialViewResult Search()
        {
            return PartialView("_Search");
        }

        [ChildActionOnly]
        public PartialViewResult CategoriesWidget()
        {
            var categoriesListViewModel = _widgetsModelCreator.GetAllCategories();
            return PartialView("_CategoriesWidget", categoriesListViewModel);
        }

        [ChildActionOnly]
        public PartialViewResult TagsWidget()
        {
            var tagsListViewModel = _widgetsModelCreator.GetAllTags();
            return PartialView("_TagsWidget", tagsListViewModel);
        }

        [ChildActionOnly]
        public ActionResult LatestPostsWidget()
        {
            var postsListViewModel = _widgetsModelCreator.GetLatestPosts(LatestPostsListSize);

            return PartialView("_LatestPostsWidget", postsListViewModel);
        }
    }
}
