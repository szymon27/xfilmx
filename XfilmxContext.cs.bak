using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class XfilmxContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmToWatch> FilmsToWatch { get; set; }
        public DbSet<SerieToWatch> SeriesToWatch { get; set; }
        public DbSet<FilmWatched> FilmsWatched { get; set; }
        public DbSet<SerieWatched> SeriesWatched { get; set; }
        public DbSet<FilmRate> FilmRates { get; set; }
        public DbSet<SerieRate> SerieRates { get; set; }
        public DbSet<FilmComment> FilmComments { get; set; }
        public DbSet<SerieComment> SerieComments { get; set; }
        public DbSet<FilmActor> FilmActors { get; set; }
        public DbSet<SerieActor> SerieActors { get; set; }
        public DbSet<FilmScreenwriter> FilmScreenwriters { get; set; }
        public DbSet<SerieScreenwriter> SerieScreenwriters { get; set; }
        public DbSet<FilmDirector> FilmDirectors { get; set; }
        public DbSet<SerieDirector> SerieDirectors { get; set; }
        public DbSet<Celebritie> Celebrities { get; set; }
        public DbSet<FilmProduction> FilmProductions { get; set; }
        public DbSet<SerieProduction> SerieProductions { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<FilmGenre> FilmGenres { get; set; }
        public DbSet<SerieGenre> SerieGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<FilmPicture> FilmPictures { get; set; }
        public DbSet<SeriePicture> SeriePictures { get; set; }
        public DbSet<FilmTrailer> FilmTrailers { get; set; }
        public DbSet<SerieTrailer> SerieTrailers { get; set; }
        public DbSet<SerieEpisod> SerieEpisods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmActor>().HasKey(t => new { t.FilmId, t.CelebritieId, t.Character });
            modelBuilder.Entity<SerieActor>().HasKey(t => new { t.SerieId, t.CelebritieId, t.Character });
            modelBuilder.Entity<FilmDirector>().HasKey(t => new { t.FilmId, t.CelebritieId });
            modelBuilder.Entity<SerieDirector>().HasKey(t => new { t.SerieId, t.CelebritieId });
            modelBuilder.Entity<FilmGenre>().HasKey(t => new { t.FilmId, t.GenreId });
            modelBuilder.Entity<SerieGenre>().HasKey(t => new { t.SerieId, t.GenreId });
            modelBuilder.Entity<FilmProduction>().HasKey(t => new { t.FilmId, t.ProductionId });
            modelBuilder.Entity<SerieProduction>().HasKey(t => new { t.SerieId, t.ProductionId });
            modelBuilder.Entity<FilmRate>().HasKey(t => new { t.FilmId, t.UserId});
            modelBuilder.Entity<SerieRate>().HasKey(t => new { t.SerieId, t.UserId });
            modelBuilder.Entity<FilmScreenwriter>().HasKey(t => new { t.FilmId, t.CelebritieId });
            modelBuilder.Entity<SerieScreenwriter>().HasKey(t => new { t.SerieId, t.CelebritieId });
            modelBuilder.Entity<FilmToWatch>().HasKey(t => new { t.FilmId, t.UserId });
            modelBuilder.Entity<SerieToWatch>().HasKey(t => new { t.SerieId, t.UserId });
            modelBuilder.Entity<FilmWatched>().HasKey(t => new { t.FilmId, t.UserId });
            modelBuilder.Entity<SerieWatched>().HasKey(t => new { t.SerieId, t.Season, t.Episod });
            modelBuilder.Entity<SerieEpisod>().HasKey(t => new { t.SerieId, t.Season, t.Episod });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
                                Initial Catalog=XFILMX;
                                Integrated Security=True;
                                Connect Timeout=30;
                                Encrypt=False;
                                TrustServerCertificate=False;
                                ApplicationIntent=ReadWrite;
                                MultiSubnetFailover=False");
        }
    }

    public enum UserType
    {
        Guest = 0,
        Normal = 1,
        Employee = 2,
        Admin = 3
    };

    public class User
    {
        [Key]
        public int UserId { get; set; }
        public UserType Type { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        public byte[] Picture { get; set; }
        public ICollection<News> News { get; set; }
        public ICollection<FilmComment> FilmComments { get; set; }
        public ICollection<SerieComment> SerieComments { get; set; }
        public ICollection<FilmRate> FilmRates { get; set; }
        public ICollection<SerieRate> SerieRates { get; set; }
        public ICollection<FilmWatched> FilmsWatched { get; set; }
        public ICollection<SerieWatched> SeriesWatched { get; set; }
        public ICollection<FilmToWatch> FilmsToWatch { get; set; }
        public ICollection<SerieToWatch> SeriesToWatch { get; set; }
    }

    public class News
    {
        [Key]
        public int NewsId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public byte[] Picture { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }
    }

    public class Serie
    {
        [Key]
        public int SerieId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Column(TypeName = "date")]
        public DateTime BeginDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public ICollection<SeriePicture> SeriePictures { get; set; }
        public ICollection<SerieTrailer> SerieTrailers { get; set; }
        public ICollection<SerieProduction> SerieProductions { get; set; }
        public ICollection<SerieGenre> SerieGenres { get; set; }
        public ICollection<SerieDirector> SerieDirectors { get; set; }
        public ICollection<SerieScreenwriter> SerieScreenwriters { get; set; }
        public ICollection<SerieActor> SerieActors { get; set; }
        public ICollection<SerieComment> SerieComments { get; set; }
        public ICollection<SerieRate> SerieRates { get; set; }
        public ICollection<SerieWatched> SeriesWatched { get; set; }
        public ICollection<SerieToWatch> SeriesToWatch { get; set; }
    }

    public class Film
    {
        [Key]
        public int FilmId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Column(TypeName = "date")]
        public DateTime Premiere { get; set; }

        public int Duration { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public ICollection<FilmPicture> FilmPictures { get; set; }
        public ICollection<FilmTrailer> FilmTrailers { get; set; }
        public ICollection<FilmProduction> FilmProductions { get; set; }
        public ICollection<FilmGenre> FilmGenres { get; set; }
        public ICollection<FilmDirector> FilmDirectors { get; set; }
        public ICollection<FilmScreenwriter> FilmScreenwriters { get; set; }
        public ICollection<FilmActor> FilmActors { get; set; }
        public ICollection<FilmComment> FilmComments { get; set; }
        public ICollection<FilmRate> FilmRates { get; set; }
        public ICollection<FilmWatched> FilmsWatched { get; set; }
        public ICollection<FilmToWatch> FilmsToWatch { get; set; }
    }


    [Table("FilmsToWatch")]
    public class FilmToWatch
    {
        [ForeignKey(nameof(Film))]
        public int FilmId { get; set; }
        public Film Film { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }
    }

    [Table("SeriesToWatch")]
    public class SerieToWatch
    {
        [ForeignKey(nameof(Serie))]
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }
    }

    [Table("FilmsWatched")]
    public class FilmWatched
    {
        [ForeignKey(nameof(Film))]
        public int FilmId { get; set; }
        public Film Film { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }
    }

    [Table("SeriesWatched")]
    public class SerieWatched
    {
        [ForeignKey(nameof(Serie))]
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }

        public int Season { get; set; }
        public int Episod { get; set; }
    }

    public class FilmRate
    {
        [ForeignKey(nameof(Film))]
        public int FilmId { get; set; }
        public Film Film { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }

        public int Rate { get; set; }
    }

    public class SerieRate
    {
        [ForeignKey(nameof(Serie))]
        public int SerieId { get; set; }
        public Film Serie { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }

        public int Rate { get; set; }
    }

    public class FilmComment
    {
        [Key]
        public int FilmCommentId { get; set; }
        [ForeignKey(nameof(Film))]
        public int FilmId { get; set; }
        public Film Film { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [MaxLength(300)]
        public string Comment { get; set; }
    }

    public class SerieComment
    {
        [Key]
        public int SerieCommentId { get; set; }
        [ForeignKey(nameof(Serie))]
        public int SerieId { get; set; }
        public Film Serie { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [MaxLength(300)]
        public string Comment { get; set; }
    }

    public class FilmActor
    {
        [ForeignKey(nameof(Film))]
        public int FilmId { get; set; }
        public Film Film { get; set; }

        [ForeignKey(nameof(Celebritie))]
        public int CelebritieId { get; set; }
        public Celebritie Celebritie { get; set; }

        [Required]
        [MaxLength(100)]
        public string Character { get; set; }
        public byte[] Picture { get; set; }
    }

    public class SerieActor
    {
        [ForeignKey(nameof(Serie))]
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        [ForeignKey(nameof(Celebritie))]
        public int CelebritieId { get; set; }
        public Celebritie Celebritie { get; set; }

        [Required]
        [MaxLength(100)]
        public string Character { get; set; }
        public byte[] Picture { get; set; }
    }

    public class FilmScreenwriter
    {
        [ForeignKey(nameof(Film))]
        public int FilmId { get; set; }
        public Film Film { get; set; }

        [ForeignKey(nameof(Celebritie))]
        public int CelebritieId { get; set; }
        public Celebritie Celebritie { get; set; }
    }

    public class SerieScreenwriter
    {
        [ForeignKey(nameof(Serie))]
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        [ForeignKey(nameof(Celebritie))]
        public int CelebritieId { get; set; }
        public Celebritie Celebritie { get; set; }
    }

    public class FilmDirector
    {
        [ForeignKey(nameof(Film))]
        public int FilmId { get; set; }
        public Film Film { get; set; }

        [ForeignKey(nameof(Celebritie))]
        public int CelebritieId { get; set; }
        public Celebritie Celebritie { get; set; }
    }

    public class SerieDirector
    {
        [ForeignKey(nameof(Serie))]
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        [ForeignKey(nameof(Celebritie))]
        public int CelebritieId { get; set; }
        public Celebritie Celebritie { get; set; }
    }

    public class Celebritie
    {
        [Key]
        public int ProductionId { get; set; }
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        [Required]
        [MaxLength(60)]
        public string Surnmae { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MaxLength(60)]
        public string PlaceOfBirth { get; set; }
        public byte[] Picture { get; set; }
        public ICollection<FilmDirector> FilmDirectors { get; set; }
        public ICollection<SerieDirector> SerieDirectors { get; set; }
        public ICollection<FilmScreenwriter> FilmScreenwriters { get; set; }
        public ICollection<SerieScreenwriter> SerieScreenwriters { get; set; }
        public ICollection<FilmActor> FilmActors { get; set; }
        public ICollection<SerieActor> SerieActors { get; set; }
    }

    public class FilmProduction
    {
        [ForeignKey(nameof(Film))]
        public int FilmId { get; set; }
        public Film Film { get; set; }

        [ForeignKey(nameof(Production))]
        public int ProductionId { get; set; }
        public Production Production { get; set; }
    }

    public class SerieProduction
    {
        [ForeignKey(nameof(Serie))]
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        [ForeignKey(nameof(Production))]
        public int ProductionId { get; set; }
        public Production Production { get; set; }
    }

    public class Production
    {
        [Key]
        public int ProductionId { get; set; }
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        public ICollection<FilmProduction> FilmProductions { get; set; }
        public ICollection<SerieProduction> SerieProductions { get; set; }

    }

    public class FilmGenre
    {
        [ForeignKey(nameof(Film))]
        public int FilmId { get; set; }
        public Film Film { get; set; }

        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }

    public class SerieGenre
    {
        [ForeignKey(nameof(Serie))]
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }

    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        public ICollection<FilmGenre> FilmGenres { get; set; }
        public ICollection<SerieGenre> SerieGenres { get; set; }

    }

    public class FilmPicture
    {
        [Key]
        public int FilmPictureId { get; set; }
        public byte[] Picture { get; set; }

        [ForeignKey(nameof(Film))]
        public int FilmId { get; set; }
        public Film Film { get; set; }

    }

    public class FilmTrailer
    {
        [Key]
        public int FilmTrailerId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Link { get; set; }

        [ForeignKey(nameof(Film))]
        public int FilmId { get; set; }
        public Film Film { get; set; }

    }

    public class SeriePicture
    {
        [Key]
        public int SeriePictureId { get; set; }
        public byte[] Picture { get; set; }

        [ForeignKey(nameof(Serie))]
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

    }

    public class SerieTrailer
    {
        [Key]
        public int SerieTrailerId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Link { get; set; }

        [ForeignKey(nameof(Serie))]
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

    }

    public class SerieEpisod
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public int Season { get; set; }
        public int Episod { get; set; }

        [ForeignKey(nameof(Serie))]
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

    }
}
