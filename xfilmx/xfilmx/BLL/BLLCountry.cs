using xfilmx.DAL;
using xfilmx.Models;

namespace xfilmx.BLL
{
    public class BLLCountry : ICountry
    {
        private readonly IUnitOfWork unitOfWork;

        public BLLCountry(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create(Country country)
        {
            if (country == null)
                throw new Exception("invalid country");

            bool canAddCountry = 
                this.Get().Where(c => c.Name.ToLower() == country.Name.ToLower()).FirstOrDefault() == null;
            
            if (!canAddCountry)
                throw new Exception("country already exists");

            this.unitOfWork.CountryRepository.Add(country);
            this.unitOfWork.Complete();
        }

        public void Edit(int countryId, string name)
        {
            if (countryId <= 0)
                throw new Exception("invalid country id");

            Country country = this.Get(countryId);
            if (country == null)
                throw new Exception("invalid country");

            if (country.Name.ToLower() == name.ToLower())
                throw new Exception("new country name is same as old");

            bool canEditCountry =
                this.Get().Where(c => c.Name.ToLower() == name.ToLower()).FirstOrDefault() == null;

            if (!canEditCountry)
                throw new Exception("country already exists");

            country.Name = name;
            this.unitOfWork.Complete();
        }

        public void Delete(int countryId)
        {
            if (countryId <= 0)
                throw new Exception("invalid country id");

            bool removed = this.unitOfWork.CountryRepository.Delete(countryId);
            if (removed) this.unitOfWork.Complete();
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
