using xfilmx.Models;

namespace xfilmx.BLL
{
    public interface ICountry
    {
        public void Create(Country country);
        public void Edit(int countryId, string name);
        public void Delete(int countryId);
        public Country Get(int countryId);
        public IEnumerable<Country> Get();
    }
}
