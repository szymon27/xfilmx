using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.BLL.Interfaces;
using WebAPI.DTO;
using WebAPI.Models;

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

        [Authorize(Roles = "Employee,Admin")]
        [HttpPost]
        public ProductionDto Post(PostProductionDto postProduction)
            => this.productionBll.Post(postProduction);

        [Authorize(Roles = "Employee,Admin")]
        [HttpPut("{productionId}")]
        public ProductionDto Put(int productionId, [FromBody] PutProductionDto putProduction)
            => this.productionBll.Put(productionId, putProduction);

        [Authorize(Roles = "Employee,Admin")]
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

        [Authorize(Roles = "Employee,Admin")]
        [HttpDelete("deletePicture/{productionId}")]
        public bool DeletePicture(int productionId)
            => this.productionBll.DeletePicture(productionId);

        [Authorize(Roles = "Employee,Admin")]
        [HttpDelete("{productionId}")]
        public bool Delete(int productionId)
            => this.productionBll.Delete(productionId);

        [HttpGet("countries/{productionId}")]
        public List<CountryDto> GetCountries(int productionId)
            => this.productionBll.GetCountries(productionId);

        [Authorize(Roles = "Employee,Admin")]
        [HttpPut("countries/{productionId}")]
        public bool AddCountry(int productionId, [FromBody] int countryId)
            => this.productionBll.AddCountry(productionId, countryId);

        [Authorize(Roles = "Employee,Admin")]
        [HttpDelete("countries/{productionId}/{countryId}")]
        public bool DeleteCountry(int productionId, int countryId)
            => this.productionBll.DeleteCountry(productionId, countryId);

        [HttpGet("genres/{productionId}")]
        public List<GenreDto> GetGenres(int productionId)
            => this.productionBll.GetGenres(productionId);

        [Authorize(Roles = "Employee,Admin")]
        [HttpPut("genres/{productionId}")]
        public bool AddGenres(int productionId, [FromBody] int genreId)
            => this.productionBll.AddGenre(productionId, genreId);

        [Authorize(Roles = "Employee,Admin")]
        [HttpDelete("genres/{productionId}/{genreId}")]
        public bool DeleteGenre(int productionId, int genreId)
            => this.productionBll.DeleteGenre(productionId, genreId);

        [HttpGet("actors/{productionId}")]
        public List<Tuple<CelebritieDto, string>> GetActors(int productionId)
            => this.productionBll.GetActors(productionId);

        [Authorize(Roles = "Employee,Admin")]
        [HttpPut("actors/{productionId}/{celebritieId}")]
        public bool AddActor(int productionId, int celebritieId, [FromBody] string character)
            => this.productionBll.AddActor(productionId, celebritieId, character);

        [Authorize(Roles = "Employee,Admin")]
        [HttpDelete("actors/{productionId}/{celebritieId}")]
        public bool DeleteActor(int productionId, int celebritieId)
            => this.productionBll.DeleteActor(productionId, celebritieId);

        [HttpGet("directors/{productionId}")]
        public List<CelebritieDto> GetDirectors(int productionId)
            => this.productionBll.GetDirectors(productionId);

        [Authorize(Roles = "Employee,Admin")]
        [HttpPut("directors/{productionId}")]
        public bool AddDirector(int productionId, [FromBody] int celebritieId)
            => this.productionBll.AddDirector(productionId, celebritieId);

        [Authorize(Roles = "Employee,Admin")]
        [HttpDelete("directors/{productionId}/{celebritieId}")]
        public bool DeleteDirector(int productionId, int celebritieId)
            => this.productionBll.DeleteDirector(productionId, celebritieId);

        [HttpGet("screenwriters/{productionId}")]
        public List<CelebritieDto> GetScreenwriters(int productionId)
            => this.productionBll.GetScreenwriters(productionId);

        [Authorize(Roles = "Employee,Admin")]
        [HttpPut("screenwriters/{productionId}")]
        public bool AddScreenwriter(int productionId, [FromBody] int celebritieId)
            => this.productionBll.AddScreenwriter(productionId, celebritieId);

        [Authorize(Roles = "Employee,Admin")]
        [HttpDelete("screenwriters/{productionId}/{celebritieId}")]
        public bool DeleteScreenwriter(int productionId, int celebritieId)
            => this.productionBll.DeleteScreenwriter(productionId, celebritieId);

        [HttpGet("celebrities/{productionId}")]
        public List<ProductionCelebritiesDto> GetCelebrities(int productionId)
            => this.productionBll.GetCelebrities(productionId);

        [HttpGet("seasons/{productionId}")]
        public List<SeasonDto> GetSeasons(int productionId)
            => this.productionBll.GetSeasons(productionId);

        [Authorize(Roles = "Employee,Admin")]
        [HttpPost("episods/{productionId}/")]
        public bool AddEpisod(int productionId, [FromBody] NewEpisodDto newEpisod)
            => this.productionBll.AddEpisod(productionId, newEpisod);

        [Authorize(Roles = "Employee,Admin")]
        [HttpDelete("episods/{productionId}/{season}/{episod}")]
        public bool DeleteEpisod(int productionId, int season, int episod)
            => this.productionBll.DeleteEpisod(productionId, season, episod);

        [Authorize(Roles = "Employee,Admin")]
        [HttpPut("episods/{productionId}/{season}/{episod}")]
        public bool EditEpisod(int productionId, int season, int episod, [FromBody] string title)
            => this.productionBll.EditEpisod(productionId, season, episod, title);

        [Authorize(Roles = "Employee,Admin")]
        [HttpDelete("seasons/{productionId}/{season}")]
        public bool DeleteSeason(int productionId, int season)
            => this.productionBll.DeleteSeason(productionId, season);

        [Authorize(Roles = "Employee,Admin")]
        [HttpPost("pictures/{productionId}")]
        public ProductionPicture AddToGallery(int productionId)
        {
            var picture = HttpContext.Request.Form.Files["Picture"];
            if (picture == null)
                return this.productionBll.AddToGallery(productionId,
                    System.IO.File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, @"Resources\", "defaultProductionPicture.png")));

            MemoryStream memoryStream = new MemoryStream();
            picture.CopyTo(memoryStream);
            return this.productionBll.AddToGallery(productionId, memoryStream.ToArray());
        }

        [Authorize(Roles = "Employee,Admin")]
        [HttpDelete("pictures/{pictureId}")]
        public bool DeleteFromGallery(int pictureId)
            => this.productionBll.DeleteFromGallery(pictureId);

        [HttpGet("pictures/{productionId}")]
        public List<ProductionPictureDto> GetGallery(int productionId)
            => this.productionBll.GetGallery(productionId);

        [Authorize(Roles = "Employee,Admin")]
        [HttpPost("trailers/{productionId}")]
        public ProductionTrailer AddTrailer(int productionId, [FromBody] string link)
            => this.productionBll.AddTrailer(productionId, link);

        [Authorize(Roles = "Employee,Admin")]
        [HttpDelete("trailers/{trailerId}")]
        public bool DeleteTrailer(int trailerId)
            => this.productionBll.DeleteTrailer(trailerId);

        [HttpGet("trailers/{productionId}")]
        public List<ProductionTrailerDto> GetTrailers(int productionId)
            => this.productionBll.GetTrailers(productionId);

        [Authorize]
        [HttpPut("rates/{productionId}/{userId}")]
        public bool AddRate(int productionId, int userId, [FromBody] int rate)
            => this.productionBll.AddRate(productionId, userId, rate);

        [Authorize]
        [HttpDelete("rates/{productionId}/{userId}")]
        public bool DeleteRate(int productionId, int userId)
            => this.productionBll.DeleteRate(productionId, userId);

        [HttpGet("rates/{productionId}/{userId}")]
        public int? GetRate(int productionId, int userId)
            => this.productionBll.GetRate(productionId, userId);

        [Authorize]
        [HttpPut("comments/{productionId}/{userId}")]
        public CommentDto AddComment(int productionId, int userId, [FromBody] string comment)
            => this.productionBll.AddComment(productionId, userId, comment);

        [Authorize(Roles = "Employee,Admin")]
        [HttpDelete("comments/{commentId}")]
        public bool DeleteComment(int commentId)
            => this.productionBll.DeleteComment(commentId);

        [HttpGet("comments/{productionId}")]
        public List<CommentDto> GetComments(int productionId)
            => this.productionBll.GetComments(productionId);

        [HttpGet("toWatchList/{userId}")]
        public List<ProductionWatchDto> GetToWatchProductions(int userId)
            => this.productionBll.GetToWatchProductions(userId);

        [HttpGet("watchedList/{userId}")]
        public List<ProductionWatchDto> GetWatchedProductions(int userId)
            => this.productionBll.GetWatchedProductions(userId);

        [Authorize]
        [HttpPut("watch/{productionId}/{userId}")]
        public bool AddPoductionToWatch(int productionId, int userId, [FromBody] int status)
            => this.productionBll.AddPoductionToWatch(productionId, userId, status);

        [Authorize]
        [HttpDelete("watch/{productionId}/{userId}")]
        public bool DeleteProductionFromWatch(int productionId, int userId)
            => this.productionBll.DeleteProductionFromWatch(productionId, userId);

        [HttpGet("status/{productionId}/{userId}")]
        public int GetProductionStatus(int productionId, int userId)
            => this.productionBll.GetProductionStatus(productionId, userId);
    }
}
