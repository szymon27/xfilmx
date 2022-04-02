using xfilmx.Models;

namespace xfilmx.BL
{
    public interface INews
    {
        public News Add(News news);
        public bool ChangeContent(int newsId, string title, string description, byte[] picture);
        public News Get(int newsId);
        public bool Delete(int newsId);
        public IEnumerable<News> Get();
    }
}
