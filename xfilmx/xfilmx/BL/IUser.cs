using xfilmx.Models;

namespace xfilmx.BL
{
    public interface IUser
    {
        public User Add(User user);
        public bool ChangePassword(int id, string password);
        public bool ChangePicture(int id, byte[] picture);
        public bool ChangeType(int id, UserType userType);
        public bool Delete(int id);
        public IEnumerable<User> Get();
        public User Get(int id);
        public IEnumerable<Production> GetWatchedProductions(int id);
        public IEnumerable<Production> GetToWatchProductions(int id);
    }
}
