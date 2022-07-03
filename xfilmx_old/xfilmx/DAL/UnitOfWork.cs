using xfilmx.Models;

namespace xfilmx.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Database database;
        
        public UnitOfWork(Database database)
        {
            this.database = database;
        }

        private IRepository<User> userRepository;
        public IRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                    this.userRepository = new Repository<User>(this.database);

                return this.userRepository;
            }
        }

        private IRepository<Genre> genreRepository;
        public IRepository<Genre> GenreRepository
        {
            get
            {
                if (this.genreRepository == null)
                    this.genreRepository = new Repository<Genre>(this.database);

                return this.genreRepository;
            }
        }

        private IRepository<Country> countryRepository;
        public IRepository<Country> CountryRepository
        {
            get
            {
                if(this.countryRepository == null)
                    this.countryRepository = new Repository<Country>(this.database);

                return this.countryRepository;
            }
        }

        private IRepository<News> newsRepository;
        public IRepository<News> NewsRepository 
        { 
            get 
            {
                if (this.newsRepository == null)
                    this.newsRepository = new Repository<News>(this.database);

                return this.newsRepository; 
            } 
        }

        private IRepository<Celebritie> celebritieRepository;
        public IRepository<Celebritie> CelebritieRepository
        {
            get
            {
                if (this.celebritieRepository == null)
                    this.celebritieRepository = new Repository<Celebritie>(this.database);

                return this.celebritieRepository;
            }
        }

        private IRepository<Production> productionRepository;
        public IRepository<Production> ProductionRepository
        {
            get
            {
                if (this.productionRepository == null)
                    this.productionRepository = new Repository<Production>(this.database);

                return this.productionRepository;
            }
        }
        private IRepository<ProductionComment> productionCommentRepository;
        public IRepository<ProductionComment> ProductionCommentRepository
        {
            get
            {
                if (this.productionCommentRepository == null)
                    this.productionCommentRepository = new Repository<ProductionComment>(this.database);
                return this.productionCommentRepository;
            }
        }

        private IRepository<ProductionRate> productionRateRepository;
        public IRepository<ProductionRate> ProductionRateRepository
        {
            get
            {
                if (this.productionRateRepository == null)
                    this.productionRateRepository = new Repository<ProductionRate>(this.database);
                return this.productionRateRepository;
            }
        }

        private IRepository<ProductionWatchStatus> productionWatchStatusRepository;
        public IRepository<ProductionWatchStatus> ProductionWatchStatusRepository
        {
            get
            {
                if (this.productionWatchStatusRepository == null)
                    this.productionWatchStatusRepository = new Repository<ProductionWatchStatus>(this.database);
                return this.productionWatchStatusRepository;
            }
        }

        private IRepository<ProductionGenre> productionGenreRepository;
        public IRepository<ProductionGenre> ProductionGenreRepository
        {
            get
            {
                if (this.productionGenreRepository == null)
                    this.productionGenreRepository = new Repository<ProductionGenre>(this.database);
                return this.productionGenreRepository;
            }
        }

        private IRepository<ProductionCountry> productionCountryRepository;
        public IRepository<ProductionCountry> ProductionCountryRepository
        {
            get
            {
                if (this.productionCountryRepository == null)
                    this.productionCountryRepository = new Repository<ProductionCountry>(this.database);
                return this.productionCountryRepository;
            }
        }

        private IRepository<ProductionTrailer> productionTrailerRepository;
        public IRepository<ProductionTrailer> ProductionTrailerRepository
        {
            get
            {
                if (this.productionTrailerRepository == null)
                    this.productionTrailerRepository = new Repository<ProductionTrailer>(this.database);
                return this.productionTrailerRepository;
            }
        }

        private IRepository<ProductionEpisod> productionEpisodRepository;
        public IRepository<ProductionEpisod> ProductionEpisodRepository
        {
            get
            {
                if (this.productionEpisodRepository == null)
                    this.productionEpisodRepository = new Repository<ProductionEpisod>(this.database);
                return this.productionEpisodRepository;
            }
        }

        private IRepository<ProductionScreenwriter> productionScreenwriterRepository;
        public IRepository<ProductionScreenwriter> ProductionScreenwriterRepository
        {
            get
            {
                if (this.productionScreenwriterRepository == null)
                    this.productionScreenwriterRepository = new Repository<ProductionScreenwriter>(this.database);
                return this.productionScreenwriterRepository;
            }
        }

        private IRepository<ProductionActor> productionActorRepository;
        public IRepository<ProductionActor> ProductionActorRepository
        {
            get
            {
                if (this.productionActorRepository == null)
                    this.productionActorRepository = new Repository<ProductionActor>(this.database);
                return this.productionActorRepository;
            }
        }

        private IRepository<ProductionDirector> productionDirectorRepository;
        public IRepository<ProductionDirector> ProductionDirectorRepository
        {
            get 
            {
                if (this.productionDirectorRepository == null)
                    this.productionDirectorRepository = new Repository<ProductionDirector>(this.database);
                return this.productionDirectorRepository;
            }
        }

        private IRepository<ProductionPicture> productionPictureRepository;
        public IRepository<ProductionPicture> ProductionPictureRepository
        {
            get
            {
                if (this.productionPictureRepository == null)
                    this.productionPictureRepository = new Repository<ProductionPicture>(this.database);
                return this.productionPictureRepository;
            }
        }

        public int Complete()
        {
            return this.database.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await this.database.SaveChangesAsync();
        }

        public void Dispose() 
        {
            this.database.Dispose();
        }
    }
}
