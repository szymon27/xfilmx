using xfilmx.Models;

namespace xfilmx.BLL
{
    public interface ICelebritie
    {
        public void Create(Celebritie celebritie);
        public void Edit(int celebritieId, string name, string surename, DateTime? dateOfBirth, string birthPlace, byte[] picture);
        public void Delete(int celebritieId);
        public Celebritie Get(int celebritieId);
        public IEnumerable<Celebritie> Get();
    }
}
