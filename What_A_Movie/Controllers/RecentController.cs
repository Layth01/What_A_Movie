﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace What_A_Movie.Controllers
{
    public class RecentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}