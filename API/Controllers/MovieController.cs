using CleanMovie.Application.@abstract;
using CleanMovie.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanMovie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        public ActionResult<List<Movie>> Get()
        {
            var movies = _movieService.GetAllMovies();
            return movies;

        }
        [HttpPost]
        public ActionResult<Movie> PostMovie(Movie movie)
        {
            var movies = _movieService.CreateMovie(movie);
            return movies;
        }
    }
}
