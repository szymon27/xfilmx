using WebAPI.DTO;

namespace WebAPI.BLL.Interfaces
{
    public interface INewsBll
    {
        public NewsDto Get(int newsId);
        public List<NewsDto> Get();
        public NewsDto Post(PostNewsDto postNews);
        public NewsDto Put(int newsId, PutNewsDto putNews);
        public bool ChangePicture(int newsId, byte[] picture);
        public bool DeletePicture(int newsId);
        public bool Delete(int newsId);
    }
}
