using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Employee,Admin")]
        [HttpPost]
        public NewsDto Post(PostNewsDto postNews)
            => this.newsBll.Post(postNews);

        [Authorize(Roles = "Employee,Admin")]
        [HttpPut("{newsId}")]
        public NewsDto Put(int newsId, [FromBody] PutNewsDto putNews)
            => this.newsBll.Put(newsId, putNews);

        [Authorize(Roles = "Employee,Admin")]
        [HttpDelete("{newsId}")]
        public bool Delete(int newsId)
            => this.newsBll.Delete(newsId);

        [Authorize(Roles = "Employee,Admin")]
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

        [Authorize(Roles = "Employee,Admin")]
        [HttpDelete("deletePicture/{newsId}")]
        public bool DeletePicture(int newsId)
            => this.newsBll.DeletePicture(newsId);
    }
}