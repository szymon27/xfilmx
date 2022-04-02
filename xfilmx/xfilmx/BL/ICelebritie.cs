using xfilmx.Models;

namespace xfilmx.BL
{
    public interface ICelebritie
    {
        public Celebritie Add(Celebritie celebritie);
        public bool Change(int celebritieId, string name, string surename, DateTime? dateOfBirth, string birthPlace, byte[] picture);
        public bool Delete(int celebritieId);
        public Celebritie Get(int celebritieId);
        public IEnumerable<Celebritie> Get();
    }
}
