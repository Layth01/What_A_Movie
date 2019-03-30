using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace What_A_Movie.Models
{
    public class MockMovieRepository : IMovieRepository
    {
        private List<Movie> _movies;
        public MockMovieRepository()
        {
            if (_movies == null)
            {
                InitializeMovies();
            }

        }

        private void InitializeMovies()
        { 
            _movies = new List<Movie>
           {
               new Movie{Id = 1, Name="Captain Marvel",Genre="Fantasy", ReleaseDate= new DateTime(2002) ,Description = "Captain Marvel is an extraterrestrial Kree warrior who finds herself caught in the middle of an intergalactic battle between her people and the Skrulls. Living on Earth in 1995, she keeps having recurring memories of another life as U.S. Air Force pilot Carol Danvers. With help from N",Duration= 2.20d ,Likes= 20,Rating=90 },
               new Movie{Id = 1, Name="Captain ",Genre="Fantasy", ReleaseDate= new DateTime(2019) ,Description = "Captain Marvel is an extraterrestrial Kree warrior who finds herself caught in the middle of an intergalactic battle between her people and the Skrulls. Living on Earth in 1995, she keeps having recurring memories of another life as U.S. Air Force pilot Carol Danvers. With help from N",Duration= 2.20d ,Likes= 20,Rating=90 },
               new Movie{Id = 1, Name="Captain Marvel",Genre="Fantasy", ReleaseDate= new DateTime(2019) ,Description = "Captain Marvel is an extraterrestrial Kree warrior who finds herself caught in the middle of an intergalactic battle between her people and the Skrulls. Living on Earth in 1995, she keeps having recurring memories of another life as U.S. Air Force pilot Carol Danvers. With help from N",Duration= 2.20d ,Likes= 20,Rating=90 },
               new Movie{Id = 1, Name="Captain ",Genre="Fantasy", ReleaseDate= new DateTime(2019),Description = "Captain Marvel is an extraterrestrial Kree warrior who finds herself caught in the middle of an intergalactic battle between her people and the Skrulls. Living on Earth in 1995, she keeps having recurring memories of another life as U.S. Air Force pilot Carol Danvers. With help from N",Duration= 2.20 ,Likes= 20,Rating=90 }
               };
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _movies;
        }
    }
}
