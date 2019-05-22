using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Linq;

using What_A_Movie.Models;

namespace What_A_Movie.Controllers
{
    [Authorize]
    public class MyListController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        public MyListController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public IActionResult Index()
        {
            var movies = _movieRepository.Movies.OrderBy(p => p.Name);
            return View(movies);
        }
    }
}