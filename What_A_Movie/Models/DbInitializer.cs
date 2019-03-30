using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace What_A_Movie.Models
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Movies.Any())
            {
                context.AddRange
                (
                    new Movie {  Name = "Captain Marvel", Genre = "Fantasy", ReleaseDate = new DateTime(2002), Description = "Captain Marvel is an extraterrestrial Kree warrior who finds herself caught in the middle of an intergalactic battle between her people and the Skrulls. Living on Earth in 1995, she keeps having recurring memories of another life as U.S. Air Force pilot Carol Danvers. With help from N", Duration = 2.20d, Likes = 20, Rating = 90, FilmUrl = "https://www.youtube.com/watch?v=ft_UsQvW4bI", ThumbnailUrl = "http://lorempixel.com/400/200/" },
                    new Movie {  Name = "Captain Marvel", Genre = "Fantasy", ReleaseDate = new DateTime(2002), Description = "Captain Marvel is an extraterrestrial Kree warrior who finds herself caught in the middle of an intergalactic battle between her people and the Skrulls. Living on Earth in 1995, she keeps having recurring memories of another life as U.S. Air Force pilot Carol Danvers. With help from N", Duration = 2.20d, Likes = 20, Rating = 90, FilmUrl = "https://www.youtube.com/watch?v=ft_UsQvW4bI", ThumbnailUrl = "http://lorempixel.com/400/200/" },
                    new Movie {  Name = "Captain Marvel", Genre = "Fantasy", ReleaseDate = new DateTime(2002), Description = "Captain Marvel is an extraterrestrial Kree warrior who finds herself caught in the middle of an intergalactic battle between her people and the Skrulls. Living on Earth in 1995, she keeps having recurring memories of another life as U.S. Air Force pilot Carol Danvers. With help from N", Duration = 2.20d, Likes = 20, Rating = 90, FilmUrl = "https://www.youtube.com/watch?v=ft_UsQvW4bI", ThumbnailUrl = "http://lorempixel.com/400/200/" },
                    new Movie { Name = "Captain Marvel", Genre = "Fantasy", ReleaseDate = new DateTime(2002), Description = "Captain Marvel is an extraterrestrial Kree warrior who finds herself caught in the middle of an intergalactic battle between her people and the Skrulls. Living on Earth in 1995, she keeps having recurring memories of another life as U.S. Air Force pilot Carol Danvers. With help from N", Duration = 2.20d, Likes = 20, Rating = 90, FilmUrl = "https://www.youtube.com/watch?v=ft_UsQvW4bI", ThumbnailUrl = "http://lorempixel.com/400/200/" } ,
                    new Movie { Name = "Captain Marvel", Genre = "Fantasy", ReleaseDate = new DateTime(2002), Description = "Captain Marvel is an extraterrestrial Kree warrior who finds herself caught in the middle of an intergalactic battle between her people and the Skrulls. Living on Earth in 1995, she keeps having recurring memories of another life as U.S. Air Force pilot Carol Danvers. With help from N", Duration = 2.20d, Likes = 20, Rating = 90, FilmUrl = "https://www.youtube.com/watch?v=ft_UsQvW4bI", ThumbnailUrl = "http://lorempixel.com/400/200/" },
                     new Movie { Name = "Captain Marvel", Genre = "Fantasy", ReleaseDate = new DateTime(2002), Description = "Captain Marvel is an extraterrestrial Kree warrior who finds herself caught in the middle of an intergalactic battle between her people and the Skrulls. Living on Earth in 1995, she keeps having recurring memories of another life as U.S. Air Force pilot Carol Danvers. With help from N", Duration = 2.20d, Likes = 20, Rating = 90, FilmUrl = "https://www.youtube.com/watch?v=ft_UsQvW4bI", ThumbnailUrl = "http://lorempixel.com/400/200/" }

               );
                context.SaveChanges();
            }
        }
    }
}