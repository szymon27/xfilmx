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

        public bool ChangePassword(int id, string password)
        {
            if (id <= 0)
                throw new ArgumentException("invalid user id");

            User user = this.Get(id);
            if (user == null)
                throw new ArgumentException("invalid user");

            string hashPassword = password.ToPassword();

            if (user.Password == hashPassword)
                throw new ArgumentException("new password is the same as old");

            user.Password = hashPassword;
            this.unitOfWork.Complete();
            return true;
        }

        public bool ChangePicture(int id, byte[] picture)
        {
            if (id <= 0)
                throw new ArgumentException("invalid user id");

            User user = this.Get(id);
            if (user == null)
                throw new ArgumentException("invalid user");

            //if (picture == null || picture.Length == 0)
            //    throw new ArgumentException("invalid picture");

            user.Picture = picture;
            this.unitOfWork.Complete();
            return true;
        }

        public bool ChangeType(int id, UserType userType)
        {
            if (id <= 0)
                throw new ArgumentException("invalid user id");

            User user = this.Get(id);
            if (user == null)
                throw new ArgumentException("invalid user");

            user.UserType = userType;
            this.unitOfWork.Complete();
            return true;
        }

        public bool Delete(int id)
        {
            if (id <= 0)        
                throw new ArgumentException("invalid user id");
                     
            bool removed = this.unitOfWork.UserRepository.Delete(id);
            if (removed)
                this.unitOfWork.Complete();

            return removed;
        }

        public IEnumerable<User> Get()
        {
            return this.unitOfWork.UserRepository.Get();
        }

        public User Get(int id)
        {
            if (id <= 0)
                throw new ArgumentException("invalid user id");

            return this.unitOfWork.UserRepository.Get(id);
        }

        public IEnumerable<Production> GetToWatchProductions(int id)
        {
            if (id <= 0)
                throw new ArgumentException("invalid user id");

            return this.unitOfWork.ProductionWatchStatusRepository.Get()
                .Where(pws => pws.UserId == id && pws.WatchStatus == WatchStatus.ToWatch)
                .Join(this.unitOfWork.ProductionRepository.Get(),
                pws => pws.ProductionId,
                p => p.ProductionId,
                (pws, p) => p);
        }

        public IEnumerable<Production> GetWatchedProductions(int id)
        {
            if (id <= 0)
                throw new ArgumentException("invalid user id");

            return this.unitOfWork.ProductionWatchStatusRepository.Get()
                .Where(pws => pws.UserId == id && pws.WatchStatus == WatchStatus.Watched)
                .Join(this.unitOfWork.ProductionRepository.Get(),
                pws => pws.ProductionId,
                p => p.ProductionId,
                (pws, p) => p);
        }
    }
}
