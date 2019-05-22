using System.Collections.Generic;

namespace What_A_Movie.Models
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> Movies { get; }
        Movie GetMovieById(int movieId);

        void CreateMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int MovieId);
    }
}
