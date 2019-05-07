using System.Collections.Generic;

namespace What_A_Movie.Models
{
    interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
