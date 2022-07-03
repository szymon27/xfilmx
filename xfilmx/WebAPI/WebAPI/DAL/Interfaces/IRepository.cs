namespace WebAPI.DAL.Interfaces
{
    public interface IRepository<T>
    {
        public IEnumerable<T> Get();
        public T Get(params object[] keys);
        public void Add(T item);
        public void Update(T item);
        public bool Delete(params object[] keys);
    }
}
