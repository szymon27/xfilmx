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
