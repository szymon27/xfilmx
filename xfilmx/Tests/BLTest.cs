using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xfilmx.DAL;
using xfilmx.Models;
using Moq;
using Xunit;
using xfilmx.BLL;
using static Tests.TestMockRepository;

namespace Tests
{
    public class BLTest
    {
        TestUnitOfWork testUnitOfWork = new TestUnitOfWork();

        [Fact]
        public void GetGenreByIdTest()
        {           
            var mockRepository = new MockRepository<Genre>();
            mockRepository.Setup(r => r.Get(It.IsAny<int>()))
                .Returns(new Genre { Name = "Action" });

            testUnitOfWork.GenreRepository = mockRepository.Object;

            BLLGenre bLGenre = new BLLGenre(testUnitOfWork);

            Genre genre = bLGenre.Get(1);

            Assert.Equal("Action", genre.Name);
        }

        [Fact]
        public void GetAllUsersTest()
        {
            IEnumerable<User> users = new List<User>()
            {
                new User(),
                new User(),
                new User()
            };
            var mockRepository = new MockRepository<User>();
            mockRepository.Setup(r => r.Get()).Returns(users);

            testUnitOfWork.UserRepository = mockRepository.Object;

            IEnumerable<User> users2 = testUnitOfWork.UserRepository.Get();

            Assert.Equal(users2, users);
        }

    }
}
