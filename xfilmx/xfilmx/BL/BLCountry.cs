using xfilmx.DAL;
using xfilmx.Models;

namespace xfilmx.BL
{
    public class BLCountry : ICountry
    {
        private readonly IUnitOfWork unitOfWork;

        public BLCountry(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Country Add(Country country)
        {
            if (country == null)
                throw new ArgumentNullException("invalid country");

            this.unitOfWork.CountryRepository.Add(country);
            this.unitOfWork.Complete();
            return country;
        }

        public bool Change(int countryId, string name)
        {
            if (countryId <= 0)
                throw new ArgumentException("invalid country id");

            Country country = this.Get(countryId);
            if (country == null)
                throw new ArgumentNullException("invalid country");

            country.Name = name;
            this.unitOfWork.Complete();
            return true;
        }

        public bool Delete(int countryId)
        {
            if (countryId <= 0)
                throw new ArgumentException("invalid country id");

            bool removed = this.unitOfWork.GenreRepository.Delete(countryId);
            if (removed)
                this.unitOfWork.Complete();

            return removed;
        }

        public Country Get(int countryId)
        {
            if (countryId <= 0)
                throw new ArgumentException("invalid country id");

            return this.unitOfWork.CountryRepository.Get(countryId);
        }

        public IEnumerable<Country> Get()
        {
            return this.unitOfWork.CountryRepository.Get();
        }
    }
}
