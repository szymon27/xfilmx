using Microsoft.AspNetCore.Mvc;
using xfilmx.BLL;
using xfilmx.Models;
using xfilmx.ViewModels;

namespace xfilmx.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountry bllCountry;

        public CountryController(ICountry bllCountry)
        {
            this.bllCountry = bllCountry;
        }
        
        public ActionResult Index()
        {
            IEnumerable<Country> countries = this.bllCountry.Get();
            return View("Index", countries);
        }

        public ActionResult Delete(int countryId)
        {
            try { this.bllCountry.Delete(countryId); }
            catch { }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(CreateCountryVM createCountryVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.bllCountry.Create(new Country() { Name = createCountryVM.Name });
                    return RedirectToAction("Create");
                }
                catch(Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                }
            }
            return View("Create", createCountryVM);
        }

        public ActionResult Edit(int countryId)
        {
            Country country = this.bllCountry.Get(countryId);

            if (country == null)
                return RedirectToAction("Index");

            return View("Edit", new EditCountryVM
            {
                CountryId = country.CountryId,
                Name = country.Name,
            });
        }

        [HttpPost]
        public ActionResult Edit(EditCountryVM editCountryVM)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    this.bllCountry.Edit(editCountryVM.CountryId, editCountryVM.Name);
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                }
            }
            return View("Edit", editCountryVM);
        }
    }
}
