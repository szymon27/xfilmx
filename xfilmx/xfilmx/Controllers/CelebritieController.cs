using Microsoft.AspNetCore.Mvc;
using xfilmx.BLL;
using xfilmx.Models;
using xfilmx.ViewModels;
using System.Web;

namespace xfilmx.Controllers
{
    public class CelebritieController : Controller
    {
        private readonly ICelebritie bllCelebritie;

        public CelebritieController(ICelebritie bllCelebritie)
        {
            this.bllCelebritie = bllCelebritie;
        }

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(CreateCelebritieVM createCelebritieVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.bllCelebritie.Create(new Celebritie()
                    {

                    });
                    return RedirectToAction("Create");
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                }
            }
            return View("Create", createCelebritieVM);
        }
    }
}
