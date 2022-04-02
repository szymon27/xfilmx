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
