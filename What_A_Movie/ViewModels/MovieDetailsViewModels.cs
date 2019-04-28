
using System.ComponentModel.DataAnnotations;

using What_A_Movie.Models;

namespace What_A_Movie.ViewModels
{
    public class MovieDetailsViewModels
    {
        [Required]
        public Movie Movie { get; set; }

        public string Review { get; set; }
    }
}
