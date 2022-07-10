using WebAPI.BLL.Interfaces;
using WebAPI.DAL.Interfaces;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.BLL
{
    public class CelebritieBll : ICelebritieBll
    {
        private readonly IUnitOfWork unitOfWork;

        public CelebritieBll(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool ChangePicture(int celebritieId, byte[] picture)
        {
            Celebritie celebritie = this.unitOfWork.CelebritieRepository.Get(celebritieId);
            if (celebritie == null)
                return false;

            celebritie.Picture = picture;
            this.unitOfWork.Complete();
            return true;
        }

        public bool Delete(int celebritieId)
        {
            bool deleted = this.unitOfWork.CelebritieRepository.Delete(celebritieId);
            if (deleted)
            {
                var directed = this.unitOfWork.ProductionDirectorRepository.Get().Where(x => x.CelebritieId == celebritieId).ToList();
                var played  = this.unitOfWork.ProductionActorRepository.Get().Where(x => x.CelebritieId == celebritieId).ToList();
                var screenwrited = this.unitOfWork.ProductionScreenwriterRepository.Get().Where(x => x.CelebritieId == celebritieId).ToList();

                foreach(var x in directed)
                    this.unitOfWork.ProductionDirectorRepository.Delete(new { x.ProductionId, x.CelebritieId });

                foreach (var x in played)
                    this.unitOfWork.ProductionActorRepository.Delete(new { x.ProductionId, x.CelebritieId });

                foreach (var x in screenwrited)
                    this.unitOfWork.ProductionScreenwriterRepository.Delete(new { x.ProductionId, x.CelebritieId });

                this.unitOfWork.Complete();
            }
            return deleted;
        }

        public bool DeletePicture(int celebritieId)
        {
            Celebritie celebritie = this.unitOfWork.CelebritieRepository.Get(celebritieId);
            if (celebritie == null)
                return false;

            celebritie.Picture = File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, @"Resources\", "defaultNewsPicture.png"));
            this.unitOfWork.Complete();
            return true;
        }

        public CelebritieDto Get(int celebritieId)
        {
            Celebritie celebritie = this.unitOfWork.CelebritieRepository.Get(celebritieId);

            if (celebritie == null)
                return (CelebritieDto)null;

            return new CelebritieDto
            {
                Id = celebritie.CelebritieId,
                Name = celebritie.Name,
                Surname = celebritie.Surname,
                DateOfBirth = celebritie.DateOfBirth,
                PlaceOfBirth = celebritie.PlaceOfBirth,
                Picture = celebritie.Picture
            };
            
        }

        public List<CelebritieDto> Get()
        {
            return this.unitOfWork.CelebritieRepository.Get()
                .Select(c => new CelebritieDto
                {
                    Id = c.CelebritieId,
                    Name = c.Name,
                    Surname = c.Surname,
                    DateOfBirth = c.DateOfBirth,
                    PlaceOfBirth = c.PlaceOfBirth,
                    Picture = c.Picture
                }).ToList();
        }

        public CelebritieDto Post(PostCelebritieDto dto) 
        {
            Celebritie celebritie = new Celebritie
            {
                Name = dto.Name,
                Surname= dto.Surname,
                DateOfBirth = dto.DateOfBirth,
                PlaceOfBirth = dto.PlaceOfBirth,
                Picture = File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, @"Resources\", "defaultCelebritiePicture.png"))
            };

            this.unitOfWork.CelebritieRepository.Add(celebritie);
            this.unitOfWork.Complete();

            return new CelebritieDto
            {
                Id = celebritie.CelebritieId,
                Name = celebritie.Name,
                Surname = celebritie.Surname,
                DateOfBirth = celebritie.DateOfBirth,
                PlaceOfBirth = celebritie.PlaceOfBirth,
                Picture = celebritie.Picture
            };
        }

        public CelebritieDto Put(int celebritieId, PutCelebritieDto dto)
        {
            Celebritie celebritie = this.unitOfWork.CelebritieRepository.Get(celebritieId);

            if (celebritie == null)
                return (CelebritieDto)null;

            celebritie.Name = dto.Name;
            celebritie.Surname = dto.Surname;
            celebritie.DateOfBirth = dto.DateOfBirth;
            celebritie.PlaceOfBirth = dto.PlaceOfBirth;
            celebritie.Picture = File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, @"Resources\", "defaultCelebritiePicture.png"));


            this.unitOfWork.Complete();

            return new CelebritieDto
            {
                Id = celebritie.CelebritieId,
                Name = celebritie.Name,
                Surname = celebritie.Surname,
                DateOfBirth = celebritie.DateOfBirth,
                PlaceOfBirth = celebritie.PlaceOfBirth,
                Picture = celebritie.Picture
            };
        }
    }
}
