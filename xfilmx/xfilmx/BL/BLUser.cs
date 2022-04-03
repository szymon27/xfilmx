using xfilmx.DAL;
using xfilmx.Extensions;
using xfilmx.Models;

namespace xfilmx.BL
{
    public class BLUser : IUser
    {
        private readonly IUnitOfWork unitOfWork;

        public BLUser(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public User Add(User user)
        {
            if (user == null)
                throw new ArgumentException("invalid user");

            this.unitOfWork.UserRepository.Add(user);
            this.unitOfWork.Complete();
            return user;
        }

        public bool ChangePassword(int userId, string password)
        {
            if (userId <= 0)
                throw new ArgumentException("invalid user id");

            User user = this.Get(userId);
            if (user == null)
                throw new ArgumentException("invalid user");

            string hashPassword = password.ToPassword();

            if (user.Password == hashPassword)
                throw new ArgumentException("new password is the same as old");

            user.Password = hashPassword;
            this.unitOfWork.Complete();
            return true;
        }

        public bool ChangePicture(int userId, byte[] picture)
        {
            if (userId <= 0)
                throw new ArgumentException("invalid user id");

            User user = this.Get(userId);
            if (user == null)
                throw new ArgumentException("invalid user");

            //if (picture == null || picture.Length == 0)
            //    throw new ArgumentException("invalid picture");

            user.Picture = picture;
            this.unitOfWork.Complete();
            return true;
        }

        public bool ChangeType(int userId, UserType userType)
        {
            if (userId <= 0)
                throw new ArgumentException("invalid user id");

            User user = this.Get(userId);
            if (user == null)
                throw new ArgumentException("invalid user");

            user.UserType = userType;
            this.unitOfWork.Complete();
            return true;
        }

        public bool Delete(int userId)
        {
            if (userId <= 0)        
                throw new ArgumentException("invalid user id");
                     
            bool removed = this.unitOfWork.UserRepository.Delete(userId);
            if (removed)
                this.unitOfWork.Complete();

            return removed;
        }

        public IEnumerable<User> Get()
        {
            return this.unitOfWork.UserRepository.Get();
        }

        public User Get(int userId)
        {
            if (userId <= 0)
                throw new ArgumentException("invalid user id");

            return this.unitOfWork.UserRepository.Get(userId);
        }

        public IEnumerable<Production> GetToWatchProductions(int userId)
        {
            if (userId <= 0)
                throw new ArgumentException("invalid user id");

            return this.unitOfWork.ProductionWatchStatusRepository.Get()
                .Where(pws => pws.UserId == userId && pws.WatchStatus == WatchStatus.ToWatch)
                .Join(this.unitOfWork.ProductionRepository.Get(),
                pws => pws.ProductionId,
                p => p.ProductionId,
                (pws, p) => p);
        }

        public IEnumerable<Production> GetWatchedProductions(int userId)
        {
            if (userId <= 0)
                throw new ArgumentException("invalid user id");

            return this.unitOfWork.ProductionWatchStatusRepository.Get()
                .Where(pws => pws.UserId == userId && pws.WatchStatus == WatchStatus.Watched)
                .Join(this.unitOfWork.ProductionRepository.Get(),
                pws => pws.ProductionId,
                p => p.ProductionId,
                (pws, p) => p);
        }
    }
}
