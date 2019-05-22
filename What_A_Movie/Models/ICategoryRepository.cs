using System.Collections.Generic;

namespace What_A_Movie.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
