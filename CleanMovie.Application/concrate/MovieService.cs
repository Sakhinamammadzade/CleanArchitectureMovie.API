using CleanMovie.Application.@abstract;
using CleanMovie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application.concrate
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        //Constructor Dependency Injection
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Movie CreateMovie(Movie movie)
        {
            try
            {
                _movieRepository.CreateMovie(movie);
                return movie;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Movie> GetAllMovies()
        {
            try
            {
                var movies = _movieRepository.GetAllMovies();
                return movies;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
