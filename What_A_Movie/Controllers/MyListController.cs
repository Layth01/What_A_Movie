﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            var movies = _movieRepository.GetAllMovies().OrderBy(p => p.Name);
            return View(movies);
        }
    }
}