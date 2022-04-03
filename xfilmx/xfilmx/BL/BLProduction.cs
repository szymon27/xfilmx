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

            ProductionRate productionRate = new ProductionRate()
            {
                ProductionId = productionId,
                UserId = userId,
                Stars = stars
            };

            this.unitOfWork.ProductionRateRepository.Add(productionRate);
            this.unitOfWork.Complete();
            return productionRate;
        }

        public IEnumerable<Celebritie> AddScreenwriters(int productionId, ICollection<int> celebritieIds)
        {
            if (productionId <= 0)
                throw new ArgumentException("invalid production id");

            Production production = this.Get(productionId);
            if (production == null)
                throw new ArgumentException("invalid production");

            IEnumerable<ProductionScreenwriter> productionScreenwriters = celebritieIds
                .Select(cId => new ProductionScreenwriter { ProductionId = productionId, CelebritieId = cId });
            foreach (ProductionScreenwriter ps in productionScreenwriters)
                this.unitOfWork.ProductionScreenwriterRepository.Add(ps);
            this.unitOfWork.Complete();

            return this.unitOfWork.ProductionActorRepository.Get()
                .Where(ps => ps.ProductionId == productionId)
                .Join(this.unitOfWork.CelebritieRepository.Get(),
                ps => ps.CelebritieId,
                c => c.CelebritieId,
                (ps, c) => c);
        }

        public void AddTrailer(int productionId, string link)
        {
            if (productionId <= 0)
                throw new ArgumentException("invalid production id");

            Production production = this.Get(productionId);
            if (production == null)
                throw new ArgumentException("invalid production");

            ProductionTrailer productionTrailer = new ProductionTrailer()
            {
                ProductionId = productionId,
                Link = link
            };
            this.unitOfWork.ProductionTrailerRepository.Add(productionTrailer);
            this.unitOfWork.Complete();

        }

        public Production Change(int productionId, bool isSerie, string title,
            DateTime beginData, DateTime? endDate, int duration, string description, byte[] picture)
        {
            if (productionId <= 0)
                throw new ArgumentException("invalid production id");

            Production production = this.Get(productionId);
            if (production == null)
                throw new ArgumentException("invalid production");

            production.IsSerie = isSerie;
            production.Title = title;
            production.BeginDate = beginData;
            production.EndDate = endDate;
            production.Duration = duration;
            production.Description = description;
            production.Picture = picture;

            this.unitOfWork.Complete();

            return production;
        }

        public ProductionComment ChangeComment(int productionCommentId, string comment)
        {
            if (productionCommentId <= 0)
                throw new ArgumentException("invalid comment id");

            ProductionComment productionComment = this.unitOfWork.ProductionCommentRepository.Get(productionCommentId);
            if (productionComment == null)
                throw new ArgumentNullException("invalid comment");

            productionComment.Comment= comment;
            this.unitOfWork.Complete();

            return productionComment;
        }

        public ProductionEpisod ChangeEpisod(int productionEpisodId, int season, int episod, string title)
        {
            if (productionEpisodId <= 0)
                throw new ArgumentException("invalid episod id");

            ProductionEpisod productionEpisod = this.unitOfWork.ProductionEpisodRepository.Get(productionEpisodId);
            if (productionEpisod == null)
                throw new ArgumentNullException("invalid episod");

            productionEpisod.Season = season;
            productionEpisod.Episod = episod;
            productionEpisod.Title = title;
            this.unitOfWork.Complete();

            return productionEpisod;
        }

        public ProductionRate ChangeRate(int productionId, int userId, Stars stars)
        {
            if (productionId <= 0)
                throw new ArgumentException("invalid production id");

            Production production = this.Get(productionId);
            if (production == null)
                throw new ArgumentNullException("invalid production");

            if (userId <= 0)
                throw new ArgumentException("invalid user id");

            ProductionRate productionRate = this.unitOfWork.ProductionRateRepository.Get().First(pr => pr.ProductionId == productionId && pr.UserId == userId);
            if (productionRate == null)
                throw new ArgumentNullException("invalid production rate");

            productionRate.Stars = stars;
            this.unitOfWork.Complete();

            return productionRate;
        }

        public bool Delete(int productionId)
        {
            if (productionId <= 0)
                throw new ArgumentException("invalid production id");

            bool removed = this.Delete(productionId);
            if (removed)
                this.unitOfWork.Complete();

            return removed;
        }

        public bool DeleteActor(int productionId, int celebritieId)
        {
            if (productionId <= 0)
                throw new ArgumentException("invalid production id");

            if (celebritieId <= 0)
                throw new ArgumentException("invalid celebritie id");

            Production production = this.Get(productionId);
            if (production == null)
                throw new ArgumentNullException("invalid production");

            ProductionActor celebritie = production.ProductionActors.First(pa => pa.CelebritieId == celebritieId);
            if (celebritie == null)
                throw new ArgumentNullException("invalid actor");

            bool removed = production.ProductionActors.Remove(celebritie);
            if (removed)
                this.unitOfWork.Complete();

            return removed;
        }

        public bool DeleteComment(int productionCommentId)
        {
            if (productionCommentId <= 0)
                throw new ArgumentException("invalid comment id");

            bool removed = this.unitOfWork.ProductionCommentRepository.Delete(productionCommentId);
            if (removed)
                this.unitOfWork.Complete();

            return removed;
        }

        public bool DeleteCountry(int productionId, int countryId)
        {
            if (productionId <= 0)
                throw new ArgumentException("invalid production id");
            if (countryId <= 0)
                throw new ArgumentException("invalid country id");

            Production production = this.Get(productionId);
            if (production == null)
                throw new ArgumentNullException("invalid production");

            ProductionCountry country = production.ProductionCountries.First(pc => pc.CountryId == countryId);
            if (country == null)
                throw new ArgumentNullException("invalid country");

            bool removed = production.ProductionCountries.Remove(country);
            if (removed)
                this.unitOfWork.Complete();

            return removed;
        }

        public bool DeleteDirector(int productionId, int celebritieId)
        {
            if (productionId <= 0)
                throw new ArgumentException("invalid production id");

            if (celebritieId <= 0)
                throw new ArgumentException("invalid celebritie id");

            Production production = this.Get(productionId);
            if (production == null)
                throw new ArgumentNullException("invalid production");

            ProductionDirector celebritie = production.ProductionDirectors.First(pd => pd.CelebritieId == celebritieId);
            if (celebritie == null)
                throw new ArgumentNullException("invalid director");

            bool removed = production.ProductionDirectors.Remove(celebritie);
            if (removed)
                this.unitOfWork.Complete();

            return removed;
        }

        public bool DeleteEpisod(int productionId, int season, int episod)
        {
            if (productionId <= 0)
                throw new ArgumentException("invalid production id");

            Production production = this.Get(productionId);
            if (production == null)
                throw new ArgumentNullException("invalid production");

            ProductionEpisod productionEpisod = production.ProductionEpisods.First(pe => pe.Season == season && pe.Episod == episod);
            if (productionEpisod == null)
                throw new ArgumentNullException("invalid episode");

            bool removed = production.ProductionEpisods.Remove(productionEpisod);
            if (removed)
                this.unitOfWork.Complete();

            return removed;
        }

        public bool DeleteGenre(int productionId, int genreId)
        {
            if (productionId <= 0)
                throw new ArgumentException("invalid production id");
            if (genreId <= 0)
                throw new ArgumentException("invalid genre id");

            Production production = this.Get(productionId);
            if (production == null)
                throw new ArgumentNullException("invalid production");

            ProductionGenre genre = production.ProductionGenres.First(pg => pg.GenreId == genreId);
            if (genre == null)
                throw new ArgumentNullException("invalid genre");

            bool removed = production.ProductionGenres.Remove(genre);
            if (removed)
                this.unitOfWork.Complete();

            return removed;
        }

        public bool DeletePicture(int productionPictureId)
        {
            if (productionPictureId <= 0)
                throw new ArgumentException("invalid picture id");

            bool removed = this.unitOfWork.ProductionPictureRepository.Delete(productionPictureId);
            if (removed)
                this.unitOfWork.Complete();

            return removed;
        }

        public bool DeleteRate(int productionId, int userId)
        {
            if (productionId <= 0)
                throw new ArgumentException("invalid production id");

            if (userId <= 0)
                throw new ArgumentException("invalid user id");

            Production production = this.Get(productionId);
            if (production == null)
                throw new ArgumentNullException("invalid production");

            ProductionRate productionRate = production.ProductionRates.First(pr => pr.UserId == userId);
            if (productionRate == null)
                throw new ArgumentNullException("invalid rate");

            bool removed = production.ProductionRates.Remove(productionRate);
            if (removed)
                this.unitOfWork.Complete();

            return removed;
        }

        public bool DeleteSccreenwriter(int productionId, int celebritieId)
        {
            if (productionId <= 0)
                throw new ArgumentException("invalid production id");

            if (celebritieId <= 0)
                throw new ArgumentException("invalid celebritie id");

            Production production = this.Get(productionId);
            if (production == null)
                throw new ArgumentNullException("invalid production");

            ProductionScreenwriter celebritie = production.ProductionScreenwriters.First(ps => ps.CelebritieId == celebritieId);
            if (celebritie == null)
                throw new ArgumentNullException("invalid screenwriter");

            bool removed = production.ProductionScreenwriters.Remove(celebritie);
            if (removed)
                this.unitOfWork.Complete();

            return removed;
        }

        public bool DeleteSeason(int productionId, int season)
        {
            if(productionId <= 0)
                throw new ArgumentException("invalid production id");

            Production production = this.Get(productionId);
            if (production == null)
                throw new ArgumentNullException("invalid production");

            IEnumerable<ProductionEpisod> productionEpisods = production.ProductionEpisods.Where(pe => pe.Season == season);

            bool removed = false;

            if (productionEpisods.Any())
            {
                foreach (ProductionEpisod episode in productionEpisods)
                    production.ProductionEpisods.Remove(episode);
                removed = true;
            }
            if (removed)
                this.unitOfWork.Complete();

            return removed;
        }

        public bool DeleteTrailer(int productionTrailerId)
        {
            if (productionTrailerId <= 0)
                throw new ArgumentException("invalid trailer id");

            bool removed = this.unitOfWork.ProductionTrailerRepository.Delete(productionTrailerId);
            if (removed)
                this.unitOfWork.Complete();

            return removed;
        }

        public Production Get(int productionId)
        {
            if (productionId <= 0)
                throw new ArgumentException("invalid production id");

            return this.unitOfWork.ProductionRepository.Get(productionId);
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
