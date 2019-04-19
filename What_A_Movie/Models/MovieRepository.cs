using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace What_A_Movie.Models
{
    public class MovieRepository: IMovieRepository
    {
        public readonly AppDbContext _applicationDbContext;

        public MovieRepository(AppDbContext appDbContext)
        {
            _applicationDbContext = appDbContext;
        }
       

        public IEnumerable<Movie> GetAllMovies()
        {
            return _applicationDbContext.Movies;
        }

        public Movie GetMovieById(int Movieid)
        {
            return _applicationDbContext.Movies.FirstOrDefault(p => p.MovieId == Movieid);
        }
    }
}
