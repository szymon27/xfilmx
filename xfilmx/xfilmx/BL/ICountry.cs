using xfilmx.Models;

namespace xfilmx.BL
{
    public interface ICountry
    {
        public Country Add(Country country);
        public bool Change(int countryId, string name);
        public bool Delete(int countryId);
        public Country Get(int countryId);
        public IEnumerable<Country> Get();
    }
}
