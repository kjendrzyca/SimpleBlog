using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using SimpleBlog.Models;

namespace SimpleBlog.Infrastructure.HtmlHelpers
{
    public static class PaginationHelper
    {
        public static HtmlString PaginationForModel(this HtmlHelper helper, PostsListViewModel model)
        {
            var action = SetActionName(model.PageType);

            var routeValues = SetRouteValues(model.PageType, model.RouteValue, model.CurrentPage);

            if (model.CurrentPage == 1)
            {
                return helper.ActionLink("Next >", action, "Blog", routeValues[0], null);
            }
            if (model.CurrentPage == model.TotalPages)
            {
                return helper.ActionLink("< Previous", action, "Blog", routeValues[1], null);
            }
            return MvcHtmlString.Create(
                helper.ActionLink("< Previous", action, "Blog", routeValues[2], null) +
                helper.ActionLink("Next >", action, "Blog", routeValues[3], null).ToString());
        }

        private static string SetActionName(EPageType pageType)
        {
            switch (pageType)
            {
                case EPageType.CategoriesList:
                    return "Category";
                case EPageType.TagsList:
                    return "Tag";
                case EPageType.SearchStringList:
                    return "Search";
            }

            return "Posts";
        }

        private static List<object> SetRouteValues(EPageType pageType, string routeValue, int currentPage)
        {
            if (pageType == EPageType.SearchStringList)
            {
                return new List<object>
                                  {
                                      new {searchString = routeValue, page = 2},
                                      new {searchString = routeValue, page = currentPage - 1},
                                      new {searchString = routeValue, page = currentPage - 1},
                                      new {searchString = routeValue, page = currentPage + 1}
                                  };
            }

            return new List<object>
                              {
                                  new {page = 2},
                                  new {page = currentPage - 1},
                                  new {page = currentPage - 1},
                                  new {page = currentPage + 1}
                              };
        }
    }
}