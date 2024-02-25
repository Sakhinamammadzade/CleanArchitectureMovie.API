using CleanMovie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application.@abstract
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();
        Movie CreateMovie(Movie movie);
    }
}
