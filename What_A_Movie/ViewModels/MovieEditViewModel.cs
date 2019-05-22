using Microsoft.AspNetCore.Mvc.Rendering;

using System.Collections.Generic;

using What_A_Movie.Models;

namespace What_A_Movie.ViewModels
{
    public class MovieEditViewModel
    {
        public Movie Movie { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public int CategoryId { get; set; }
    }
}
