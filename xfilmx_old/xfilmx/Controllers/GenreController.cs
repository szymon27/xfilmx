using Microsoft.AspNetCore.Mvc;
using xfilmx.BLL;
using xfilmx.Models;
using xfilmx.ViewModels;

namespace xfilmx.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenre bllGenre;

        public GenreController(IGenre bllGenre)
        {
            this.bllGenre = bllGenre;
        }

        public ActionResult Index()
        {
            IEnumerable<Genre> genres = this.bllGenre.Get(); 
            return View("Index", genres);
        }

        public ActionResult Delete(int genreId)
        {
            try { this.bllGenre.Delete(genreId); }
            catch { }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(CreateGenreVM createGenreVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.bllGenre.Create(new Genre() { Name = createGenreVM.Name });
                    return RedirectToAction("Create");
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                }
            }
            return View("Create", createGenreVM);
        }

        public ActionResult Edit(int genreId)
        {
            Genre genre = this.bllGenre.Get(genreId);

            if (genre == null)
                return RedirectToAction("Index");


            return View("Edit", new EditGenreVM
            {
                GenreId = genre.GenreId,
                Name = genre.Name,
            });
        }

        [HttpPost]
        public ActionResult Edit(EditGenreVM editGenreVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.bllGenre.Edit(editGenreVM.GenreId, editGenreVM.Name);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                }
            }
            return View("Edit", editGenreVM);
        }
    }
}
