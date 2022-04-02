using xfilmx.Models;

namespace xfilmx.BL
{
    public interface ICountry
    {
        public Country Add(Country country);
        public bool Change(int id, string name);
        public bool Delete(int id);
        public Country Get(int id);
        public IEnumerable<Country> Get();
    }
}
