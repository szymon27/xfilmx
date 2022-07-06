using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.BLL.Interfaces
{
    public interface ICountryBll
    {
        public CountryDto Get(int countryId);
        public List<CountryDto> Get();
        public CountryDto Post(string name);
        public CountryDto Put(int countryId, string name);
        public bool Delete(int countryId);
    }
}
