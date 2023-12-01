using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEntityDapper.API.Model;
using ApiEntityDapper.Domain.Entities;
using ApiEntityDapper.Domain.Interface.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiEntityDapper.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("list/{type}", Name = "ListMovies")]
        public async Task<ActionResult> ListMovies([FromRoute] string type)
        {
            var movies = await _movieService.ListMovies(type);

            return Ok(movies);
        }

        [HttpGet("get/{id}", Name = "GetMovie")]
        public async Task<ActionResult> GetMovie([FromRoute] string id, string type)
        {
            var movie = await _movieService.GetMovieById(id, type);

            return Ok(movie);
        }

        [HttpPost("{type}", Name = "CreateMovie")]
        public async Task<ActionResult> CreateMovie([FromBody] MovieViewModel movie, [FromRoute] string type)
        {
            var _movie = new Movie(movie.Id, movie.Title, movie.Description, movie.Year, movie.IdCategory, false);
            var result = await _movieService.CreateMovie(_movie, type);

            return Ok(result);
        }

        [HttpPut("{type}", Name = "UpdateMovie")]
        public async Task<ActionResult> UpdateMovie([FromBody] MovieViewModel movie, [FromRoute] string type)
        {
            var _movie = new Movie(movie.Id, movie.Title, movie.Description, movie.Year, movie.IdCategory, false);
            var result = await _movieService.UpdateMovie(_movie, type);

            return Ok(result);
        }

        [HttpDelete("{Id}/{type}")]
        public async Task<ActionResult> RemoveMovie([FromRoute] string Id, string type)
        { 
            var result = await _movieService.DeleteMovie(Id, type);

            return Ok(result);
        }
    }
}

