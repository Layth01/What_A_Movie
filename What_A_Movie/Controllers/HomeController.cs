using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using What_A_Movie.Models;

namespace What_A_Movie.Controllers
{
    
    public class HomeController : Controller
    {
    

        public IActionResult Index()
        {
            return View();
        }
    }
}