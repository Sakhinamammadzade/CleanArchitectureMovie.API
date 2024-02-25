using CleanMovie.Application.@abstract;
using CleanMovie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CleanMovie.Infrastructure
{
    public class MovieRepository: IMovieRepository
    {

        private readonly MovieDbContext _movieDbContext;

        public MovieRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public Movie CreateMovie(Movie movie)
        {
            _movieDbContext.Movies.Add(movie);
            _movieDbContext.SaveChanges();

            return movie;
        }

        public List<Movie> GetAllMovies()
        {
            return _movieDbContext.Movies.ToList();
        }
    }

    
}
