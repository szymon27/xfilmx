using xfilmx.Models;

namespace xfilmx.DAL
{
    public interface IUnitOfWork
    {
        public IRepository<User> UserRepository { get;}
        public IRepository<Genre> GenreRepository { get; }
        public Task<int> CompleteAsync();
        public int Complete();
    }
}
