﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.BLL.Interfaces;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreBll genreBll;

        public GenresController(IGenreBll genreBll)
        {
            this.genreBll = genreBll;
        }


        [HttpGet("{genreId}")]
        public GenreDto Get(int genreId)
            => this.genreBll.Get(genreId);

        [HttpGet]
        public List<GenreDto> Get()
            => this.genreBll.Get();

        [Authorize(Roles = "Employee,Admin")]
        [HttpPost]
        public GenreDto Post([FromBody] string name)
            => this.genreBll.Post(name);

        [Authorize(Roles = "Employee,Admin")]
        [HttpPut("{genreId}")]
        public GenreDto Put(int genreId, [FromBody] string name)
            => this.genreBll.Put(genreId, name);

        [Authorize(Roles = "Employee,Admin")]
        [HttpDelete("{genreId}")]
        public bool Delete(int genreId)
            => this.genreBll.Delete(genreId);
    }
}
