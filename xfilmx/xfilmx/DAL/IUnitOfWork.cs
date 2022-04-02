using xfilmx.Models;

namespace xfilmx.DAL
{
    public interface IUnitOfWork
    {
        public IRepository<User> UserRepository { get;}
        public IRepository<Genre> GenreRepository { get; }
        public IRepository<Country> CountryRepository { get; }
        public IRepository<News> NewsRepository { get; }
        public IRepository<Celebritie> CelebritieRepository { get; }
        public IRepository<Production> ProductionRepository { get; }
        public IRepository<ProductionComment> ProductionCommentRepository { get; }
        public IRepository<ProductionRate> ProductionRateRepository { get; }
        public IRepository<ProductionWatchStatus> ProductionWatchStatusRepository { get; }
        public IRepository<ProductionGenre> ProductionGenreRepository { get; }
        public IRepository<ProductionCountry> ProductionCountryRepository { get; }
        public IRepository<ProductionTrailer> ProductionTrailerRepository { get; }
        public IRepository<ProductionEpisod> ProductionEpisodRepository { get; }
        public IRepository<ProductionScreenwriter> ProductionScreenwriterRepository { get; }
        public IRepository<ProductionActor> ProductionActorRepository { get; }
        public IRepository<ProductionDirector> ProductionDirectorRepository { get; }
        public IRepository<ProductionPicture> ProductionPictureRepository { get; }
        public Task<int> CompleteAsync();
        public int Complete();
    }
}
