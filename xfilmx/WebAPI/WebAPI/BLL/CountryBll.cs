using WebAPI.BLL.Interfaces;
using WebAPI.DAL.Interfaces;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.BLL
{
    public class CountryBll : ICountryBll
    {
        private readonly IUnitOfWork unitOfWork;

        public CountryBll(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool Delete(int countryId)
        {
            bool deleted = this.unitOfWork.CountryRepository.Delete(countryId);
            if (deleted)
            {
                var productions = this.unitOfWork.ProductionCountryRepository.Get().Where(x => x.CountryId == countryId);
                foreach (var x in productions) this.unitOfWork.ProductionCountryRepository.Delete(x.ProductionId, x.CountryId);
                this.unitOfWork.Complete();
            }
            return deleted;
        }

        public CountryDto Get(int countryId)
        {
            Country country = this.unitOfWork.CountryRepository.Get(countryId);
            if (country == null)
                return (CountryDto)null;
            return new CountryDto
            {
                CountryId = country.CountryId,
                Name = country.Name
            };
        }

        public List<CountryDto> Get()
        {
            return this.unitOfWork.CountryRepository.Get()
                .Select(c => new CountryDto
                {
                    CountryId = c.CountryId,
                    Name = c.Name
                }).ToList();
        }

        public CountryDto Post(string name)
        {
            Country country = this.unitOfWork.CountryRepository.Get()
                .Where(c => c.Name.ToLower() == name.ToLower())
                .FirstOrDefault();

            if (country != null)
                return (CountryDto)null;

            country = new Country();
            country.Name = name;
            this.unitOfWork.CountryRepository.Add(country);
            this.unitOfWork.Complete();
            return new CountryDto
            {
                CountryId = country.CountryId,
                Name = country.Name
            };
        }

        public CountryDto Put(int countryId, string name)
        {
            Country country = this.unitOfWork.CountryRepository.Get()
                .Where(c => c.Name.ToLower() == name.ToLower())
                .FirstOrDefault();

            if (country != null)
                return (CountryDto)null;

            country = this.unitOfWork.CountryRepository.Get(countryId);

            if (country == null)
                return (CountryDto)null;

            country.Name = name;
            this.unitOfWork.Complete();
            return new CountryDto
            {
                CountryId = country.CountryId,
                Name = country.Name
            };
        }
    }
}
