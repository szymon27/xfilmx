using xfilmx.DAL;
using xfilmx.Models;

namespace xfilmx.BL
{
    public class BLCelebritie : ICelebritie
    {
        private readonly IUnitOfWork unitOfWork;

        public BLCelebritie(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Celebritie Add(Celebritie celebritie)
        {
            if (celebritie == null)
                throw new ArgumentNullException("invalid celebritie");

            this.unitOfWork.CelebritieRepository.Add(celebritie);
            this.unitOfWork.Complete();
            return celebritie;
        }

        public bool Change(int id, string name, string surename, DateTime date, string birthPlace, byte[] picture)
        {
            if (id <= 0)
                throw new ArgumentException("invalid celebritie id");

            Celebritie celebritie = this.Get(id);
            if (celebritie == null)
                throw new ArgumentNullException("invalid celebritie");

            celebritie.Name = name;
            celebritie.Surname = surename;
            celebritie.DateOfBirth = date;
            celebritie.PlaceOfBirth = birthPlace;
            celebritie.Picture = picture;

            this.unitOfWork.Complete();

            return true;
        }

        public bool Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("invalid celebritie id");

            bool removed = this.unitOfWork.CelebritieRepository.Delete(id);
            if (removed)
                this.unitOfWork.Complete();

            return removed;
        }

        public Celebritie Get(int id)
        {
            if (id <= 0)
                throw new ArgumentException("invalid celebritie id");

            return this.unitOfWork.CelebritieRepository.Get(id);
        }

        public IEnumerable<Celebritie> Get()
        {
            return this.unitOfWork.CelebritieRepository.Get();
        }
    }
}
