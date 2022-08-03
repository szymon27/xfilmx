using WebAPI.BLL.Interfaces;
using WebAPI.DAL.Interfaces;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.BLL
{
    public class NewsBll : INewsBll
    {
        private readonly IUnitOfWork unitOfWork;

        public NewsBll(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool ChangePicture(int newsId, byte[] picture)
        {
            News news = this.unitOfWork.NewsRepository.Get(newsId);
            if (news == null)
                return false;

            news.Picture = picture;
            this.unitOfWork.Complete();
            return true;
        }

        public bool Delete(int newsId)
        {
            bool deleted = this.unitOfWork.NewsRepository.Delete(newsId);
            if (deleted) this.unitOfWork.Complete();
            return deleted;
        }

        public bool DeletePicture(int newsId)
        {
            News news = this.unitOfWork.NewsRepository.Get(newsId);
            if (news == null)
                return false;

            news.Picture = File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, @"Resources\", "defaultNewsPicture.png"));
            this.unitOfWork.Complete();
            return true;
        }

        public NewsDto Get(int newsId)
        {
            News news = this.unitOfWork.NewsRepository.Get(newsId);
            if (news == null)
                return (NewsDto)null;
            return new NewsDto
            {
                NewsId = news.NewsId,
                UserId = news.UserId,
                Title = news.Title,
                Description = news.Description,
                Date = news.Date,
                Picture = news.Picture
            };
        }

        public List<NewsDto> Get()
        {
            return this.unitOfWork.NewsRepository.Get()
                .Select(news => new NewsDto
                {
                    NewsId = news.NewsId,
                    UserId = news.UserId,
                    Title = news.Title,
                    Description = news.Description,
                    Date = news.Date,
                    Picture = news.Picture
                })
                .OrderByDescending(news => news.Date)
                .ToList();
        }

        public NewsDto Post(PostNewsDto postNews)
        {
            if (postNews == null)
                return (NewsDto)null;

            News news = new News
            {
                UserId = postNews.UserId,
                Title = postNews.Title,
                Description = postNews.Description,
                Date = DateTime.Now,
                Picture = File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, @"Resources\", "defaultNewsPicture.png"))
            };

            this.unitOfWork.NewsRepository.Add(news);
            this.unitOfWork.Complete();
            return new NewsDto
            {
                NewsId = news.NewsId,
                UserId = news.UserId,
                Title = news.Title,
                Description = news.Description,
                Date = news.Date,
                Picture = news.Picture
            };
        }

        public NewsDto Put(int newsId, PutNewsDto putNews)
        {
            News news = this.unitOfWork.NewsRepository.Get(newsId);
            if (news == null)
                return (NewsDto)null;

            if(putNews == null)
                return (NewsDto)null;

            news.Title = putNews.Title;
            news.Description = putNews.Description;
            this.unitOfWork.Complete();
            return new NewsDto
            {
                NewsId = news.NewsId,
                UserId = news.UserId,
                Title = news.Title,
                Description = news.Description,
                Date = news.Date,
                Picture = news.Picture
            };
        }
    }
}
