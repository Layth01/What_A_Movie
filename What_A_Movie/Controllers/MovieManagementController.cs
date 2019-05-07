using Microsoft.AspNetCore.Mvc;

using System.Linq;

using What_A_Movie.Models;

namespace What_A_Movie.Controllers
{
    public class MovieManagementController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MovieManagementController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public ViewResult Index()
        {
            var movies = _movieRepository.GetAllMovies().OrderBy(m => m.Name);
            return View(movies);
        }


    }
}