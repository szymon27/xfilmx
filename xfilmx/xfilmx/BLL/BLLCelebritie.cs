using xfilmx.DAL;
using xfilmx.Models;

namespace xfilmx.BLL
{
    public class BLLCelebritie : ICelebritie
    {
        private readonly IUnitOfWork unitOfWork;

        public BLLCelebritie(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create(Celebritie celebritie)
        {
            if (celebritie == null)
                throw new Exception("invalid celebritie");

            this.unitOfWork.CelebritieRepository.Add(celebritie);
            this.unitOfWork.Complete();
        }

        public void Edit(int celebritieId, string name, string surename, DateTime? dateOfBirth, string birthPlace, byte[] picture)
        {
            if (celebritieId <= 0)
                throw new Exception("invalid celebritie id");

            Celebritie celebritie = this.Get(celebritieId);
            if (celebritie == null)
                throw new Exception("invalid celebritie");

            celebritie.Name = name;
            celebritie.Surname = surename;
            celebritie.DateOfBirth = dateOfBirth;
            celebritie.PlaceOfBirth = birthPlace;
            celebritie.Picture = picture;
            this.unitOfWork.Complete();
        }

        public void Delete(int celebritieId)
        {
            if (celebritieId <= 0)
                throw new Exception("invalid celebritie id");

            bool removed = this.unitOfWork.CelebritieRepository.Delete(celebritieId);
            if (removed) this.unitOfWork.Complete();
        }

        public Celebritie Get(int celebritieId)
        {
            if (celebritieId <= 0)
                throw new Exception("invalid celebritie id");

            return this.unitOfWork.CelebritieRepository.Get(celebritieId);
        }

        public IEnumerable<Celebritie> Get()
        {
            return this.unitOfWork.CelebritieRepository.Get();
        }
    }
}
