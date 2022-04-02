using xfilmx.Models;

namespace xfilmx.BL
{
    public interface IProduction
    {
        public Production Add(Production productionId);
        public Production Change(int productionId, bool isSerie, string title, DateTime beginData,
                                DateTime? endDate, int duration, string description, byte[] picture);
        public Production Delete(int productionId);           
        public Production Get(int productionId);
        public IEnumerable<Production> Get();

        public ProductionCountry AddCountry(int productionId, int countryId);
        public bool DeleteCountry(int productionId, int countryId);

        public ProductionGenre AddGenre(int productionId, int genreId);
        public bool DeleteGenre(int productionId, int genreId);

        public ProductionRate AddRate(int productionId, int userId, Stars stars);
        public ProductionRate ChangeRate(int productionId, int userId, Stars stars);
        public bool DeleteRate(int productionId, int userId);

        public ProductionComment AddComment(int productionId, int userId, string comment);
        public ProductionComment ChangeComment(int productionCommentId, string comment);
        public bool DeleteComment(int productionCommentId);

        public ProductionEpisod AddEpisod(ProductionEpisod productionEpisod);
        public IEnumerable<ProductionEpisod> AddEpisods(int productionId, ICollection<Tuple<int, int, string>> espids);
        public ProductionEpisod ChangeEpisod(int productionEpisodId, int season, int episod, string title);
        public bool DeleteEpisod(int productionEpisodId);
        public bool DeleteSeason(int productionId, int season);

        public void AddTrailer(int productionId, string link);
        public bool DeleteTrailer(int productionTrailerId);
        public IEnumerable<ProductionTrailer> GetTrailers(int productionId);

        public void AddPicture(int productionId, byte[] picture);
        public bool DeletePicture(int productionPictureId);
        public IEnumerable<ProductionPicture> GetPictures(int productionId);

        public IEnumerable<Celebritie> AddActors(int productionId, ICollection<int> celebritieIds);
        public bool DeleteActor(int productionId, int celebritieId);
        public IEnumerable<Celebritie> GetActors(int productionId);

        public IEnumerable<Celebritie> AddScreenwriters(int productionId, ICollection<int> celebritieIds);
        public bool DeleteSccreenwriter(int productionId, int celebritieId);
        public IEnumerable<Celebritie> GetScreenwriters(int productionId);

        public IEnumerable<Celebritie> AddDirectors(int productionId, ICollection<int> celebritieIds);
        public bool DeleteDirector(int productionId, int celebritieId);
        public IEnumerable<Celebritie> GetDirectors(int productionId);


    }
}
