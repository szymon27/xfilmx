using Microsoft.AspNetCore.Mvc;
using xfilmx.BLL;
using xfilmx.Models;
using xfilmx.ViewModels;

namespace xfilmx.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser bllUser;

        public UserController(IUser bllUser)
        {
            this.bllUser = bllUser;
        }
        public ActionResult Index()
        {
            IEnumerable<User> users = this.bllUser.Get();
            return View("Index", users);
        }
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(CreateUserVM createUserVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.bllUser.Add(new User() { Username = createUserVM.Username, Password = createUserVM.Password });
                    return RedirectToAction("Create");
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                }
            }
            return View("Create", createUserVM);
        }
    }
}
