using xfilmx.Models;

namespace xfilmx.BL
{
    public interface ICelebritie
    {
        public Celebritie Add(Celebritie celebritie);
        public bool Change(int id, string name, string surename, DateTime date, string birthPlace, byte[] picture);
        public bool Delete(int id);
        public Celebritie Get(int id);
        public IEnumerable<Celebritie> Get();
    }
}
