using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Employee,Admin")]
        [HttpPost]
        public CelebritieDto Post(PostCelebritieDto dto)
            => this.celebritieBll.Post(dto);

        [Authorize(Roles = "Employee,Admin")]
        [HttpPut("{celebritieId}")]
        public CelebritieDto Put(int celebritieId, [FromBody] PutCelebritieDto dto)
            => this.celebritieBll.Put(celebritieId, dto);

        [Authorize(Roles = "Employee,Admin")]
        [HttpDelete("{celebritieId}")]
        public bool Delete(int celebritieId)
            => this.celebritieBll.Delete(celebritieId);

        [Authorize(Roles = "Employee,Admin")]
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

        [Authorize(Roles = "Employee,Admin")]
        [HttpDelete("deletePicture/{newsId}")]
        public bool DeletePicture(int newsId)
            => this.celebritieBll.DeletePicture(newsId);

        [HttpGet("director/{celebritieId}")]
        public List<ProductionDto> DirectorIn(int celebritieId)
            => this.celebritieBll.DirectorIn(celebritieId);

        [HttpGet("screenwriter/{celebritieId}")]
        public List<ProductionDto> ScreenwriterIn(int celebritieId)
            => this.celebritieBll.ScreenwriterIn(celebritieId);

        [HttpGet("actor/{celebritieId}")]
        public List<ProductionDto> ActorIn(int celebritieId)
            => this.celebritieBll.ActorIn(celebritieId);
    }
}