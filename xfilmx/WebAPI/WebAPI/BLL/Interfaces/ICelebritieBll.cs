using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.BLL.Interfaces
{
    public interface ICelebritieBll
    {
        public CelebritieDto Get(int id);
        public List<CelebritieDto> Get();
        public CelebritieDto Post(PostCelebritieDto dto);
        public CelebritieDto Put(int id, PutCelebritieDto dto);
        public bool ChangePicture(int celebritieId, byte[] picture);
        public bool DeletePicture(int celebritieId);
        public bool Delete(int celebritieId);
        public List<ProductionDto> DirectorIn(int celebritieId);
        public List<ProductionDto> ScreenwriterIn(int celebritieId);
        public List<ProductionDto> ActorIn(int celebritieId);
    }
}
