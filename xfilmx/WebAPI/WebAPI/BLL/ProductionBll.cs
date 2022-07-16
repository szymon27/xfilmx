using WebAPI.BLL.Interfaces;
using WebAPI.DAL.Interfaces;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.BLL
{
    public class ProductionBll : IProductionBll
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductionBll(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ProductionDto Get(int productionId)
        {
            Production production = this.unitOfWork.ProductionRepository.Get(productionId);
            if (production == null)
                return (ProductionDto)null;

            return new ProductionDto
            {
                IsSerie = production.IsSerie,
                ProductionId = production.ProductionId,
                Title = production.Title,
                Description = production.Description,
                BeginDate = production.BeginDate,
                EndDate = production.EndDate,
                Duration = production.Duration,
                Picture = production.Picture,
                Countries = this.unitOfWork.ProductionCountryRepository.Get().ToList()
                                .Where(pc => pc.ProductionId == productionId)
                                .Join(this.unitOfWork.CountryRepository.Get(),
                                    pc => pc.CountryId,
                                    c => c.CountryId,
                                    (pc, c) => new string(c.Name))
                                .ToList(),
                Genres = this.unitOfWork.ProductionGenreRepository.Get().ToList()
                                .Where(pg => pg.ProductionId == productionId)
                                .Join(this.unitOfWork.GenreRepository.Get(),
                                    pg => pg.GenreId,
                                    g => g.GenreId,
                                    (pg, g) => new string(g.Name))
                                .ToList(),
                Rate = this.unitOfWork.ProductionRateRepository.Get().Where(r => r.ProductionId == productionId).Select(r => r.Stars).DefaultIfEmpty().Average(x => (int)x),
                RateCount = this.unitOfWork.ProductionRateRepository.Get().Where(r => r.ProductionId == productionId).Count()
            };
        }

        public List<ProductionDto> Get()
        {
            return this.unitOfWork.ProductionRepository.Get().ToList().Select(production => new ProductionDto
            {
                ProductionId = production.ProductionId,
                Title = production.Title,
                Description = production.Description,
                Duration = production.Duration,
                IsSerie = production.IsSerie,
                BeginDate = production.BeginDate,
                EndDate = production.EndDate,
                Picture = production.Picture,
                Countries = this.unitOfWork.ProductionCountryRepository.Get().ToList()
                                .Where(pc => pc.ProductionId == production.ProductionId)
                                .Join(this.unitOfWork.CountryRepository.Get(),
                                    pc => pc.CountryId,
                                    c => c.CountryId,
                                    (pc, c) => new string(c.Name))
                                .ToList(),
                Genres = this.unitOfWork.ProductionGenreRepository.Get().ToList()
                                .Where(pg => pg.ProductionId == production.ProductionId)
                                .Join(this.unitOfWork.GenreRepository.Get(),
                                    pg => pg.GenreId,
                                    g => g.GenreId,
                                    (pg, g) => new string(g.Name))
                                .ToList(),
                Rate = this.unitOfWork.ProductionRateRepository.Get().Where(r => r.ProductionId == production.ProductionId).Select(r => r.Stars).DefaultIfEmpty().Average(x => (int)x),
                RateCount = this.unitOfWork.ProductionRateRepository.Get().Where(r => r.ProductionId == production.ProductionId).Count()
            }).ToList();
        }

        public List<ProductionDto> GetFilms()
        {
            return this.unitOfWork.ProductionRepository.Get().ToList().Where(p => p.IsSerie == false).Select(production => new ProductionDto
            {
                ProductionId = production.ProductionId,
                Title = production.Title,
                Description = production.Description,
                Duration = production.Duration,
                IsSerie = production.IsSerie,
                BeginDate = production.BeginDate,
                EndDate = production.EndDate,
                Picture = production.Picture,
                Countries = this.unitOfWork.ProductionCountryRepository.Get().ToList()
                    .Where(pc => pc.ProductionId == production.ProductionId)
                    .Join(this.unitOfWork.CountryRepository.Get(),
                        pc => pc.CountryId,
                        c => c.CountryId,
                        (pc, c) => new string(c.Name))
                    .ToList(),
                Genres = this.unitOfWork.ProductionGenreRepository.Get().ToList()
                    .Where(pg => pg.ProductionId == production.ProductionId)
                    .Join(this.unitOfWork.GenreRepository.Get(),
                        pg => pg.GenreId,
                        g => g.GenreId,
                        (pg, g) => new string(g.Name))
                    .ToList(),
                Rate = this.unitOfWork.ProductionRateRepository.Get().Where(r => r.ProductionId == production.ProductionId).Select(r => r.Stars).DefaultIfEmpty().Average(x => (int)x),
                RateCount = this.unitOfWork.ProductionRateRepository.Get().Where(r => r.ProductionId == production.ProductionId).Count()
            }).ToList();
        }

        public List<ProductionDto> GetSeries()
        {
                return this.unitOfWork.ProductionRepository.Get().ToList().Where(p => p.IsSerie == true).Select(production => new ProductionDto
                {
                    ProductionId = production.ProductionId,
                    Title = production.Title,
                    Description = production.Description,
                    Duration = production.Duration,
                    IsSerie = production.IsSerie,
                    BeginDate = production.BeginDate,
                    EndDate = production.EndDate,
                    Picture = production.Picture,
                    Countries = this.unitOfWork.ProductionCountryRepository.Get().ToList()
                        .Where(pc => pc.ProductionId == production.ProductionId)
                        .Join(this.unitOfWork.CountryRepository.Get(),
                            pc => pc.CountryId,
                            c => c.CountryId,
                            (pc, c) => new string(c.Name))
                        .ToList(),
                    Genres = this.unitOfWork.ProductionGenreRepository.Get().ToList()
                        .Where(pg => pg.ProductionId == production.ProductionId)
                        .Join(this.unitOfWork.GenreRepository.Get(),
                            pg => pg.GenreId,
                            g => g.GenreId,
                            (pg, g) => new string(g.Name))
                        .ToList(),
                    Rate = this.unitOfWork.ProductionRateRepository.Get().Where(r => r.ProductionId == production.ProductionId).Select(r => r.Stars).DefaultIfEmpty().Average(x => (int)x),
                    RateCount = this.unitOfWork.ProductionRateRepository.Get().Where(r => r.ProductionId == production.ProductionId).Count()
                }).ToList();
        }

        public ProductionDto Post(PostProductionDto postProduction)
        {
            if (postProduction == null)
                return (ProductionDto)null;

            Production production = new Production
            {
                IsSerie = postProduction.IsSerie,
                Title = postProduction.Title,
                BeginDate = postProduction.BeginDate,
                EndDate = postProduction.EndDate,
                Duration = postProduction.Duration,
                Description = postProduction.Description,
                Picture = File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, @"Resources\", "defaultProductionPicture.png"))
            };

            this.unitOfWork.ProductionRepository.Add(production);
            this.unitOfWork.Complete();

            return new ProductionDto
            {
                ProductionId = production.ProductionId,
                Title = production.Title,
                Description = production.Description,
                Duration = production.Duration,
                IsSerie = production.IsSerie,
                BeginDate = production.BeginDate,
                EndDate = production.EndDate,
                Picture = production.Picture,
                Countries = this.unitOfWork.ProductionCountryRepository.Get()
                                .Where(pc => pc.ProductionId == production.ProductionId)
                                .Join(this.unitOfWork.CountryRepository.Get(),
                                    pc => pc.CountryId,
                                    c => c.CountryId,
                                    (pc, c) => new string(c.Name))
                                .ToList(),
                Genres = this.unitOfWork.ProductionGenreRepository.Get()
                                .Where(pg => pg.ProductionId == production.ProductionId)
                                .Join(this.unitOfWork.GenreRepository.Get(),
                                    pg => pg.GenreId,
                                    g => g.GenreId,
                                    (pg, g) => new string(g.Name))
                                .ToList(),
                Rate = this.unitOfWork.ProductionRateRepository.Get().Where(r => r.ProductionId == production.ProductionId).Select(r => r.Stars).DefaultIfEmpty().Average(x => (int)x),
                RateCount = this.unitOfWork.ProductionRateRepository.Get().Where(r => r.ProductionId == production.ProductionId).Count()
            };
        }

        public ProductionDto Put(int productionId, PutProductionDto putProduction)
        {
            Production production = this.unitOfWork.ProductionRepository.Get(productionId);
            if (production == null)
                return (ProductionDto)null;

            if (putProduction == null)
                return (ProductionDto)null;

            production.IsSerie = putProduction.IsSerie;
            production.Title = putProduction.Title;
            production.BeginDate = putProduction.BeginDate;
            production.EndDate = putProduction.EndDate;
            production.Duration = putProduction.Duration;
            production.Description = putProduction.Description;
            this.unitOfWork.Complete();
            return new ProductionDto
            {
                ProductionId = production.ProductionId,
                Title = production.Title,
                Description = production.Description,
                Duration = production.Duration,
                IsSerie = production.IsSerie,
                BeginDate = production.BeginDate,
                EndDate = production.EndDate,
                Picture = production.Picture,
                Countries = this.unitOfWork.ProductionCountryRepository.Get()
                    .Where(pc => pc.ProductionId == production.ProductionId)
                    .Join(this.unitOfWork.CountryRepository.Get(),
                        pc => pc.CountryId,
                        c => c.CountryId,
                        (pc, c) => new string(c.Name))
                    .ToList(),
                Genres = this.unitOfWork.ProductionGenreRepository.Get()
                    .Where(pg => pg.ProductionId == production.ProductionId)
                    .Join(this.unitOfWork.GenreRepository.Get(),
                        pg => pg.GenreId,
                        g => g.GenreId,
                        (pg, g) => new string(g.Name))
                    .ToList(),
                Rate = this.unitOfWork.ProductionRateRepository.Get().Where(r => r.ProductionId == production.ProductionId).Select(r => r.Stars).DefaultIfEmpty().Average(x => (int)x),
                RateCount = this.unitOfWork.ProductionRateRepository.Get().Where(r => r.ProductionId == production.ProductionId).Count()
            };
        }

        public bool ChangePicture(int productionId, byte[] picture)
        {
            Production production = this.unitOfWork.ProductionRepository.Get(productionId);
            if (production == null)
                return false;

            production.Picture = picture;
            this.unitOfWork.Complete();
            return true;
        }

        public bool DeletePicture(int productionId)
        {
            Production production = this.unitOfWork.ProductionRepository.Get(productionId);
            if (production == null)
                return false;

            production.Picture = File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, @"Resources\", "defaultProductionPicture.png"));
            this.unitOfWork.Complete();
            return true;
        }

        public bool Delete(int productionId)
        {
            bool deleted = this.unitOfWork.ProductionRepository.Delete(productionId);
            if (deleted)
            {
                var comments = this.unitOfWork.ProductionCommentRepository.Get().Where(x => x.ProductionId == productionId);
                var rates = this.unitOfWork.ProductionRateRepository.Get().Where(x => x.ProductionId == productionId);
                var watchStatus = this.unitOfWork.ProductionWatchStatusRepository.Get().Where(x => x.ProductionId == productionId);
                var genres = this.unitOfWork.ProductionGenreRepository.Get().Where(x => x.ProductionId == productionId);
                var countries = this.unitOfWork.ProductionCountryRepository.Get().Where(x => x.ProductionId == productionId);
                var trailers = this.unitOfWork.ProductionTrailerRepository.Get().Where(x => x.ProductionId == productionId);
                var episods = this.unitOfWork.ProductionEpisodRepository.Get().Where(x => x.ProductionId == productionId);
                var pictures = this.unitOfWork.ProductionPictureRepository.Get().Where(x => x.ProductionId == productionId);
                var actors = this.unitOfWork.ProductionActorRepository.Get().Where(x => x.ProductionId == productionId);
                var directors = this.unitOfWork.ProductionDirectorRepository.Get().Where(x => x.ProductionId == productionId);
                var screenwriters = this.unitOfWork.ProductionScreenwriterRepository.Get().Where(x => x.ProductionId == productionId);

                foreach (var x in comments) this.unitOfWork.ProductionCommentRepository.Delete(x.ProductionCommentId);
                foreach (var x in rates) this.unitOfWork.ProductionRateRepository.Delete(productionId, x.UserId);
                foreach (var x in watchStatus) this.unitOfWork.ProductionWatchStatusRepository.Delete(productionId, x.UserId);
                foreach (var x in genres) this.unitOfWork.ProductionGenreRepository.Delete(productionId, x.GenreId);
                foreach (var x in countries) this.unitOfWork.ProductionRateRepository.Delete(productionId, x.CountryId);
                foreach (var x in trailers) this.unitOfWork.ProductionTrailerRepository.Delete(x.ProductionTrailerId);
                foreach (var x in episods) this.unitOfWork.ProductionEpisodRepository.Delete(productionId, x.Season, x.Episod);
                foreach (var x in pictures) this.unitOfWork.ProductionPictureRepository.Delete(x.ProductionPictureId);
                foreach (var x in actors) this.unitOfWork.ProductionActorRepository.Delete(productionId, x.CelebritieId);
                foreach (var x in directors) this.unitOfWork.ProductionDirectorRepository.Delete(productionId, x.CelebritieId);
                foreach (var x in screenwriters) this.unitOfWork.ProductionScreenwriterRepository.Delete(productionId, x.CelebritieId);
                this.unitOfWork.Complete();
            }
            return deleted;
        }

        public List<CountryDto> GetCountries(int productionId)
        {
            Production production = this.unitOfWork.ProductionRepository.Get(productionId);
            if (production == null)
                return new List<CountryDto>();

            return this.unitOfWork.ProductionCountryRepository.Get().ToList()
                .Where(p => p.ProductionId == productionId)
                .Join(this.unitOfWork.CountryRepository.Get(),
                    pc => pc.CountryId,
                    c => c.CountryId,
                    (pc, c) => new CountryDto
                    {
                        CountryId = c.CountryId,
                        Name = c.Name
                    })
                .ToList();
        }

        public bool AddCountry(int productionId, int countryId)
        {
            Production production = this.unitOfWork.ProductionRepository.Get(productionId);
            if (production == null)
                return false;

            Country country = this.unitOfWork.CountryRepository.Get(countryId);
            if (country == null)
                return false;

            bool exist = this.unitOfWork.ProductionCountryRepository.Get().Where(x => x.CountryId == countryId && x.ProductionId == productionId).Count() > 0;
            if (exist)
                return false;

            this.unitOfWork.ProductionCountryRepository.Add(new ProductionCountry
            {
                CountryId = countryId,
                ProductionId = productionId
            });
            this.unitOfWork.Complete();
            return true;
        }

        public bool DeleteCountry(int productionId, int countryId)
        {
            bool removed = this.unitOfWork.ProductionCountryRepository.Delete( productionId, countryId );
            if (removed) this.unitOfWork.Complete();
            return removed;
        }

        public List<GenreDto> GetGenres(int productionId)
        {
            Production production = this.unitOfWork.ProductionRepository.Get(productionId);
            if (production == null)
                return new List<GenreDto>();

            return this.unitOfWork.ProductionGenreRepository.Get().ToList()
                .Where(p => p.ProductionId == productionId)
                .Join(this.unitOfWork.GenreRepository.Get(),
                    pg => pg.GenreId,
                    g => g.GenreId,
                    (pg, g) => new GenreDto
                    {
                        GenreId = g.GenreId,
                        Name = g.Name
                    })
                .ToList();
        }

        public bool AddGenre(int productionId, int genreId)
        {
            Production production = this.unitOfWork.ProductionRepository.Get(productionId);
            if (production == null)
                return false;

            Genre genre = this.unitOfWork.GenreRepository.Get(genreId);
            if (genre == null)
                return false;

            bool exist = this.unitOfWork.ProductionGenreRepository.Get().Where(x => x.GenreId == genreId && x.ProductionId == productionId).Count() > 0;
            if (exist)
                return false;

            this.unitOfWork.ProductionGenreRepository.Add(new ProductionGenre
            {
                GenreId = genreId,
                ProductionId = productionId
            });
            this.unitOfWork.Complete();
            return true;
        }

        public bool DeleteGenre(int productionId, int genreId)
        {
            bool removed = this.unitOfWork.ProductionGenreRepository.Delete(productionId, genreId);
            if (removed) this.unitOfWork.Complete();
            return removed;
        }

        public List<CelebritieDto> GetActors(int productionId)
        {
            Production production = this.unitOfWork.ProductionRepository.Get(productionId);
            if (production == null)
                return new List<CelebritieDto>();

            return this.unitOfWork.ProductionActorRepository.Get().ToList()
                .Where(p => p.ProductionId == productionId)
                .Join(this.unitOfWork.CelebritieRepository.Get(),
                    pa => pa.CelebritieId,
                    c => c.CelebritieId,
                    (pa, c) => new CelebritieDto
                    {
                        Id = c.CelebritieId,
                        Name = c.Name,
                        Surname = c.Surname,
                        DateOfBirth = c.DateOfBirth,
                        PlaceOfBirth = c.PlaceOfBirth,
                        Picture = c.Picture
                    })
                .ToList();
        }

        public bool AddActor(int productionId, int celebritieId)
        {
            Production production = this.unitOfWork.ProductionRepository.Get(productionId);
            if (production == null)
                return false;

            Celebritie celebritie = this.unitOfWork.CelebritieRepository.Get(celebritieId);
            if (celebritie == null)
                return false;

            bool exist = this.unitOfWork.ProductionActorRepository.Get().Where(x => x.CelebritieId == celebritieId && x.ProductionId == productionId).Count() > 0;
            if (exist)
                return false;

            this.unitOfWork.ProductionActorRepository.Add(new ProductionActor
            {
                CelebritieId = celebritieId,
                ProductionId = productionId
            });
            this.unitOfWork.Complete();
            return true;
        }

        public bool DeleteActor(int productionId, int celebritieId)
        {
            bool removed = this.unitOfWork.ProductionActorRepository.Delete(productionId, celebritieId);
            if (removed) this.unitOfWork.Complete();
            return removed;
        }

        public List<CelebritieDto> GetDirectors(int productionId)
        {
            Production production = this.unitOfWork.ProductionRepository.Get(productionId);
            if (production == null)
                return new List<CelebritieDto>();

            return this.unitOfWork.ProductionDirectorRepository.Get().ToList()
                .Where(p => p.ProductionId == productionId)
                .Join(this.unitOfWork.CelebritieRepository.Get(),
                    pd => pd.CelebritieId,
                    c => c.CelebritieId,
                    (pd, c) => new CelebritieDto
                    {
                        Id = c.CelebritieId,
                        Name = c.Name,
                        Surname = c.Surname,
                        DateOfBirth = c.DateOfBirth,
                        PlaceOfBirth = c.PlaceOfBirth,
                        Picture = c.Picture
                    })
                .ToList();
        }

        public bool AddDirector(int productionId, int celebritieId)
        {
            Production production = this.unitOfWork.ProductionRepository.Get(productionId);
            if (production == null)
                return false;

            Celebritie celebritie = this.unitOfWork.CelebritieRepository.Get(celebritieId);
            if (celebritie == null)
                return false;

            bool exist = this.unitOfWork.ProductionDirectorRepository.Get().Where(x => x.CelebritieId == celebritieId && x.ProductionId == productionId).Count() > 0;
            if (exist)
                return false;

            this.unitOfWork.ProductionDirectorRepository.Add(new ProductionDirector
            {
                CelebritieId = celebritieId,
                ProductionId = productionId
            });
            this.unitOfWork.Complete();
            return true;
        }

        public bool DeleteDirector(int productionId, int celebritieId)
        {
            bool removed = this.unitOfWork.ProductionDirectorRepository.Delete(productionId, celebritieId);
            if (removed) this.unitOfWork.Complete();
            return removed;
        }

        public List<CelebritieDto> GetScreenwriters(int productionId)
        {
            Production production = this.unitOfWork.ProductionRepository.Get(productionId);
            if (production == null)
                return new List<CelebritieDto>();

            return this.unitOfWork.ProductionScreenwriterRepository.Get().ToList()
                .Where(p => p.ProductionId == productionId)
                .Join(this.unitOfWork.CelebritieRepository.Get(),
                    ps => ps.CelebritieId,
                    c => c.CelebritieId,
                    (ps, c) => new CelebritieDto
                    {
                        Id = c.CelebritieId,
                        Name = c.Name,
                        Surname = c.Surname,
                        DateOfBirth = c.DateOfBirth,
                        PlaceOfBirth = c.PlaceOfBirth,
                        Picture = c.Picture
                    })
                .ToList();
        }

        public bool AddScreenwriter(int productionId, int celebritieId)
        {
            Production production = this.unitOfWork.ProductionRepository.Get(productionId);
            if (production == null)
                return false;

            Celebritie celebritie = this.unitOfWork.CelebritieRepository.Get(celebritieId);
            if (celebritie == null)
                return false;

            bool exist = this.unitOfWork.ProductionScreenwriterRepository.Get().Where(x => x.CelebritieId == celebritieId && x.ProductionId == productionId).Count() > 0;
            if (exist)
                return false;

            this.unitOfWork.ProductionScreenwriterRepository.Add(new ProductionScreenwriter
            {
                CelebritieId = celebritieId,
                ProductionId = productionId
            });
            this.unitOfWork.Complete();
            return true;
        }

        public bool DeleteScreenwriter(int productionId, int celebritieId)
        {
            bool removed = this.unitOfWork.ProductionScreenwriterRepository.Delete(productionId, celebritieId);
            if (removed) this.unitOfWork.Complete();
            return removed;
        }
    }
}
