﻿using Microsoft.AspNetCore.Http;
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

        [HttpGet("genres/{productionId}")]
        public List<GenreDto> GetGenres(int productionId)
            => this.productionBll.GetGenres(productionId);

        [HttpPut("genres/{productionId}")]
        public bool AddGenres(int productionId, [FromBody] int genreId)
            => this.productionBll.AddGenre(productionId, genreId);

        [HttpDelete("genres/{productionId}/{genreId}")]
        public bool DeleteGenre(int productionId, int genreId)
            => this.productionBll.DeleteGenre(productionId, genreId);

        [HttpGet("actors/{productionId}")]
        public List<Tuple<CelebritieDto, string>> GetActors(int productionId)
            => this.productionBll.GetActors(productionId);

        [HttpPut("actors/{productionId}/{celebritieId}")]
        public bool AddActor(int productionId, int celebritieId, [FromBody] string character)
            => this.productionBll.AddActor(productionId, celebritieId, character);

        [HttpDelete("actors/{productionId}/{celebritieId}")]
        public bool DeleteActor(int productionId, int celebritieId)
            => this.productionBll.DeleteActor(productionId, celebritieId);

        [HttpGet("directors/{productionId}")]
        public List<CelebritieDto> GetDirectors(int productionId)
            => this.productionBll.GetDirectors(productionId);

        [HttpPut("directors/{productionId}")]
        public bool AddDirector(int productionId, [FromBody] int celebritieId)
            => this.productionBll.AddDirector(productionId, celebritieId);

        [HttpDelete("directors/{productionId}/{celebritieId}")]
        public bool DeleteDirector(int productionId, int celebritieId)
            => this.productionBll.DeleteDirector(productionId, celebritieId);

        [HttpGet("screenwriters/{productionId}")]
        public List<CelebritieDto> GetScreenwriters(int productionId)
            => this.productionBll.GetScreenwriters(productionId);

        [HttpPut("screenwriters/{productionId}")]
        public bool AddScreenwriter(int productionId, [FromBody] int celebritieId)
            => this.productionBll.AddScreenwriter(productionId, celebritieId);

        [HttpDelete("screenwriters/{productionId}/{celebritieId}")]
        public bool DeleteScreenwriter(int productionId, int celebritieId)
            => this.productionBll.DeleteScreenwriter(productionId, celebritieId);

        [HttpGet("celebrities/{productionId}")]
        public List<ProductionCelebritiesDto> GetCelebrities(int productionId)
            => this.productionBll.GetCelebrities(productionId);
    }
}
