using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        private readonly HtmlEncoder _htmlEncoder;
        public MoviesController(IMovieRepository movieRepository,
                                IMovieReviewRepository movieReviewRepository,
                                HtmlEncoder htmlEncoder)
        {
            _movieRepository = movieRepository;
            _movieReviewRepository = movieReviewRepository;
            _htmlEncoder = htmlEncoder;
        }

        public IActionResult Index()
        {
            var movies = _movieRepository.GetAllMovies().OrderBy(p => p.Name);

            return View(movies);
        }
        // [Route("[controller]/Details/{id}")]
        public IActionResult Details(int MovieId)
        {
            var movie = _movieRepository.GetMovieById(MovieId);
            if (movie == null)
                return NotFound();

            return View(new MovieDetailsViewModels() { Movie = movie });
        }

        //[Route("[controller]/Details/{id}")]
        [HttpPost]
        public IActionResult Details(int MovieId, string Review)
        {
            var movie = _movieRepository.GetMovieById(MovieId);

            if (movie == null)
            {
                return NotFound();
            }

            var encodedReview = _htmlEncoder.Encode(Review);
            _movieReviewRepository.AddMovieReview(new MovieReview() { Movie = movie, Review = encodedReview });

            return View(new MovieDetailsViewModels() { Movie = movie });



        }
    }
}