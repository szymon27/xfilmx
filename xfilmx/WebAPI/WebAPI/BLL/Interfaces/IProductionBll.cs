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
    }
}
