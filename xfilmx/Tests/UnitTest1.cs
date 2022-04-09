using xfilmx.DAL;
using xfilmx.Models;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

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
            public IRepository<User> UserRepository => new MockRepository<User>().Object;

            public IRepository<Genre> GenreRepository => new MockRepository<Genre>().Object;

            public IRepository<Country> CountryRepository => new MockRepository<Country>().Object;

            public IRepository<News> NewsRepository => new MockRepository<News>().Object;

            public IRepository<Celebritie> CelebritieRepository => new MockRepository<Celebritie>().Object;

            public IRepository<Production> ProductionRepository => new MockRepository<Production>().Object;

            public IRepository<ProductionComment> ProductionCommentRepository => new MockRepository<ProductionComment>().Object;

            public IRepository<ProductionRate> ProductionRateRepository => new MockRepository<ProductionRate>().Object;

            public IRepository<ProductionWatchStatus> ProductionWatchStatusRepository => new MockRepository<ProductionWatchStatus>().Object;

            public IRepository<ProductionGenre> ProductionGenreRepository => new MockRepository<ProductionGenre>().Object;

            public IRepository<ProductionCountry> ProductionCountryRepository => new MockRepository<ProductionCountry>().Object;

            public IRepository<ProductionTrailer> ProductionTrailerRepository => new MockRepository<ProductionTrailer>().Object;

            public IRepository<ProductionEpisod> ProductionEpisodRepository => new MockRepository<ProductionEpisod>().Object;

            public IRepository<ProductionScreenwriter> ProductionScreenwriterRepository => new MockRepository<ProductionScreenwriter>().Object;

            public IRepository<ProductionActor> ProductionActorRepository => new MockRepository<ProductionActor>().Object;

            public IRepository<ProductionDirector> ProductionDirectorRepository => new MockRepository<ProductionDirector>().Object;

            public IRepository<ProductionPicture> ProductionPictureRepository => new MockRepository<ProductionPicture>().Object;

            public int Complete()
            {
                throw new System.NotImplementedException();
            }

            public Task<int> CompleteAsync()
            {
                throw new System.NotImplementedException();
            }

            public class MockRepository<T> : Mock<IRepository<T>>
            {
                public MockRepository<T> MockGetByID(T result)
                {
                    Setup(x => x.Get(It.IsAny<int>()))
                        .Returns(result);

                    return this;
                }

                public MockRepository<T> MockGetByIDInvalid()
                {
                    Setup(x => x.Get(It.IsAny<int>()))
                        .Throws(new Exception());

                    return this;
                }

                public MockRepository<T> VerifyGetByID(Times times)
                {
                    Verify(x => x.Get(It.IsAny<int>()), times);

                    return this;
                }

                public MockRepository<T> MockGetAll(IEnumerable<T> result)
                {
                    Setup(x => x.Get())
                        .Returns(result);

                    return this;
                }

                public MockRepository<T> MockGetAll()
                {
                    Setup(x => x.Get())
                        .Throws(new Exception());

                    return this;
                }

                public MockRepository<T> VerifyGetAll(Times times)
                {
                    Verify(x => x.Get(), times);

                    return this;
                }
            }
        }
    }
}
