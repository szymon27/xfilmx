using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.BLL.Interfaces;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CelebritiesController : ControllerBase
    {
        private readonly ICelebritieBll celebritieBll;

        public CelebritiesController(ICelebritieBll celebritieBll)
        {
            this.celebritieBll = celebritieBll;
        }

        [HttpGet("{celebritieID}")]
        public CelebritieDto Get(int celebritieId)
            => this.celebritieBll.Get(celebritieId);

        [HttpGet]
        public List<CelebritieDto> Get()
            => this.celebritieBll.Get();

        [HttpPost]
        public CelebritieDto Post(PostCelebritieDto dto)
            => this.celebritieBll.Post(dto);

        [HttpPut("{celebritieId}")]
        public CelebritieDto Put(int celebritieId, [FromBody] PutCelebritieDto dto)
            => this.celebritieBll.Put(celebritieId, dto);

        [HttpDelete("{celebritieId}")]
        public bool Delete(int celebritieId)
            => this.celebritieBll.Delete(celebritieId);

        [HttpPut("changePicture/{celebritieId}")]
        public bool ChangePicture(int celebritieId)
        {
            var picture = HttpContext.Request.Form.Files["Picture"];
            if (picture == null)
                return this.celebritieBll.ChangePicture(celebritieId,
                    System.IO.File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, @"Resources\", "defaultNewsPicture.png")));

            MemoryStream memoryStream = new MemoryStream();
            picture.CopyTo(memoryStream);
            return this.celebritieBll.ChangePicture(celebritieId, memoryStream.ToArray());
        }

        [HttpDelete("deletePicture/{newsId}")]
        public bool DeletePicture(int newsId)
            => this.celebritieBll.DeletePicture(newsId);
    }
}