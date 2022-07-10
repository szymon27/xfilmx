using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.BLL.Interfaces;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductionsController : ControllerBase
    {
        private readonly IProductionBll productionBll;

        public ProductionsController(IProductionBll productionBll)
        {
            this.productionBll = productionBll;
        }

        [HttpGet("{productionId}")]
        public ProductionDto Get(int productionId)
            => this.productionBll.Get(productionId);

        [HttpGet]
        public List<ProductionDto> Get()
            => this.productionBll.Get();

        [HttpGet("films")]
        public List<ProductionDto> GetFilms()
            => this.productionBll.GetFilms();

        [HttpGet("series")]
        public List<ProductionDto> GetSeries()
            => this.productionBll.GetSeries();

        [HttpPost]
        public ProductionDto Post(PostProductionDto postProduction)
            => this.productionBll.Post(postProduction);

        [HttpPut("{productionId}")]
        public ProductionDto Put(int productionId, [FromBody] PutProductionDto putProduction)
            => this.productionBll.Put(productionId, putProduction);

        [HttpPut("changePicture/{productionId}")]
        public bool ChangePicture(int productionId)
        {
            var picture = HttpContext.Request.Form.Files["Picture"];
            if (picture == null)
                return this.productionBll.ChangePicture(productionId,
                    System.IO.File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, @"Resources\", "defaultProductionPicture.png")));

            MemoryStream memoryStream = new MemoryStream();
            picture.CopyTo(memoryStream);
            return this.productionBll.ChangePicture(productionId, memoryStream.ToArray());
        }

        [HttpDelete("deletePicture/{productionId}")]
        public bool DeletePicture(int productionId)
            => this.productionBll.DeletePicture(productionId);

        [HttpDelete("{productionId}")]
        public bool Delete(int productionId)
            => this.productionBll.Delete(productionId);

        [HttpGet("countries/{productionId}")]
        public List<CountryDto> GetCountries(int productionId)
            => this.productionBll.GetCountries(productionId);

        [HttpPut("countries/{productionId}")]
        public bool AddCountry(int productionId, [FromBody] int countryId)
            => this.productionBll.AddCountry(productionId, countryId);

        [HttpDelete("countries/{productionId}/{countryId}")]
        public bool DeleteCountry(int productionId, int countryId)
            => this.productionBll.DeleteCountry(productionId, countryId);
    }
}
