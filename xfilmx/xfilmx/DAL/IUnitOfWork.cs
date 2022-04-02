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
        public Task<int> CompleteAsync();
        public int Complete();
    }
}
