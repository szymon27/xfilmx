using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.BLL.Interfaces;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsBll newsBll;

        public NewsController(INewsBll newsBll)
        {
            this.newsBll = newsBll;
        }

        [HttpGet("{newsId}")]
        public NewsDto Get(int newsId)
            => this.newsBll.Get(newsId);

        [HttpGet]
        public List<NewsDto> Get()
            => this.newsBll.Get();

        [HttpPost]
        public NewsDto Post(PostNewsDto postNews)
            => this.newsBll.Post(postNews);

        [HttpPut("{newsId}")]
        public NewsDto Put(int newsId, [FromBody] PutNewsDto putNews)
            => this.newsBll.Put(newsId, putNews);

        [HttpDelete("{newsId}")]
        public bool Delete(int newsId)
            => this.newsBll.Delete(newsId);

        [HttpPut("changePicture/{newsId}")]
        public bool ChangePicture(int newsId)
        {
            var picture = HttpContext.Request.Form.Files["Picture"];
            if (picture == null)
                return this.newsBll.ChangePicture(newsId,
                    System.IO.File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, @"Resources\", "defaultNewsPicture.png")));

            MemoryStream memoryStream = new MemoryStream();
            picture.CopyTo(memoryStream);
            return this.newsBll.ChangePicture(newsId, memoryStream.ToArray());
        }

        [HttpDelete("deletePicture/{newsId}")]
        public bool DeletePicture(int newsId)
            => this.newsBll.DeletePicture(newsId);
    }
}