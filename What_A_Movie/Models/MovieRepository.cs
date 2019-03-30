using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace What_A_Movie.Models
{
    public class MovieRepository: IMovieRepository
    {
        public readonly AppDbContext _appDbContext;

        public MovieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
       

        public IEnumerable<Movie> GetAllMovies()
        {
            return _appDbContext.Movies;
        }
    }
}
