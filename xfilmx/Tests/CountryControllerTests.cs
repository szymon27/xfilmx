using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using xfilmx.BLL;
using xfilmx.Controllers;
using xfilmx.Models;
using xfilmx.ViewModels;
using Xunit;

namespace Tests
{
    public class CountryControllerTests
    {
        private Mock<ICountry> mockBllCountry = new Mock<ICountry>();

        [Fact]
        public void TestIndexView()
        {
            var controller = new CountryController(this.mockBllCountry.Object);
            var result = controller.Index() as ViewResult;
            Assert.Equal("Index", result.ViewName);
        }

        [Fact]
        public void TestDeleteRedirect()
        {
            var controller = new CountryController(this.mockBllCountry.Object);
            var result = (RedirectToActionResult)controller.Delete(1);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void TestCreateView()
        {
            var controller = new CountryController(this.mockBllCountry.Object);
            var result = controller.Create() as ViewResult;
            Assert.Equal("Create", result.ViewName);
        }

        [Fact]
        public void TestCreateRedirectValidModel()
        {
            CreateCountryVM createCountryVM = new CreateCountryVM()
            {
                Name = "Poland"
            };
            this.mockBllCountry
                .Setup(m => m.Create(It.IsAny<Country>()));
            var controller = new CountryController(this.mockBllCountry.Object);
            var result = (RedirectToActionResult)controller.Create(createCountryVM);
            Assert.Equal("Create", result.ActionName);
        }

        [Fact]
        public void TestCreateViewInvalidModel()
        {
            this.mockBllCountry
                .Setup(m => m.Create(It.IsAny<Country>()));
            var controller = new CountryController(this.mockBllCountry.Object);
            CreateCountryVM createCountryVM = new CreateCountryVM()
            {
                Name = null
            };
            controller.ModelState.AddModelError("Name", "name is required");
            var result = controller.Create(createCountryVM) as ViewResult;
            Assert.Equal("Create", result.ViewName);
            Assert.Null(((CreateCountryVM)result.Model).Name);
        }

        [Fact]
        public void TestCreateViewCountryAlreadyExists()
        {
            this.mockBllCountry
                .Setup(m => m.Create(It.IsAny<Country>()))
                .Throws(new Exception("country already exists"));
            var controller = new CountryController(this.mockBllCountry.Object);
            CreateCountryVM createCountryVM = new CreateCountryVM()
            {
                Name = "Poland"
            };
            var result = controller.Create(createCountryVM) as ViewResult;
            Assert.Equal("Create", result.ViewName);
            Assert.Equal("Poland", ((CreateCountryVM)result.Model).Name);
            Assert.Equal("country already exists", result.ViewData["ErrorMessage"]);
        }


        [Fact]
        public void TestEditViewCountryExists()
        {
            this.mockBllCountry
                .Setup(m => m.Get(It.IsAny<int>()))
                .Returns(new Country() { CountryId = 1, Name = "Poland" });
            var controller = new CountryController(this.mockBllCountry.Object);
            var result = controller.Edit(1) as ViewResult;
            Assert.Equal("Edit", result.ViewName);
        }

        [Fact]
        public void TestEditRedirectCountryNotExists()
        {
            this.mockBllCountry
                .Setup(m => m.Get(It.IsAny<int>()))
                .Returns((Country)null);
            var controller = new CountryController(this.mockBllCountry.Object);
            var result = (RedirectToActionResult)controller.Edit(1);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void TestEditRedirectValidModel()
        {
            EditCountryVM editCountryVM = new EditCountryVM()
            {
                CountryId = 1,
                Name = "Poland"
            };
            this.mockBllCountry
                .Setup(m => m.Edit(It.IsAny<int>(), It.IsAny<string>()));
            var controller = new CountryController(this.mockBllCountry.Object);
            var result = (RedirectToActionResult)controller.Edit(editCountryVM);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void TestEditViewInvalidModel()
        {
            this.mockBllCountry
                .Setup(m => m.Edit(It.IsAny<int>(), It.IsAny<string>()));
            var controller = new CountryController(this.mockBllCountry.Object);
            EditCountryVM editCountryVM = new EditCountryVM()
            {
                CountryId = 1,
                Name = null
            };
            controller.ModelState.AddModelError("Name", "name is required");
            var result = controller.Edit(editCountryVM) as ViewResult;
            Assert.Equal("Edit", result.ViewName);
            Assert.Null(((EditCountryVM)result.Model).Name);
        }

        [Fact]
        public void TestEditViewCountryAlreadyExists()
        {
            this.mockBllCountry
                .Setup(m => m.Edit(It.IsAny<int>(), It.IsAny<string>()))
                .Throws(new Exception("country already exists"));
            var controller = new CountryController(this.mockBllCountry.Object);
            EditCountryVM editCountryVM = new EditCountryVM()
            {
                CountryId = 1,
                Name = "Poland"
            };
            var result = controller.Edit(editCountryVM) as ViewResult;
            Assert.Equal("Edit", result.ViewName);
            Assert.Equal("Poland", ((EditCountryVM)result.Model).Name);
            Assert.Equal("country already exists", result.ViewData["ErrorMessage"]);
        }
    }
}
