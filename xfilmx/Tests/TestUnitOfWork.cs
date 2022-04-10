using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xfilmx.DAL;
using xfilmx.Models;
using static Tests.TestMockRepository;

namespace Tests
{
    public class TestUnitOfWork : IUnitOfWork
    {
        private IRepository<User> userRepository;
        public IRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                    this.userRepository = new MockRepository<User>().Object;

                return this.userRepository;
            }
            set { this.userRepository = value; }
        }

        private IRepository<Genre> genreRepository;
        public IRepository<Genre> GenreRepository
        {
            get
            {
                if (this.genreRepository == null)
                    this.genreRepository = new MockRepository<Genre>().Object;

                return this.genreRepository;
            }
            set { this.genreRepository = value; }
        }

        private IRepository<Country> countryRepository;
        public IRepository<Country> CountryRepository
        {
            get
            {
                if (this.countryRepository == null)
                    this.countryRepository = new MockRepository<Country>().Object; ;

                return this.countryRepository;
            }
            set { this.countryRepository = value; }
        }

        private IRepository<News> newsRepository;
        public IRepository<News> NewsRepository
        {
            get
            {
                if (this.newsRepository == null)
                    this.newsRepository = new MockRepository<News>().Object;

                return this.newsRepository;
            }
            set { this.newsRepository = value; }
        }

        private IRepository<Celebritie> celebritieRepository;
        public IRepository<Celebritie> CelebritieRepository
        {
            get
            {
                if (this.celebritieRepository == null)
                    this.celebritieRepository = new MockRepository<Celebritie>().Object;

                return this.celebritieRepository;
            }
            set { this.celebritieRepository = value; }
        }

        private IRepository<Production> productionRepository;
        public IRepository<Production> ProductionRepository
        {
            get
            {
                if (this.productionRepository == null)
                    this.productionRepository = new MockRepository<Production>().Object;

                return this.productionRepository;
            }
            set { this.productionRepository = value; }
        }
        private IRepository<ProductionComment> productionCommentRepository;
        public IRepository<ProductionComment> ProductionCommentRepository
        {
            get
            {
                if (this.productionCommentRepository == null)
                    this.productionCommentRepository = new MockRepository<ProductionComment>().Object;
                return this.productionCommentRepository;
            }
            set { this.productionCommentRepository = value; }
        }

        private IRepository<ProductionRate> productionRateRepository;
        public IRepository<ProductionRate> ProductionRateRepository
        {
            get
            {
                if (this.productionRateRepository == null)
                    this.productionRateRepository = new MockRepository<ProductionRate>().Object;
                return this.productionRateRepository;
            }
            set { this.productionRateRepository = value; }
        }

        private IRepository<ProductionWatchStatus> productionWatchStatusRepository;
        public IRepository<ProductionWatchStatus> ProductionWatchStatusRepository
        {
            get
            {
                if (this.productionWatchStatusRepository == null)
                    this.productionWatchStatusRepository = new MockRepository<ProductionWatchStatus>().Object;
                return this.productionWatchStatusRepository;
            }
            set { this.productionWatchStatusRepository = value; }
        }

        private IRepository<ProductionGenre> productionGenreRepository;
        public IRepository<ProductionGenre> ProductionGenreRepository
        {
            get
            {
                if (this.productionGenreRepository == null)
                    this.productionGenreRepository = new MockRepository<ProductionGenre>().Object;
                return this.productionGenreRepository;
            }
            set { this.productionGenreRepository = value; }
        }

        private IRepository<ProductionCountry> productionCountryRepository;
        public IRepository<ProductionCountry> ProductionCountryRepository
        {
            get
            {
                if (this.productionCountryRepository == null)
                    this.productionCountryRepository = new MockRepository<ProductionCountry>().Object;
                return this.productionCountryRepository;
            }
        }

        private IRepository<ProductionTrailer> productionTrailerRepository;
        public IRepository<ProductionTrailer> ProductionTrailerRepository
        {
            get
            {
                if (this.productionTrailerRepository == null)
                    this.productionTrailerRepository = new MockRepository<ProductionTrailer>().Object;
                return this.productionTrailerRepository;
            }
            set { this.productionTrailerRepository = value; }
        }

        private IRepository<ProductionEpisod> productionEpisodRepository;
        public IRepository<ProductionEpisod> ProductionEpisodRepository
        {
            get
            {
                if (this.productionEpisodRepository == null)
                    this.productionEpisodRepository = new MockRepository<ProductionEpisod>().Object;
                return this.productionEpisodRepository;
            }
            set { this.productionEpisodRepository = value; }
        }

        private IRepository<ProductionScreenwriter> productionScreenwriterRepository;
        public IRepository<ProductionScreenwriter> ProductionScreenwriterRepository
        {
            get
            {
                if (this.productionScreenwriterRepository == null)
                    this.productionScreenwriterRepository = new MockRepository<ProductionScreenwriter>().Object;
                return this.productionScreenwriterRepository;
            }
            set { this.productionScreenwriterRepository = value; }
        }

        private IRepository<ProductionActor> productionActorRepository;
        public IRepository<ProductionActor> ProductionActorRepository
        {
            get
            {
                if (this.productionActorRepository == null)
                    this.productionActorRepository = new MockRepository<ProductionActor>().Object;
                return this.productionActorRepository;
            }
            set { this.productionActorRepository = value; }
        }

        private IRepository<ProductionDirector> productionDirectorRepository;
        public IRepository<ProductionDirector> ProductionDirectorRepository
        {
            get
            {
                if (this.productionDirectorRepository == null)
                    this.productionDirectorRepository = new MockRepository<ProductionDirector>().Object;
                return this.productionDirectorRepository;
            }
            set { this.productionDirectorRepository = value; }
        }

        private IRepository<ProductionPicture> productionPictureRepository;
        public IRepository<ProductionPicture> ProductionPictureRepository
        {
            get
            {
                if (this.productionPictureRepository == null)
                    this.productionPictureRepository = new MockRepository<ProductionPicture>().Object;
                return this.productionPictureRepository;
            }
            set { this.productionPictureRepository = value; }
        }

        public int Complete()
        {
            return 1;
        }

        public async Task<int> CompleteAsync()
        {
            return 1;
        }

        public void Dispose()
        {
            
        }
    }
}

