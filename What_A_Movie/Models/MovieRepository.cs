using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;

namespace What_A_Movie.Models
{
    public class MovieRepository : IMovieRepository
    {
        public readonly AppDbContext _applicationDbContext;

        public MovieRepository(AppDbContext appDbContext)
        {
            _applicationDbContext = appDbContext;
        }

        public IEnumerable<Movie> Movies
        {
            get { return _applicationDbContext.Movies.Include(c => c.Category); }
        }

        public void CreateMovie(Movie movie)
        {
            _applicationDbContext.Movies.Add(movie);
            _applicationDbContext.SaveChanges();
        }

        //public IEnumerable<Movie> GetAllMovies()
        //{
        //    return _applicationDbContext.Movies;
        //}

        public Movie GetMovieById(int Movieid)
        {
            return _applicationDbContext.Movies.FirstOrDefault(p => p.MovieId == Movieid);
        }

        public void UpdateMovie(Movie movie)
        {
            _applicationDbContext.Movies.Update(movie);
            _applicationDbContext.SaveChanges();
        }

        public async void DeleteMovie(int MoiveId)
        {
            var movie = await _applicationDbContext.Movies.FindAsync(MoiveId);

            _applicationDbContext.Movies.Remove(movie);


        }

    }
}
