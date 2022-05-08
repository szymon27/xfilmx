using Microsoft.EntityFrameworkCore;
using xfilmx.Models;

namespace xfilmx.DAL
{
    public class Repository<T> : IRepository<T> 
        where T : class
    {
        private readonly Database database;
        private readonly DbSet<T> dbSet;

        public Repository(Database database)
        {
            this.database = database;
            this.dbSet = this.database.Set<T>();
        }

        public void Add(T item)
        {
            this.dbSet.Add(item);
        }

        public bool Delete(params object[] keys)
        {
            bool removed = false;
            T item = this.Get(keys);

            if (item == null)
                throw new Exception("item doesn't exists");

            removed = true;
            this.dbSet.Remove(item);

            return removed;
        }

        public IEnumerable<T> Get()
        {
            return this.dbSet;
        }

        public T Get(params object[] keys)
        {
            return this.dbSet.Find(keys);
        }

        public void Update(T item)
        {
            this.dbSet.Attach(item);
            this.database.Entry(item).State = EntityState.Modified;
        }
    }
}
