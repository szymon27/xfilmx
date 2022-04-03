using xfilmx.DAL;
using xfilmx.Models;

namespace xfilmx.BL
{
    public class BLProduction : IProduction
    {
        private readonly IUnitOfWork unitOfWork;

        public BLProduction(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Production Add(Production production)
        {
            if (production == null)
                throw new ArgumentException("invalid production");

            this.unitOfWork.ProductionRepository.Add(production);
            this.unitOfWork.Complete();
            return production;
        }

        public IEnumerable<Celebritie> AddActors(int productionId, ICollection<int> celebritieIds)
        {
            if (productionId <= 0)
                throw new ArgumentException("invalid production id");

            Production production = this.Get(productionId);
            if (production == null)
                throw new ArgumentException("invalid production");

            IEnumerable<ProductionActor> productionActors = celebritieIds
                .Select(cId => new ProductionActor { ProductionId = productionId, CelebritieId = cId });
            foreach (ProductionActor pa in productionActors)
                this.unitOfWork.ProductionActorRepository.Add(pa);
            this.unitOfWork.Complete();

            return this.unitOfWork.ProductionActorRepository.Get()
                .Where(pa => pa.ProductionId == productionId)
                .Join(this.unitOfWork.CelebritieRepository.Get(),
                pa => pa.CelebritieId,
                c => c.CelebritieId,
                (pa, c) => c);
        }

        public ProductionComment AddComment(int productionId, int userId, string comment)
        {
            if (productionId <= 0)
                throw new ArgumentException("invalid production id");

            if (userId <= 0)
                throw new ArgumentException("invalid user id");

            Production production = this.Get(productionId);
            if (production == null)
                throw new ArgumentException("invalid production");

            User user = this.unitOfWork.UserRepository.Get(userId);
            if (user == null)
                throw new ArgumentException("invalid user");

            ProductionComment productionComment = new ProductionComment()
            {
                ProductionId = productionId,
                UserId = userId,
                Comment = comment
            };

            this.unitOfWork.ProductionCommentRepository.Add(productionComment);
            this.unitOfWork.Complete();
            return productionComment;
        }

        public ProductionCountry AddCountry(int productionId, int countryId)
        {
            if (productionId <= 0)
                throw new ArgumentException("invalid production id");

            if (countryId <= 0)
                throw new ArgumentException("invalid country id");

            Production production = this.Get(productionId);
            if (production == null)
                throw new ArgumentException("invalid production");

            Country country = this.unitOfWork.CountryRepository.Get(countryId);
            if (country == null)
                throw new ArgumentException("invalid country");

            ProductionCountry productionCountry = new ProductionCountry
            {
                ProductionId = productionId,
                CountryId = countryId
            };

            this.unitOfWork.ProductionCountryRepository.Add(productionCountry);
            this.unitOfWork.Complete();
            return productionCountry;
        }

        public IEnumerable<Celebritie> AddDirectors(int productionId, ICollection<int> celebritieIds)
        {
            if (productionId <= 0)
                throw new ArgumentException("invalid production id");

            Production production = this.Get(productionId);
            if (production == null)
                throw new ArgumentException("invalid production");

            IEnumerable<ProductionDirector> productionDirectors = celebritieIds
                .Select(cId => new ProductionDirector { ProductionId = productionId, CelebritieId = cId });
            foreach (ProductionDirector pd in productionDirectors)
                this.unitOfWork.ProductionDirectorRepository.Add(pd);
            this.unitOfWork.Complete();

            return this.unitOfWork.ProductionDirectorRepository.Get()
                .Where(pd => pd.ProductionId == productionId)
                .Join(this.unitOfWork.CelebritieRepository.Get(),
                pd => pd.CelebritieId,
                c => c.CelebritieId,
                (pd, c) => c);
        }

        public ProductionEpisod AddEpisod(ProductionEpisod productionEpisod)
        {
            if (productionEpisod == null)
                throw new ArgumentException("invalid production episod");

            this.unitOfWork.ProductionEpisodRepository.Add(productionEpisod);
            this.unitOfWork.Complete();
            return productionEpisod;
        }

        public IEnumerable<ProductionEpisod> AddEpisods(int productionId, ICollection<Tuple<int, int, string>> episods)
        {
            if (productionId <= 0)
                throw new ArgumentException("invalid production id");

            Production production = this.Get(productionId);
            if (production == null)
                throw new ArgumentException("invalid production");

            IEnumerable<ProductionEpisod> productionEpisods = episods
                .Select(e => new ProductionEpisod()
                {
                    ProductionId = productionId,
                    Season = e.Item1,
                    Episod = e.Item2,
                    Title = e.Item3
                });
            foreach (ProductionEpisod productionEpisod in productionEpisods)
                this.unitOfWork.ProductionEpisodRepository.Add(productionEpisod);
            this.unitOfWork.Complete();
            return productionEpisods;
        }

        public ProductionGenre AddGenre(int productionId, int genreId)
        {
            if (productionId <= 0)
                throw new ArgumentException("invalid production id");

            if (genreId <= 0)
                throw new ArgumentException("invalid genre id");

            Production production = this.Get(productionId);
            if (production == null)
                throw new ArgumentException("invalid production");

            Genre genre = this.unitOfWork.GenreRepository.Get(genreId);
            if (genre == null)
                throw new ArgumentException("invalid genre");

            ProductionGenre productionGenre = new ProductionGenre
            {
                ProductionId = productionId,
                GenreId = genreId
            };

            this.unitOfWork.ProductionGenreRepository.Add(productionGenre);
            this.unitOfWork.Complete();
            return productionGenre;
        }

        public void AddPicture(int productionId, byte[] picture)
        {
            if (productionId <= 0)
                throw new ArgumentException("invalid production id");

            Production production = this.Get(productionId);
            if (production == null)
                throw new ArgumentException("invalid production");

            if (picture == null || picture.Length == 0)
                throw new ArgumentException("invalid picture");

            ProductionPicture productionPicture = new ProductionPicture()
            {
                ProductionId = productionId,
                Picture = picture
            };

            this.unitOfWork.ProductionPictureRepository.Add(productionPicture);
            this.unitOfWork.Complete();
        }

        public ProductionRate AddRate(int productionId, int userId, Stars stars)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Celebritie> AddScreenwriters(int productionId, ICollection<int> celebritieIds)
        {
            throw new NotImplementedException();
        }

        public void AddTrailer(int productionId, string link)
        {
            throw new NotImplementedException();
        }

        public Production Change(int productionId, bool isSerie, string title,
            DateTime beginData, DateTime? endDate, int duration, string description, byte[] picture)
        {
            throw new NotImplementedException();
        }

        public ProductionComment ChangeComment(int productionCommentId, string comment)
        {
            throw new NotImplementedException();
        }

        public ProductionEpisod ChangeEpisod(int productionEpisodId, int season, int episod, string title)
        {
            throw new NotImplementedException();
        }

        public ProductionRate ChangeRate(int productionId, int userId, Stars stars)
        {
            throw new NotImplementedException();
        }

        public Production Delete(int productionId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteActor(int productionId, int celebritieId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteComment(int productionCommentId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCountry(int productionId, int countryId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDirector(int productionId, int celebritieId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEpisod(int productionEpisodId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteGenre(int productionId, int genreId)
        {
            throw new NotImplementedException();
        }

        public bool DeletePicture(int productionPictureId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRate(int productionId, int userId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSccreenwriter(int productionId, int celebritieId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSeason(int productionId, int season)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTrailer(int productionTrailerId)
        {
            throw new NotImplementedException();
        }

        public Production Get(int productionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Production> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Celebritie> GetActors(int productionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Celebritie> GetDirectors(int productionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductionPicture> GetPictures(int productionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Celebritie> GetScreenwriters(int productionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductionTrailer> GetTrailers(int productionId)
        {
            throw new NotImplementedException();
        }
    }
}
