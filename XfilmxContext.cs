using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
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
            modelBuilder.Entity<FilmRate>().HasKey(t => new { t.FilmId, t.UserId });
            modelBuilder.Entity<SerieRate>().HasKey(t => new { t.SerieId, t.UserId });
            modelBuilder.Entity<FilmScreenwriter>().HasKey(t => new { t.FilmId, t.CelebritieId });
            modelBuilder.Entity<SerieScreenwriter>().HasKey(t => new { t.SerieId, t.CelebritieId });
            modelBuilder.Entity<FilmToWatch>().HasKey(t => new { t.FilmId, t.UserId });
            modelBuilder.Entity<SerieToWatch>().HasKey(t => new { t.SerieEpisodId, t.UserId });
            modelBuilder.Entity<FilmWatched>().HasKey(t => new { t.FilmId, t.UserId });
            modelBuilder.Entity<SerieWatched>().HasKey(t => new { t.SerieId, t.UserId, t.Season, t.Episod });
            modelBuilder.Entity<User>().Property(p => p.Picture).IsRequired(false);
            modelBuilder.Entity<Celebritie>().Property(p => p.Picture).IsRequired(false);
            modelBuilder.Entity<FilmActor>().Property(p => p.Picture).IsRequired(false);
            modelBuilder.Entity<Film>().Property(p => p.Picture).IsRequired(false);
            modelBuilder.Entity<SerieActor>().Property(p => p.Picture).IsRequired(false);
            modelBuilder.Entity<Serie>().Property(p => p.Picture).IsRequired(false);
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
        [Column(Order = 0)]
        public int UserId { get; set; }

        [Column(Order = 1)]
        public UserType Type { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(Order = 2)]
        public string Username { get; set; }

        [Required]
        [Column(Order = 3)]
        public string Password { get; set; }

        [Column(Order = 4)]
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
        [Column(Order = 0)]
        public int NewsId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(Order = 2)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        [Column(Order = 3)]
        public string Description { get; set; }

        [Column(TypeName = "date", Order = 4)]
        public DateTime Date { get; set; }

        [Column(Order = 5)]
        public byte[] Picture { get; set; }


        [ForeignKey(nameof(User))]
        [Column(Order = 1)]
        public int UserId { get; set; }
        public User User { get; set; }
    }

    public class Serie
    {
        [Key]
        [Column(Order = 0)]
        public int SerieId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(Order = 1)]
        public string Title { get; set; }

        [Column(TypeName = "date", Order = 2)]
        public DateTime BeginDate { get; set; }

        [Column(TypeName = "date", Order = 3)]
        public DateTime EndDate { get; set; }

        [Required]
        [MaxLength(1000)]
        [Column(Order = 4)]
        public string Description { get; set; }

        [Column(Order = 5)]
        public byte[] Picture { get; set; }

        public ICollection<SerieEpisod> SerieEpisods { get; set; }
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
    }

    public class Film
    {
        [Key]
        [Column(Order = 0)]
        public int FilmId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(Order = 1)]
        public string Title { get; set; }

        [Column(TypeName = "date", Order = 2)]
        public DateTime Premiere { get; set; }

        [Column(Order = 3)]
        public int Duration { get; set; }

        [Required]
        [MaxLength(1000)]
        [Column(Order = 4)]
        public string Description { get; set; }

        [Column(Order = 5)]
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
        [Column(Order = 0)]
        public int FilmId { get; set; }
        public Film Film { get; set; }

        [ForeignKey(nameof(User))]
        [Column(Order = 1)]
        public int UserId { get; set; }
        public User User { get; set; }
    }

    [Table("SeriesToWatch")]
    public class SerieToWatch
    {
        [ForeignKey(nameof(SerieEpisod))]
        [Column(Order = 0)]
        public int SerieEpisodId { get; set; }
        public SerieEpisod SerieEpisod { get; set; }

        [ForeignKey(nameof(User))]
        [Column(Order = 1)]
        public int UserId { get; set; }
        public User User { get; set; }
    }

    [Table("FilmsWatched")]
    public class FilmWatched
    {
        [ForeignKey(nameof(Film))]
        [Column(Order = 0)]
        public int FilmId { get; set; }
        public Film Film { get; set; }

        [ForeignKey(nameof(User))]
        [Column(Order = 1)]
        public int UserId { get; set; }
        public User User { get; set; }
    }

    [Table("SeriesWatched")]
    public class SerieWatched
    {
        [ForeignKey(nameof(Serie))]
        [Column(Order = 0)]
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        [ForeignKey(nameof(User))]
        [Column(Order = 1)]
        public int UserId { get; set; }
        public User User { get; set; }

        [Column(Order = 2)]
        public int Season { get; set; }

        [Column(Order = 3)]
        public int Episod { get; set; }
    }

    public class FilmRate
    {
        [ForeignKey(nameof(Film))]
        [Column(Order = 0)]
        public int FilmId { get; set; }
        public Film Film { get; set; }

        [ForeignKey(nameof(User))]
        [Column(Order = 1)]
        public int UserId { get; set; }
        public User User { get; set; }

        [Column(Order = 2)]
        public int Rate { get; set; }
    }

    public class SerieRate
    {
        [ForeignKey(nameof(Serie))]
        [Column(Order = 0)]
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        [ForeignKey(nameof(User))]
        [Column(Order = 1)]
        public int UserId { get; set; }
        public User User { get; set; }

        [Column(Order = 2)]
        public int Rate { get; set; }
    }

    public class FilmComment
    {
        [Key]
        [Column(Order = 0)]
        public int FilmCommentId { get; set; }

        [ForeignKey(nameof(Film))]
        [Column(Order = 1)]
        public int FilmId { get; set; }
        public Film Film { get; set; }

        [ForeignKey(nameof(User))]
        [Column(Order = 2)]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [MaxLength(300)]
        [Column(Order = 3)]
        public string Comment { get; set; }
    }

    public class SerieComment
    {
        [Key]
        [Column(Order = 0)]
        public int SerieCommentId { get; set; }

        [ForeignKey(nameof(Serie))]
        [Column(Order = 1)]
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        [ForeignKey(nameof(User))]
        [Column(Order = 2)]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [MaxLength(300)]
        [Column(Order = 3)]
        public string Comment { get; set; }
    }

    public class FilmActor
    {
        [ForeignKey(nameof(Film))]
        [Column(Order = 0)]
        public int FilmId { get; set; }
        public Film Film { get; set; }

        [ForeignKey(nameof(Celebritie))]
        [Column(Order = 1)]
        public int CelebritieId { get; set; }
        public Celebritie Celebritie { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(Order = 2)]
        public string Character { get; set; }

        [Column(Order = 3)]
        public byte[] Picture { get; set; }
    }

    public class SerieActor
    {
        [ForeignKey(nameof(Serie))]
        [Column(Order = 0)]
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        [ForeignKey(nameof(Celebritie))]
        [Column(Order = 1)]
        public int CelebritieId { get; set; }
        public Celebritie Celebritie { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(Order = 2)]
        public string Character { get; set; }

        [Column(Order = 3)]
        public byte[] Picture { get; set; }
    }

    public class FilmScreenwriter
    {
        [ForeignKey(nameof(Film))]
        [Column(Order = 0)]
        public int FilmId { get; set; }
        public Film Film { get; set; }

        [ForeignKey(nameof(Celebritie))]
        [Column(Order = 1)]
        public int CelebritieId { get; set; }
        public Celebritie Celebritie { get; set; }
    }

    public class SerieScreenwriter
    {
        [ForeignKey(nameof(Serie))]
        [Column(Order = 0)]
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        [ForeignKey(nameof(Celebritie))]
        [Column(Order = 1)]
        public int CelebritieId { get; set; }
        public Celebritie Celebritie { get; set; }
    }

    public class FilmDirector
    {
        [ForeignKey(nameof(Film))]
        [Column(Order = 0)]
        public int FilmId { get; set; }
        public Film Film { get; set; }

        [ForeignKey(nameof(Celebritie))]
        [Column(Order = 1)]
        public int CelebritieId { get; set; }
        public Celebritie Celebritie { get; set; }
    }

    public class SerieDirector
    {
        [ForeignKey(nameof(Serie))]
        [Column(Order = 0)]
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        [ForeignKey(nameof(Celebritie))]
        [Column(Order = 1)]
        public int CelebritieId { get; set; }
        public Celebritie Celebritie { get; set; }
    }

    public class Celebritie
    {
        [Key]
        [Column(Order = 0)]
        public int CelebritieId { get; set; }

        [Required]
        [MaxLength(60)]
        [Column(Order = 1)]
        public string Name { get; set; }

        [Required]
        [MaxLength(60)]
        [Column(Order = 2)]
        public string Surname { get; set; }

        [Column(TypeName = "date", Order = 3)]
        public DateTime? DateOfBirth { get; set; }

        [MaxLength(60)]
        [Column(Order = 4)]
        public string PlaceOfBirth { get; set; }

        [Column(Order = 5)]
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
        [Column(Order = 0)]
        public int FilmId { get; set; }
        public Film Film { get; set; }

        [ForeignKey(nameof(Production))]
        [Column(Order = 1)]
        public int ProductionId { get; set; }
        public Production Production { get; set; }
    }

    public class SerieProduction
    {
        [ForeignKey(nameof(Serie))]
        [Column(Order = 0)]
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        [ForeignKey(nameof(Production))]
        [Column(Order = 1)]
        public int ProductionId { get; set; }
        public Production Production { get; set; }
    }

    public class Production
    {
        [Key]
        [Column(Order = 0)]
        public int ProductionId { get; set; }

        [Required]
        [MaxLength(60)]
        [Column(Order = 1)]
        public string Name { get; set; }

        public ICollection<FilmProduction> FilmProductions { get; set; }
        public ICollection<SerieProduction> SerieProductions { get; set; }

    }

    public class FilmGenre
    {
        [ForeignKey(nameof(Film))]
        [Column(Order = 0)]
        public int FilmId { get; set; }
        public Film Film { get; set; }

        [ForeignKey(nameof(Genre))]
        [Column(Order = 1)]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }

    public class SerieGenre
    {
        [ForeignKey(nameof(Serie))]
        [Column(Order = 0)]
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        [ForeignKey(nameof(Genre))]
        [Column(Order = 1)]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }

    public class Genre
    {
        [Key]
        [Column(Order = 0)]
        public int GenreId { get; set; }

        [Required]
        [MaxLength(60)]
        [Column(Order = 1)]
        public string Name { get; set; }

        public ICollection<FilmGenre> FilmGenres { get; set; }
        public ICollection<SerieGenre> SerieGenres { get; set; }

    }

    public class FilmPicture
    {
        [Key]
        [Column(Order = 0)]
        public int FilmPictureId { get; set; }

        [Column(Order = 2)]
        public byte[] Picture { get; set; }

        [ForeignKey(nameof(Film))]
        [Column(Order = 1)]
        public int FilmId { get; set; }
        public Film Film { get; set; }

    }

    public class FilmTrailer
    {
        [Key]
        [Column(Order = 0)]
        public int FilmTrailerId { get; set; }

        [Required]
        [MaxLength(255)]
        [Column(Order = 2)]
        public string Link { get; set; }

        [ForeignKey(nameof(Film))]
        [Column(Order = 1)]
        public int FilmId { get; set; }
        public Film Film { get; set; }

    }

    public class SeriePicture
    {
        [Key]
        [Column(Order = 0)]
        public int SeriePictureId { get; set; }

        [Column(Order = 2)]
        public byte[] Picture { get; set; }

        [ForeignKey(nameof(Serie))]
        [Column(Order = 1)]
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

    }

    public class SerieTrailer
    {
        [Key]
        [Column(Order = 0)]
        public int SerieTrailerId { get; set; }

        [Required]
        [MaxLength(255)]
        [Column(Order = 2)]
        public string Link { get; set; }

        [ForeignKey(nameof(Serie))]
        [Column(Order = 1)]
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

    }

    public class SerieEpisod
    {
        [Key]
        [Column(Order = 0)]
        public int SerieEpisodId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(Order = 4)]
        public string Title { get; set; }

        [Column(Order = 2)]
        public int Season { get; set; }

        [Column(Order = 3)]
        public int Episod { get; set; }

        [ForeignKey(nameof(Serie))]
        [Column(Order = 1)]
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        public ICollection<SerieToWatch> SeriesToWatch { get; set; }
    }
}
