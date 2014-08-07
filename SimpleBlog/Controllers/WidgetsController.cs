using System.Web.Mvc;
using SimpleBlog.Services;

namespace SimpleBlog.Controllers
{
    public class WidgetsController : Controller
    {
        private readonly IWidgetsModelBuilder _widgetsModelBuilder;
        private const int LatestPostsListSize = 10;

        public WidgetsController(IWidgetsModelBuilder widgetsModelBuilder)
        {
            _widgetsModelBuilder = widgetsModelBuilder;
        }

        [ChildActionOnly]
        public PartialViewResult Search()
        {
            return PartialView("_Search");
        }

        [ChildActionOnly]
        public PartialViewResult CategoriesWidget()
        {
            var categoriesListViewModel = _widgetsModelBuilder.GetAllCategories();
            return PartialView("_CategoriesWidget", categoriesListViewModel);
        }

        [ChildActionOnly]
        public PartialViewResult TagsWidget()
        {
            var tagsListViewModel = _widgetsModelBuilder.GetAllTags();
            return PartialView("_TagsWidget", tagsListViewModel);
        }

        [ChildActionOnly]
        public ActionResult LatestPostsWidget()
        {
            var postsListViewModel = _widgetsModelBuilder.GetLatestPosts(LatestPostsListSize);

            return PartialView("_LatestPostsWidget", postsListViewModel);
        }
    }
}
