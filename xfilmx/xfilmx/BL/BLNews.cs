using xfilmx.DAL;
using xfilmx.Models;

namespace xfilmx.BL
{
    public class BLNews : INews
    {
        private readonly IUnitOfWork unitOfWork;

        public BLNews(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public News Add(News news)
        {
            if (news == null)
                throw new ArgumentNullException("invalid news");

            this.unitOfWork.NewsRepository.Add(news);
            this.unitOfWork.Complete();
            return news;
        }

        public bool ChangeContent(int newsId, string title, string description, byte[] picture)
        {
            if (newsId <= 0)
                throw new ArgumentException("invalid news id");

            News news = this.Get(newsId);
            if (news == null)
                throw new ArgumentNullException("invalid news");

            news.Title = title;
            news.Description = description;

            this.unitOfWork.Complete();
            return true;
        }

        public bool Delete(int newsId)
        {
            if (newsId <= 0)
                throw new ArgumentException("invalid news id");

            bool removed = this.unitOfWork.NewsRepository.Delete(newsId);
            if(removed)
            this.unitOfWork.Complete();

            return removed;
        }

        public News Get(int newsId)
        {
            if (newsId <= 0)
                throw new ArgumentException("invalid news id");

            return this.unitOfWork.NewsRepository.Get(newsId);
        }

        public IEnumerable<News> Get()
        {
            return this.unitOfWork.NewsRepository.Get();
        }
    }
}
