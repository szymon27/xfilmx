using xfilmx.DAL;
using xfilmx.Models;

namespace xfilmx.BLL
{
    public class BLLGenre : IGenre
    {
        private readonly IUnitOfWork unitOfWork;

        public BLLGenre(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create(Genre genre)
        {
            if (genre == null)
                throw new Exception("invalid genre");

            bool canAddGenre =
                this.Get().Where(g => g.Name.ToLower() == genre.Name.ToLower()).FirstOrDefault() == null;

            if (!canAddGenre)
                throw new Exception("genre already exists");

            this.unitOfWork.GenreRepository.Add(genre);
            this.unitOfWork.Complete();
        }

        public void Edit(int genreId, string name)
        {
            if (genreId <= 0)
                throw new Exception("invalid genre id");

            Genre genre = this.Get(genreId);
            if (genre == null)
                throw new Exception("invalid genre");

            if (genre.Name.ToLower() == name.ToLower())
                throw new Exception("new genre name is same as old");

            bool canEditGenre =
                this.Get().Where(g => g.Name.ToLower() == name.ToLower()).FirstOrDefault() == null;

            if (!canEditGenre)
                throw new Exception("genre already exists");

            genre.Name = name;
            this.unitOfWork.Complete();
        }

        public void Delete(int genreId)
        {
            if (genreId <= 0)
                throw new Exception("invalid genre id");

            bool removed = this.unitOfWork.GenreRepository.Delete(genreId);
            if(removed) this.unitOfWork.Complete();
        }

        public Genre Get(int genreId)
        {
            if (genreId <= 0)
                throw new ArgumentException("invalid genre id");

            return this.unitOfWork.GenreRepository.Get(genreId);
        }

        public IEnumerable<Genre> Get()
        {
            return this.unitOfWork.GenreRepository.Get();
        }
    }
}
