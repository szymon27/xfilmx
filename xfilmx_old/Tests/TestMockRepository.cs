using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using xfilmx.DAL;

namespace Tests
{
    public class TestMockRepository
    {
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

