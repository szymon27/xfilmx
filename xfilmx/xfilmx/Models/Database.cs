using Microsoft.EntityFrameworkCore;

namespace xfilmx.Models
{
    public class Database : DbContext
    {
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
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
                                        Initial Catalog=XFILMX;
                                        Integrated Security=True;
                                        Connect Timeout=30;
                                        Encrypt=False;
                                        TrustServerCertificate=False;
                                        ApplicationIntent=ReadWrite;
                                        MultiSubnetFailover=False");
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
}
