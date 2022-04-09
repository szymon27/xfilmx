using xfilmx.DAL;
using xfilmx.Models;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void DummyTest()
        {  
            string username = "abcdef";
            Mock<IRepository<User>> mockUserRepository = new Mock<IRepository<User>>();
            mockUserRepository.Setup(x => x.Get(1)).Returns(
                new User
                {
                    Username = username
                });
            Assert.Equal(mockUserRepository.Object.Get(1).Username, username);
        }

        [Fact]
        public void StubTest()
        {
            string username = "abcdef";
            IRepository<User> userRepository = Mock.Of<IRepository<User>>(y => y.Get(1) == new User(){ Username = username});
            Assert.Equal(userRepository.Get(1).Username, username);
        }

        public class FakeUserRepository : IRepository<User>
        { 
            private List<User> users = new List<User>();
            public void Add(User item)
            {
                this.users.Add(item);
            }

            public bool Delete(object id)
            {
                throw new System.NotImplementedException();
            }

            public IEnumerable<User> Get()
            {
                return this.users;
            }

            public User Get(object id)
            {
                throw new System.NotImplementedException();
            }

            public void Update(User item)
            {
                throw new System.NotImplementedException();
            }
        }

        [Fact]
        public void FakeTest()
        {
            FakeUserRepository fakeUserRepository = new FakeUserRepository();
            fakeUserRepository.Add(new User());
            fakeUserRepository.Add(new User());
            Assert.Equal(2, fakeUserRepository.Get().Count());
        }

        public class MockUnitOfWork : IUnitOfWork
        {
            public IRepository<User> UserRepository => new Mock<IRepository<User>>().Object;

            public IRepository<Genre> GenreRepository => new Mock<IRepository<Genre>>()
                .Setup(x => x.)
                .Object;

            public IRepository<Country> CountryRepository => new Mock<IRepository<Country>>().Object;

            public IRepository<News> NewsRepository => new Mock<IRepository<News>>().Object;

            public IRepository<Celebritie> CelebritieRepository => new Mock<IRepository<Celebritie>>().Object;

            public IRepository<Production> ProductionRepository => new Mock<IRepository<Production>>().Object;

            public IRepository<ProductionComment> ProductionCommentRepository => new Mock<IRepository<ProductionComment>>().Object;

            public IRepository<ProductionRate> ProductionRateRepository => new Mock<IRepository<ProductionRate>>().Object;

            public IRepository<ProductionWatchStatus> ProductionWatchStatusRepository => new Mock<IRepository<ProductionWatchStatus>>().Object;

            public IRepository<ProductionGenre> ProductionGenreRepository => new Mock<IRepository<ProductionGenre>>().Object;

            public IRepository<ProductionCountry> ProductionCountryRepository => new Mock<IRepository<ProductionCountry>>().Object;

            public IRepository<ProductionTrailer> ProductionTrailerRepository => new Mock<IRepository<ProductionTrailer>>().Object;

            public IRepository<ProductionEpisod> ProductionEpisodRepository => new Mock<IRepository<ProductionEpisod>>().Object;

            public IRepository<ProductionScreenwriter> ProductionScreenwriterRepository => new Mock<IRepository<ProductionScreenwriter>>().Object;

            public IRepository<ProductionActor> ProductionActorRepository => new Mock<IRepository<ProductionActor>>().Object;

            public IRepository<ProductionDirector> ProductionDirectorRepository => new Mock<IRepository<ProductionDirector>>().Object;

            public IRepository<ProductionPicture> ProductionPictureRepository => new Mock<IRepository<ProductionPicture>>().Object;

            public int Complete()
            {
                throw new System.NotImplementedException();
            }

            public Task<int> CompleteAsync()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
