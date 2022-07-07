using WebAPI.DTO;

namespace WebAPI.BLL.Interfaces
{
    public interface IGenreBll
    {
        public GenreDto Get(int genreId);
        public List<GenreDto> Get();
        public GenreDto Post(string name);
        public GenreDto Put(int genreId, string name);
        public bool Delete(int genreId);
    }
}
