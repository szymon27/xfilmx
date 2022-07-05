using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.BLL.Interfaces
{
    public interface ICelebritieBll
    {
        public CelebritieDto Get(int id);
        public List<CelebritieDto> Get();
        public CelebritieDto Post(PostCelebritieDto dto);
        public CelebritieDto Put(int id, PostCelebritieDto dto);
        public bool Delete(int celebritieId);
    }
}
