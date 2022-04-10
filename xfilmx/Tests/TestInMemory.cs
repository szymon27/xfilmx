using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xfilmx.DAL;
using xfilmx.Extensions;
using xfilmx.Models;
using Xunit;

namespace Tests
{
    public class InMemoryTest
    {
        private DbContextOptions<Database> CreateContext()
            => new DbContextOptionsBuilder<Database>()
            .UseInMemoryDatabase("InMemoryDatabase")
            .Options;

        [Fact]
        public void AddGenre()
        {
            var uof = new UnitOfWork(new Database(this.CreateContext()));
            Genre genre = new Genre()
            {
                Name = "Action"
            };

            uof.GenreRepository.Add(genre);
            uof.Complete();
            Assert.Equal(genre.Name, uof.GenreRepository.Get(genre.GenreId).Name);
        }

        [Fact]
        public void DeleteGenre()
        {
            var uof = new UnitOfWork(new Database(this.CreateContext()));
            Genre genre = new Genre()
            {
                Name = "Action"
            };

            uof.GenreRepository.Add(genre);
            uof.Complete();
            Assert.Equal(genre.Name, uof.GenreRepository.Get(genre.GenreId).Name);

            bool removed = uof.GenreRepository.Delete(genre.GenreId);
            uof.Complete();
            Assert.True(removed);
            Assert.Null(uof.GenreRepository.Get(genre.GenreId));
        }

        [Fact]
        public void GetAllCountries()
        {
            var uof = new UnitOfWork(new Database(this.CreateContext()));
            List<Country> countries = new List<Country>() {
                new Country() { Name = "Poland" },
                new Country() { Name = "USA" },
                new Country() { Name = "France" }
            };
            foreach (Country c in countries)
                uof.CountryRepository.Add(c);
            uof.Complete();

            var countriesFromRepo = uof.CountryRepository.Get();
            Assert.Equal(countries.Count(), countriesFromRepo.Count());

            foreach (Country country in countries)
                Assert.True(countriesFromRepo.Any(c => c.CountryId == country.CountryId && c.Name == country.Name));
        }

        [Fact]
        public void AddNews()
        {
            var uof = new UnitOfWork(new Database(this.CreateContext()));

            User user = new User()
            {
                UserType = UserType.Employee,
                Username = "pracownik",
                Password = "abcdwsds".ToPassword(),
            };

            uof.UserRepository.Add(user);
            uof.Complete();

            News news = new News()
            {
                UserId = user.UserId,
                Title = "Test Title",
                Description = "asadasadfafafafafafasfasfasadfafafafafafasfasfasadfafafafafafasfasfasadfafafafafafasfasfasadfafafafafafasfasffafafafafafasfasf",
                Date = DateTime.Now,
                Picture = new byte[] { }
            };

            uof.NewsRepository.Add(news);
            uof.Complete();

            var userNews = uof.UserRepository.Get(user.UserId).News;
            Assert.True(userNews.Count == 1);
            Assert.True(userNews.FirstOrDefault().Title == "Test Title");
        }

        [Fact]
        public void AddCelebritie()
        {
            var uof = new UnitOfWork(new Database(this.CreateContext()));

            List<Celebritie> celebrities = new List<Celebritie>()
            {
                new Celebritie()
                {
                    Name = "Celeb1",
                    Surname = "Celeb1S"
                },
                new Celebritie()
                {
                    Name = "Celeb2",
                    Surname = "Celeb2S"
                },
                new Celebritie()
                {
                    Name = "Celeb3",
                    Surname = "Celeb3S"
                },
                new Celebritie()
                {
                    Name = "Celeb4",
                    Surname = "Celeb4S"
                },
                new Celebritie()
                {
                    Name = "Celeb5",
                    Surname = "Celeb5S"
                }
            };

            foreach (Celebritie c in celebrities)
                uof.CelebritieRepository.Add(c);
            uof.Complete();

            var celebritiesFromRepo = uof.CelebritieRepository.Get();
            Assert.Equal(celebrities.Count(), celebritiesFromRepo.Count());

            foreach (Celebritie celebritie in celebrities)
                Assert.True(celebritiesFromRepo.Any(c => c.CelebritieId == celebritie.CelebritieId &&
                c.Name == celebritie.Name && c.Surname == celebritie.Surname));
        }

        [Fact]
        public void AddEpisodsToProduction()
        {
            var uof = new UnitOfWork(new Database(this.CreateContext()));
            Production production = new Production()
            {
                IsSerie = true,
                Title = "Serie1",
                BeginDate = new DateTime(2014, 1, 1),
                EndDate = new DateTime(2018, 12, 13),
                Duration = 56,
                Description = "Serie1 description",
                Picture = new byte[] { }
            };

            uof.ProductionRepository.Add(production);
            uof.Complete();

            List<ProductionEpisod> productionEpisods = new List<ProductionEpisod>()
            {
                new ProductionEpisod() {ProductionId = production.ProductionId, Season = 1, Episod = 1, Title = "Episod1"},
                new ProductionEpisod() {ProductionId = production.ProductionId, Season = 1, Episod = 2, Title = "Episod2"},
                new ProductionEpisod() {ProductionId = production.ProductionId, Season = 1, Episod = 3, Title = "Episod3"},
                new ProductionEpisod() {ProductionId = production.ProductionId, Season = 1, Episod = 4, Title = "Episod4"},
                new ProductionEpisod() {ProductionId = production.ProductionId, Season = 1, Episod = 5, Title = "Episod5"},
                new ProductionEpisod() {ProductionId = production.ProductionId, Season = 1, Episod = 6, Title = "Episod6"},
            };

            foreach (ProductionEpisod pe in productionEpisods)
                uof.ProductionEpisodRepository.Add(pe);
            uof.Complete();

            var productionEpisodsFromRepo = uof.ProductionRepository.Get(production.ProductionId).ProductionEpisods;
            Assert.True(productionEpisods.Count() == productionEpisodsFromRepo.Count());
        }

        [Fact]
        public void DeleteEpisodFromProduction()
        {
            var uof = new UnitOfWork(new Database(this.CreateContext()));
            Production production = new Production()
            {
                IsSerie = true,
                Title = "Serie1",
                BeginDate = new DateTime(2014, 1, 1),
                EndDate = new DateTime(2018, 12, 13),
                Duration = 56,
                Description = "Serie1 description",
                Picture = new byte[] { }
            };

            uof.ProductionRepository.Add(production);
            uof.Complete();

            List<ProductionEpisod> productionEpisods = new List<ProductionEpisod>()
            {
                new ProductionEpisod() {ProductionId = production.ProductionId, Season = 1, Episod = 1, Title = "Episod1"},
                new ProductionEpisod() {ProductionId = production.ProductionId, Season = 1, Episod = 2, Title = "Episod2"},
                new ProductionEpisod() {ProductionId = production.ProductionId, Season = 1, Episod = 3, Title = "Episod3"},
                new ProductionEpisod() {ProductionId = production.ProductionId, Season = 1, Episod = 4, Title = "Episod4"},
                new ProductionEpisod() {ProductionId = production.ProductionId, Season = 1, Episod = 5, Title = "Episod5"},
                new ProductionEpisod() {ProductionId = production.ProductionId, Season = 1, Episod = 6, Title = "Episod6"},
            };

            foreach (ProductionEpisod pe in productionEpisods)
                uof.ProductionEpisodRepository.Add(pe);
            uof.Complete();

            var productionEpisodsFromRepo = uof.ProductionRepository.Get(production.ProductionId).ProductionEpisods;
            Assert.True(productionEpisods.Count() == productionEpisodsFromRepo.Count());

            ProductionEpisod productionEpisodToDelete = productionEpisods.ElementAt(productionEpisods.Count - 1);
            uof.ProductionEpisodRepository.Delete(productionEpisodToDelete.ProductionId, productionEpisodToDelete.Season, productionEpisodToDelete.Episod);
            uof.Complete();

            productionEpisodsFromRepo = uof.ProductionRepository.Get(production.ProductionId).ProductionEpisods;
            Assert.True(!productionEpisodsFromRepo.Any(pe => pe.ProductionId == productionEpisodToDelete.ProductionId &&
                                                        pe.Season == productionEpisodToDelete.Season &&
                                                        pe.Episod == productionEpisodToDelete.Episod));

        }
    }
}
