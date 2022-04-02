using xfilmx.DAL;
using xfilmx.Models;

namespace xfilmx.BL
{
    public class BLGenre : IGenre
    {
        private readonly IUnitOfWork unitOfWork;

        public BLGenre(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Genre Add(Genre genre)
        {
            if (genre == null)
                throw new ArgumentNullException("invalid genre");

            this.unitOfWork.GenreRepository.Add(genre);
            this.unitOfWork.Complete();
            return genre;
        }

        public bool Change(int id, string name)
        {
            if (id <= 0)
                throw new ArgumentException("invalid genre id");

            Genre genre = this.Get(id);
            if (genre == null)
                throw new ArgumentNullException("invalid genre");

            genre.Name = name;
            this.unitOfWork.Complete();
            return true;
        }

        public bool Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("invalid genre id");

            bool removed = this.unitOfWork.GenreRepository.Delete(id);
            if(removed)
            this.unitOfWork.Complete();

            return removed;
        }

        public Genre Get(int id)
        {
            if (id <= 0)
                throw new ArgumentException("invalid genre id");

            return this.unitOfWork.GenreRepository.Get(id);
        }

        public IEnumerable<Genre> Get()
        {
            return this.unitOfWork.GenreRepository.Get();
        }
    }
}
