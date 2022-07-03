using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using xfilmx.BLL;
using xfilmx.Controllers;
using xfilmx.DAL;
using xfilmx.Models;
using xfilmx.ViewModels;
using Xunit;

namespace Tests
{
    public class GenreControllerTests
    {
        private Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();

        [Fact]
        public void TestIndexView()
        {
            this.mockUnitOfWork
                .Setup(m => m.GenreRepository.Get())
                .Returns(new List<Genre>());
            var bllGenre = new BLLGenre(this.mockUnitOfWork.Object);
            var controller = new GenreController(bllGenre);
            var result = controller.Index() as ViewResult;
            Assert.Equal("Index", result.ViewName);
        }

        [Fact]
        public void TestDeleteRedirect()
        {
            this.mockUnitOfWork
                .Setup(m => m.GenreRepository.Get(It.IsAny<int>()))
                .Returns(new Genre());
            this.mockUnitOfWork
                .Setup(m => m.GenreRepository.Delete(It.IsAny<int>()));
            var bllGenre = new BLLGenre(this.mockUnitOfWork.Object);
            var controller = new GenreController(bllGenre);
            var result = (RedirectToActionResult)controller.Delete(1);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void TestCreateView()
        {
            var bllGenre = new BLLGenre(this.mockUnitOfWork.Object);
            var controller = new GenreController(bllGenre);
            var result = controller.Create() as ViewResult;
            Assert.Equal("Create", result.ViewName);
        }

        [Fact]
        public void TestCreateRedirectValidModel()
        {
            CreateGenreVM createGenreVM = new CreateGenreVM()
            {
                Name = "Comedy"
            };

            this.mockUnitOfWork
                .Setup(m => m.GenreRepository.Get())
                .Returns(new List<Genre>());
            this.mockUnitOfWork
                .Setup(m => m.GenreRepository.Add(It.IsAny<Genre>()));
            var bllGenre = new BLLGenre(this.mockUnitOfWork.Object);
            var controller = new GenreController(bllGenre);
            var result = (RedirectToActionResult)controller.Create(createGenreVM);
            Assert.Equal("Create", result.ActionName);
        }

        [Fact]
        public void TestCreateViewInvalidModel()
        {
            CreateGenreVM createGenreVM = new CreateGenreVM()
            {
                Name = null
            };

            this.mockUnitOfWork
                .Setup(m => m.GenreRepository.Get())
                .Returns(new List<Genre>());
            this.mockUnitOfWork
                .Setup(m => m.GenreRepository.Add(It.IsAny<Genre>()));
            var bllGenre = new BLLGenre(this.mockUnitOfWork.Object);
            var controller = new GenreController(bllGenre);
            controller.ModelState.AddModelError("Name", "name is required");
            var result = controller.Create(createGenreVM) as ViewResult;
            Assert.Equal("Create", result.ViewName);
            Assert.Null(((CreateGenreVM)result.Model).Name);
        }

        [Fact]
        public void TestCreateViewGenreAlreadyExists()
        {
            CreateGenreVM createGenreVM = new CreateGenreVM()
            {
                Name = "Comedy"
            };

            this.mockUnitOfWork
                .Setup(m => m.GenreRepository.Get())
                .Returns(new List<Genre>() { new Genre() { GenreId = 1, Name = "Comedy" } });
            this.mockUnitOfWork
                .Setup(m => m.GenreRepository.Add(It.IsAny<Genre>()));
            var bllGenre = new BLLGenre(this.mockUnitOfWork.Object);
            var controller = new GenreController(bllGenre);
            var result = controller.Create(createGenreVM) as ViewResult;
            Assert.Equal("Create", result.ViewName);
            Assert.Equal("Comedy", ((CreateGenreVM)result.Model).Name);
            Assert.Equal("genre already exists", result.ViewData["ErrorMessage"]);
        }

        [Fact]
        public void TestEditViewGenreExists()
        {
            this.mockUnitOfWork
                .Setup(m => m.GenreRepository.Get(It.IsAny<int>()))
                .Returns(new Genre() { GenreId = 1, Name = "Comedy" });
            var bllGenre = new BLLGenre(this.mockUnitOfWork.Object);
            var controller = new GenreController(bllGenre);
            var result = controller.Edit(1) as ViewResult;
            Assert.Equal("Edit", result.ViewName);
        }

        [Fact]
        public void TestEditRedirectGenreNotExists()
        {
            this.mockUnitOfWork
                .Setup(m => m.GenreRepository.Get(It.IsAny<int>()))
                .Returns((Genre)null);
            var bllGenre = new BLLGenre(this.mockUnitOfWork.Object);
            var controller = new GenreController(bllGenre);
            var result = (RedirectToActionResult)controller.Edit(1);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void TestEditRedirectValidModel()
        {
            EditGenreVM editGenreVM = new EditGenreVM()
            {
                GenreId = 1,
                Name = "Comedy"
            };
            this.mockUnitOfWork
                .Setup(m => m.GenreRepository.Get())
                .Returns(new List<Genre>());
            this.mockUnitOfWork
                .Setup(m => m.GenreRepository.Get(It.IsAny<int>()))
                .Returns(new Genre() {GenreId = 10, Name = "xxxx"});
            var bllGenre = new BLLGenre(this.mockUnitOfWork.Object);
            var controller = new GenreController(bllGenre);
            var result = (RedirectToActionResult)controller.Edit(editGenreVM);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void TestEditViewInvalidModel()
        {
            EditGenreVM editGenreVM = new EditGenreVM()
            {
                GenreId = 1,
                Name = null
            };
            this.mockUnitOfWork
                .Setup(m => m.GenreRepository.Get())
                .Returns(new List<Genre>());
            this.mockUnitOfWork
                .Setup(m => m.GenreRepository.Get(It.IsAny<int>()))
                .Returns(new Genre() { GenreId = 10, Name = "xxxx" });
            var bllGenre = new BLLGenre(this.mockUnitOfWork.Object);
            var controller = new GenreController(bllGenre);
            controller.ModelState.AddModelError("Name", "name is required");
            var result = controller.Edit(editGenreVM) as ViewResult;
            Assert.Equal("Edit", result.ViewName);
            Assert.Null(((EditGenreVM)result.Model).Name);
        }

        [Fact]
        public void TestEditViewGenreAlreadyExists()
        {
            EditGenreVM editGenreVM = new EditGenreVM()
            {
                GenreId = 1,
                Name = "Comedy"
            };
            this.mockUnitOfWork
                .Setup(m => m.GenreRepository.Get())
                .Returns(new List<Genre>() { new Genre() { GenreId = 22, Name = "Comedy" } });
            this.mockUnitOfWork
                .Setup(m => m.GenreRepository.Get(It.IsAny<int>()))
                .Returns(new Genre() { GenreId = 1, Name = "Comedyy" });
            var bllGenre = new BLLGenre(this.mockUnitOfWork.Object);
            var controller = new GenreController(bllGenre);
            var result = controller.Edit(editGenreVM) as ViewResult;
            Assert.Equal("Edit", result.ViewName);
            Assert.Equal("Comedy", ((EditGenreVM)result.Model).Name);
            Assert.Equal("genre already exists", result.ViewData["ErrorMessage"]);

        }
    }
}
