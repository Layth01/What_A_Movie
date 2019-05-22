using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.Linq;

using What_A_Movie.Models;
using What_A_Movie.ViewModels;

namespace What_A_Movie.Controllers
{
    public class MoviesManagementController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly AppDbContext _appDbContext;

        public MoviesManagementController(IMovieRepository movieRepository, ICategoryRepository categoryRepository, AppDbContext appDbContext)
        {
            _movieRepository = movieRepository;
            _categoryRepository = categoryRepository;
            _appDbContext = appDbContext;
        }

        public ViewResult Index()
        {
            var movies = _movieRepository.Movies.OrderBy(m => m.Name);
            return View(movies);
        }

        public IActionResult AddMovie()
        {
            var catergories = _categoryRepository.Categories;
            var movieEditViewModel = new MovieEditViewModel
            {
                Categories = catergories.Select(c => new SelectListItem()
                { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList(),
                CategoryId = catergories.FirstOrDefault().CategoryId
            };
            return View(movieEditViewModel);
        }

        [HttpPost]
        public IActionResult AddMovie(MovieEditViewModel movieEditViewModel)
        {
            //basic validation
            if (ModelState.IsValid)
            {
                _movieRepository.CreateMovie(movieEditViewModel.Movie);
                return RedirectToAction("Index");
            }

            return View(movieEditViewModel);
        }
        public IActionResult EditMovie(int movieId)
        {
            var categories = _categoryRepository.Categories;

            var movie = _movieRepository.Movies.FirstOrDefault(m => m.MovieId == movieId);

            var movieEditViewModel = new MovieEditViewModel()
            {
                Categories = categories.Select(c => new SelectListItem() { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList(),
                Movie = movie,
                CategoryId = movie.CategoryId
            };

            var item = movieEditViewModel.Categories.FirstOrDefault(c => c.Value == movie.CategoryId.ToString());
            item.Selected = true;

            return View(movieEditViewModel);
        }
        [HttpPost]
        public IActionResult EditMovie(MovieEditViewModel movieEditViewModel)
        {
            movieEditViewModel.Movie.CategoryId = movieEditViewModel.CategoryId;

            if (ModelState.IsValid)
            {
                _movieRepository.UpdateMovie(movieEditViewModel.Movie);
                return RedirectToAction("Index");
            }
            return View(movieEditViewModel);
        }

        [HttpPost]
        public IActionResult DeleteMovie(int movieId)
        {
            var movie = _appDbContext.Movies.Find(movieId);

            //  _appDbContext.Movies.Remove(movie);
            _appDbContext.Movies.RemoveRange(movie);
            //_appDbContext.SaveChanges();
            //  _appDbContext.
            return View("Index");
        }

    }
}