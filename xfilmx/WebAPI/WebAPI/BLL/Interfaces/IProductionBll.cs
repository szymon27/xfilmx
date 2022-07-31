using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.BLL.Interfaces
{
    public interface IProductionBll
    {
        public ProductionDto Get(int productionId);
        public List<ProductionDto> Get();
        public List<ProductionDto> GetFilms();
        public List<ProductionDto> GetSeries();

        public ProductionDto Post(PostProductionDto postProduction);
        public ProductionDto Put(int productionId, PutProductionDto putProduction);

        public bool ChangePicture(int productionId, byte[] picture);
        public bool DeletePicture(int productionId);

        public bool Delete(int productionId);

        public List<CountryDto> GetCountries(int productionId);
        public bool AddCountry(int productionId, int countryId);
        public bool DeleteCountry(int productionId, int countryId);

        public List<GenreDto> GetGenres(int productionId);
        public bool AddGenre(int productionId, int genreId);
        public bool DeleteGenre(int productionId, int genreId);

        public List<Tuple<CelebritieDto, string>> GetActors(int productionId);
        public bool AddActor(int productionId, int celebritieId, string character);
        public bool DeleteActor(int productionId, int celebritieId);

        public List<CelebritieDto> GetDirectors(int productionId);
        public bool AddDirector(int productionId, int celebritieId);
        public bool DeleteDirector(int productionId, int celebritieId);

        public List<CelebritieDto> GetScreenwriters(int productionId);
        public bool AddScreenwriter(int productionId, int celebritieId);
        public bool DeleteScreenwriter(int productionId, int celebritieId);

        public List<ProductionCelebritiesDto> GetCelebrities(int productionId);

        public List<SeasonDto> GetSeasons(int productionId);
        public bool AddEpisod(int productionId, NewEpisodDto newEpisod);
        public bool DeleteEpisod(int productionId, int season, int episod);
        public bool EditEpisod(int productionId, int season, int episod, string title);
        public bool DeleteSeason(int productionId, int season);

        public ProductionPicture AddToGallery(int productionId, byte[] picture);
        public bool DeleteFromGallery(int pictureId);
        public List<ProductionPictureDto> GetGallery(int productionId);

        public ProductionTrailer AddTrailer(int productionId, string link);
        public bool DeleteTrailer(int trailerId);
        public List<ProductionTrailerDto> GetTrailers(int productionId);

        public bool AddRate(int productionId, int userId, int rate);
        public bool DeleteRate(int productionId, int userId);
        public int? GetRate(int productionId, int userId);

        public CommentDto AddComment(int productionId, int userId, string comment);
        public bool DeleteComment(int commentId);
        public List<CommentDto> GetComments(int productionId);

        public List<ProductionWatchDto> GetToWatchProductions(int userId);
        public List<ProductionWatchDto> GetWatchedProductions(int userId);
        public bool AddPoductionToWatch(int productionId, int userId, int stauts);
        public bool DeleteProductionFromWatch(int productionId, int userId);
        public int GetProductionStatus(int productionId, int userId);
    }
}
