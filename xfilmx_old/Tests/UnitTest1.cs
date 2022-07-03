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

            public bool Delete(params object[] keys)
            {
                throw new System.NotImplementedException();
            }

            public IEnumerable<User> Get()
            {
                return this.users;
            }

            public User Get(params object[] keys)
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
        
    }
}
