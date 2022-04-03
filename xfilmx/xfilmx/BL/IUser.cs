using xfilmx.Models;

namespace xfilmx.BL
{
    public interface IUser
    {
        public User Add(User user);
        public bool ChangePassword(int userId, string password);
        public bool ChangePicture(int userId, byte[] picture);
        public bool ChangeType(int userId, UserType userType);
        public bool Delete(int userId);
        public IEnumerable<User> Get();
        public User Get(int userId);
        public IEnumerable<Production> GetWatchedProductions(int userId);
        public IEnumerable<Production> GetToWatchProductions(int userId);
    }
}
