using AutoMapper;
using System;
using System.Linq;
using System.Web.Http;
using Vidly.WebApp.Models;
using Vidly.WebApp.Models.Dtos;

namespace Vidly.WebApp.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET Api/Movies
        public IHttpActionResult GetMovies()
        {
            var Movies = _context.Movies.ToList().Select(Movie => Mapper.Map<Movie, MovieDto>(Movie));

            return Ok(Movies);
        }

        //POST Api/Movies/1
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = Mapper.Map<Movie, MovieDto>(_context.Movies.SingleOrDefault(c => c.Id == id));

            if (movie == null)
                NotFound();

            return Ok(movie);
        }

        //POST Api/Movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (movieDto == null || !ModelState.IsValid)
                BadRequest();

            var Movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(Movie);
            _context.SaveChanges();
            movieDto.Id = Movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + Movie.Id), movieDto);
        }

        //PUT Api/Movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                NotFound();

            Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);
            _context.SaveChanges();

            return Ok();
        }

        //DELETE Api/Movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok();
        }
    }
}