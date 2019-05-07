using System.Collections.Generic;

namespace What_A_Movie.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
