using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;

using What_A_Movie.Models;
using What_A_Movie.ViewModels;

namespace What_A_Movie.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        private readonly IMovieReviewRepository _movieReviewRepository;

        private readonly ICategoryRepository _categoryRepository;
        private readonly HtmlEncoder _htmlEncoder;
        public MoviesController(IMovieRepository movieRepository,
                                IMovieReviewRepository movieReviewRepository,
                                HtmlEncoder htmlEncoder,
                                ICategoryRepository categoryRepository)
        {
            _movieRepository = movieRepository;
            _movieReviewRepository = movieReviewRepository;

            _htmlEncoder = htmlEncoder;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Movie> movies = _movieRepository.Movies.OrderBy(p => p.Name);

            return View(movies);
        }

        [HttpPost]
        public IActionResult Details(int MovieId, string Review)
        {
            Movie movie = _movieRepository.GetMovieById(MovieId);

            if (movie == null)
            {
                return NotFound();
            }

            string encodedReview = _htmlEncoder.Encode(Review);
            _movieReviewRepository.AddMovieReview(new MovieReview() { Movie = movie, Review = encodedReview });
            var reviews = _movieReviewRepository.GetReviewsForMovie(MovieId);

            return View(new MovieDetailsViewModels() { Movie = movie, ReviewList = reviews.ToList() });
        }

        public IActionResult Details(int MovieId)
        {
            var movie = _movieRepository.GetMovieById(MovieId);

            if (movie == null)
                return NotFound();

            var reviews = _movieReviewRepository.GetReviewsForMovie(MovieId);

            return View(new MovieDetailsViewModels() { Movie = movie, ReviewList = reviews.ToList() });
        }



    }
}