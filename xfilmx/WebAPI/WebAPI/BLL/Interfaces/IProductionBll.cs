using WebAPI.DTO;

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
    }
}
