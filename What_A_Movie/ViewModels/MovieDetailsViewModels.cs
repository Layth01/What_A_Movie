
using System.Collections.Generic;

using What_A_Movie.Models;

namespace What_A_Movie.ViewModels
{
    public class MovieDetailsViewModels
    {
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public List<MovieReview> ReviewList { get; set; }
        public string Review { get; set; }
    }
}
