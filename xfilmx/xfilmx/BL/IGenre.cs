using xfilmx.Models;

namespace xfilmx.BL
{
    public interface IGenre
    {
        public Genre Add(Genre genre);
        public bool Change(int genreId, string name);
        public bool Delete(int genreId);
        public Genre Get(int genreId);
        public IEnumerable<Genre> Get();
    }
}
