using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.BLL.Interfaces;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryBll countryBll;

        public CountriesController(ICountryBll countryBll)
        {
            this.countryBll = countryBll;
        }

        [HttpGet("{countryId}")]
        public CountryDto Get(int countryId)
            => this.countryBll.Get(countryId);

        [HttpGet]
        public List<CountryDto> Get()
            => this.countryBll.Get();

        [Authorize(Roles = "Employee,Admin")]
        [HttpPost]
        public CountryDto Post([FromBody] string name)
            => this.countryBll.Post(name);

        [Authorize(Roles = "Employee,Admin")]
        [HttpPut("{countryId}")]
        public CountryDto Put(int countryId, [FromBody] string name)
            => this.countryBll.Put(countryId, name);

        [Authorize(Roles = "Employee,Admin")]
        [HttpDelete("{countryId}")]
        public bool Delete(int countryId)
            => this.countryBll.Delete(countryId);
    }
}
