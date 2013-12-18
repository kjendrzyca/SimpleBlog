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
            var action = SetActionName(model);

            if (model.CurrentPage == 1)
            {
                return helper.ActionLink("Next >", action, "Blog", new { page = 2 }, null);
            }
            if (model.CurrentPage == model.TotalPages)
            {
                return helper.ActionLink("< Previous", action, "Blog", new { page = model.CurrentPage - 1 }, null);
            }
            return MvcHtmlString.Create(
                helper.ActionLink("< Previous", action, "Blog", new { page = model.CurrentPage - 1 }, null) +
                helper.ActionLink("Next >", action, "Blog", new { page = model.CurrentPage + 1 }, null).ToString());
        }

        private static string SetActionName(PostsListViewModel model)
        {
            var action = "Posts";

            if (model.Category != null)
            {
                action = "Category";
            }
            else if (model.Tag != null)
            {
                action = "Tag";
            }

            return action;
        }
    }
}