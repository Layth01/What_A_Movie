using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using What_A_Movie.Models;

namespace What_A_Movie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public IActionResult Index()
        {
            var movies = _movieRepository.GetAllMovies().OrderBy(p => p.Name);

            return View(movies);
        }
    }
}