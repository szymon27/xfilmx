using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xfilmx.DAL;
using xfilmx.Models;
using Xunit;

namespace Tests
{
    public class InMemoryContext : DbContext
    {
        private readonly Action<InMemoryContext, ModelBuilder> _modelCustomizer;
        public InMemoryContext()
        {

        }

        public InMemoryContext(DbContextOptions<InMemoryContext> options, 
            Action<InMemoryContext, ModelBuilder> modelCustomizer = null) : base(options)
        {
            _modelCustomizer = modelCustomizer;
        }

        public DbSet<Celebritie> Celebrities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<ProductionActor> ProductionActors { get; set; }
        public DbSet<ProductionComment> ProductionComments { get; set; }
        public DbSet<ProductionCountry> ProductionCountries { get; set; }
        public DbSet<ProductionDirector> ProductionDirectors { get; set; }
        public DbSet<ProductionEpisod> ProductionEpisods { get; set; }
        public DbSet<ProductionGenre> ProductionGenres { get; set; }
        public DbSet<ProductionPicture> ProductionPictures { get; set; }
        public DbSet<ProductionRate> ProductionRates { get; set; }
        public DbSet<ProductionScreenwriter> ProductionScreenwriters { get; set; }
        public DbSet<ProductionTrailer> ProductionTrailers { get; set; }
        public DbSet<ProductionWatchStatus> ProductionWatchStatuses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductionActor>().HasKey(pk => new { pk.ProductionId, pk.CelebritieId });
            modelBuilder.Entity<ProductionCountry>().HasKey(pk => new { pk.ProductionId, pk.CountryId });
            modelBuilder.Entity<ProductionDirector>().HasKey(pk => new { pk.ProductionId, pk.CelebritieId });
            modelBuilder.Entity<ProductionEpisod>().HasKey(pk => new { pk.ProductionId, pk.Season, pk.Episod });
            modelBuilder.Entity<ProductionGenre>().HasKey(pk => new { pk.ProductionId, pk.GenreId });
            modelBuilder.Entity<ProductionRate>().HasKey(pk => new { pk.ProductionId, pk.UserId });
            modelBuilder.Entity<ProductionScreenwriter>().HasKey(pk => new { pk.ProductionId, pk.CelebritieId });
            modelBuilder.Entity<ProductionWatchStatus>().HasKey(pk => new { pk.ProductionId, pk.UserId });

            modelBuilder.Entity<User>().Property(c => c.Picture).IsRequired(false);
            modelBuilder.Entity<Celebritie>().Property(c => c.Picture).IsRequired(false);
            modelBuilder.Entity<Celebritie>().Property(c => c.PlaceOfBirth).IsRequired(false);
            modelBuilder.Entity<ProductionEpisod>().Property(c => c.Title).IsRequired(false);
            modelBuilder.Entity<Production>().Property(c => c.Picture).IsRequired(false);
        }
    }

    public class InMemoryTest
    {
        private readonly DbContextOptions<InMemoryContext> contextOptions;

        public InMemoryTest()
        {
            contextOptions = new DbContextOptionsBuilder<InMemoryContext>()
                .UseInMemoryDatabase("Test")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            var context = new InMemoryContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.AddRange(
                new Genre { GenreId = 1, Name = "Action" },
                new Genre { GenreId = 2, Name = "Thriller" },
                new User { UserId = 1, Password = "TestPass1", Username = "TestName1", UserType = UserType.Normal},
                new User { UserId = 2, Password = "TestPass2", Username = "TestName2", UserType = UserType.Normal }
                );

            context.SaveChanges();
        }

        [Fact]
        public void GetGenreById()
        {
            var context = CreateContext();

            var genresRepo = new Repository<Genre>(context);
        }

        InMemoryContext CreateContext() => new InMemoryContext(contextOptions, (context, modelBuilder) =>
        {
            modelBuilder.Entity<Genre>()
            .ToInMemoryQuery(() => context.Genres
            .Select(g => new Genre { GenreId = g.GenreId, Name = g.Name }));
            modelBuilder.Entity<User>()
            .ToInMemoryQuery(() => context.Users.
            Select(u => new User { 
                UserId = u.UserId, Password = u.Password, Username = u.Username, UserType = u.UserType 
            }));
        });
    }
}
