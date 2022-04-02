using xfilmx.Models;

namespace xfilmx.BL
{
    public interface IGenre
    {
        public Genre Add(Genre genre);
        public bool Change(int id, string name);
        public bool Delete(int id);
        public Genre Get(int id);
        public IEnumerable<Genre> Get();
    }
}
