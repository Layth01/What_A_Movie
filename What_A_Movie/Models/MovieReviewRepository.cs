using System.Collections.Generic;
using System.Linq;

namespace What_A_Movie.Models
{
    public class MovieReviewRepository : IMovieReviewRepository
    {
        private readonly AppDbContext _appDbContext;
        public MovieReviewRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void AddMovieReview(MovieReview movieReview)
        {
            _appDbContext.MovieReviews.Add(movieReview);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<MovieReview> GetReviewsForMovie(int movieId)
        {
            return _appDbContext.MovieReviews.Where(p => p.Movie.MovieId == movieId);
        }
    }
}
