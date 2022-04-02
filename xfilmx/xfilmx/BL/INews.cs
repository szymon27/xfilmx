using xfilmx.Models;

namespace xfilmx.BL
{
    public interface INews
    {
        public News Add(News news);
        public bool ChangeContent(int id, string title, string description, byte[] picture);
        public News Get(int id);
        public bool Delete(int id);
        public IEnumerable<News> Get();
    }
}
