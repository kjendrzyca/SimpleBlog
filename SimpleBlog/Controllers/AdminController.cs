using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using SimpleBlog.Infrastructure;
using SimpleBlog.Models.Admin;
using SimpleBlog.Services;

namespace SimpleBlog.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IAuthProvider _authProvider;
        private readonly IAdminService _adminService;

        public AdminController(IAuthProvider authProvider, IAdminService adminService)
        {
            _authProvider = authProvider;
            _adminService = adminService;
        }

        [AllowAnonymous]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(LoginInput loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_authProvider.Authenticate(loginModel.Login, loginModel.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Manage", "Admin"));
                }

                ModelState.AddModelError("", "Incorrect username or password");
                return View();
            }
            return View();
        }

        public ActionResult Logout()
        {
            _authProvider.SignOut();

            return RedirectToAction("Login", "Admin");
        }

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult ManagePosts()
        {
            var adminPostsList = _adminService.GetAllPosts();

            return View("ManagePosts", adminPostsList);
        }

        public ViewResult CreatePost()
        {
            var postInput = new PostInput
                            {
                                AvailableCategories = GetAvailableCategories(),
                                AvailableTags = _adminService.GetTagsForSelectList().Select(t => new SelectListItem
                                {
                                    Text = t.Name,
                                    Value = t.TagId.ToString(CultureInfo.InvariantCulture)
                                })
                            };

            return View("CreatePost", postInput);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreatePost(PostInput postInput)
        {
            if (!ModelState.IsValid)
            {
                postInput.AvailableCategories = GetAvailableCategories(postInput.CategoryId);
                postInput.AvailableTags = GetAvailableTags();

                return View("CreatePost", postInput);
            }

            _adminService.CreatePost(postInput);

            return RedirectToAction("ManagePosts");
        }


        public ViewResult EditPost(int id)
        {
            var postInput = _adminService.GetPost(id);

            postInput.AvailableCategories = GetAvailableCategories(postInput.CategoryId);
            postInput.AvailableTags = GetAvailableTags();

            return View("EditPost", postInput);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditPost(PostInput postInput)
        {
            if (!ModelState.IsValid)
            {
                postInput.AvailableCategories = GetAvailableCategories(postInput.CategoryId);
                postInput.AvailableTags = GetAvailableTags();

                return View("EditPost", postInput);
            }

            _adminService.UpdatePost(postInput);

            return RedirectToAction("ManagePosts");
        }

        public ActionResult DeletePost(int id)
        {
            _adminService.DeletePost(id);

            return RedirectToAction("ManagePosts");
        }

        public ActionResult ManageCategories()
        {
            var categories = _adminService.GetAllCategories();

            return View("ManageCategories", categories);
        }

        public ViewResult CreateCategory()
        {
            return View("CreateCategory");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreateCategory(CategoryInput categoryInput)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateCategory", categoryInput);
            }

            _adminService.CreateCategory(categoryInput);

            return RedirectToAction("ManageCategories");
        }

        public ViewResult EditCategory(int id)
        {
            var categoryInput = _adminService.GetCategory(id);

            return View("EditCategory", categoryInput);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditCategory(CategoryInput categoryInput)
        {
            if (!ModelState.IsValid)
            {
                return View("EditCategory", categoryInput);
            }

            _adminService.UpdateCategory(categoryInput);

            return RedirectToAction("ManageCategories");
        }

        public ActionResult DeleteCategory(int id)
        {
            _adminService.DeleteCategory(id);

            return RedirectToAction("ManageCategories");
        }

        public ActionResult ManageTags()
        {
            var tags = _adminService.GetAllTags();

            return View("ManageTags", tags);
        }

        public ActionResult CreateTag()
        {
            return View("CreateTag");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreateTag(TagInput tagInput)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateTag", tagInput);
            }

            _adminService.CreateTag(tagInput);

            return RedirectToAction("ManageTags");
        }

        public ViewResult EditTag(int id)
        {
            var tagInput = _adminService.GetTag(id);

            return View("EditTag", tagInput);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditTag(TagInput tagInput)
        {
            if (!ModelState.IsValid)
            {
                return View("EditTag", tagInput);
            }

            _adminService.UpdateTag(tagInput);

            return RedirectToAction("ManageTags");
        }

        public ActionResult DeleteTag(int id)
        {
            _adminService.DeleteTag(id);

            return RedirectToAction("ManageTags");
        }

        private IEnumerable<SelectListItem> GetAvailableCategories(int postInputCategoryId = 0)
        {
            return _adminService.GetCategoriesForSelectList().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.CategoryId.ToString(CultureInfo.InvariantCulture),
                Selected = postInputCategoryId == c.CategoryId
            });
        }

        private IEnumerable<SelectListItem> GetAvailableTags()
        {
            return _adminService.GetTagsForSelectList().Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = t.TagId.ToString(CultureInfo.InvariantCulture),
            });
        }
    }
}