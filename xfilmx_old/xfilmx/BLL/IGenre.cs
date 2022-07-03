using xfilmx.Models;

namespace xfilmx.BLL
{
    public interface IGenre
    {
        public void Create(Genre genre);
        public void Edit(int genreId, string name);
        public void Delete(int genreId);
        public Genre Get(int genreId);
        public IEnumerable<Genre> Get();
    }
}
