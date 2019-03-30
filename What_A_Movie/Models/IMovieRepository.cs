using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace What_A_Movie.Models
{
    public interface IMovieRepository
    {
         IEnumerable<Movie> GetAllMovies();
    }
}
