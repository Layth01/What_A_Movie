using System.Collections.Generic;

namespace What_A_Movie.Models
{
    public interface IMovieReviewRepository
    {
        void AddMovieReview(MovieReview movieReview);
        IEnumerable<MovieReview> GetReviewsForMovie(int movieId);
    }
}
