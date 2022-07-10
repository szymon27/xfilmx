using WebAPI.BLL.Interfaces;
using WebAPI.DAL.Interfaces;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.BLL
{
    public class GenreBll : IGenreBll
    {
        private readonly IUnitOfWork unitOfWork;

        public GenreBll(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool Delete(int genreId)
        {
            bool deleted = this.unitOfWork.GenreRepository.Delete(genreId);
            if (deleted)
            {
                var productions = this.unitOfWork.ProductionGenreRepository.Get().Where(x => x.GenreId == genreId);
                foreach (var x in productions) this.unitOfWork.ProductionGenreRepository.Delete(new { x.ProductionId, x.GenreId });
                this.unitOfWork.Complete();
            }
            return deleted;
        }

        public GenreDto Get(int genreId)
        {
            Genre genre = this.unitOfWork.GenreRepository.Get(genreId);
            if (genre == null)
                return (GenreDto)null;
            return new GenreDto
            {
                GenreId = genre.GenreId,
                Name = genre.Name
            };
        }

        public List<GenreDto> Get()
        {
            return this.unitOfWork.GenreRepository.Get()
                .Select(g => new GenreDto
                {
                    GenreId = g.GenreId,
                    Name = g.Name
                }).ToList();
        }

        public GenreDto Post(string name)
        {
            Genre genre = this.unitOfWork.GenreRepository.Get()
                .Where(g => g.Name.ToLower() == name.ToLower())
                .FirstOrDefault();

            if (genre != null)
                return (GenreDto)null;

            genre = new Genre();
            genre.Name = name;
            this.unitOfWork.GenreRepository.Add(genre);
            this.unitOfWork.Complete();
            return new GenreDto
            {
                GenreId = genre.GenreId,
                Name = genre.Name
            };
        }

        public GenreDto Put(int genreId, string name)
        {
            Genre genre = this.unitOfWork.GenreRepository.Get()
                .Where(g => g.Name.ToLower() == name.ToLower())
                .FirstOrDefault();

            if (genre != null)
                return (GenreDto)null;

            genre = this.unitOfWork.GenreRepository.Get(genreId);

            if (genre == null)
                return (GenreDto)null;

            genre.Name = name;
            this.unitOfWork.Complete();
            return new GenreDto
            {
                GenreId = genre.GenreId,
                Name = genre.Name
            };
        }
    }
}
