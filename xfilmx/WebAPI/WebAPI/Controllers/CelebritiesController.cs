using Microsoft.AspNetCore.Mvc;
using WebAPI.BLL.Interfaces;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CelebritiesController
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
        public CelebritieDto Put(int celebritieId, PostCelebritieDto dto)
            => this.celebritieBll.Put(celebritieId, dto);

        [HttpDelete("{celebritieId}")]
        public bool Delete(int celebritieId)
            => this.celebritieBll.Delete(celebritieId);
    }
}