namespace xfilmx.DAL
{
    public interface IRepository<T>
    {
        public IEnumerable<T> Get();
        public T Get(object id);
        public void Add(T item);
        public void Update(T item);
        public bool Delete(object id);
    }
}
