using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace What_A_Movie.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public double Duration { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "yyyy")]
        public DateTime? ReleaseDate { get; set; }
        public string ThumbnailUrl { get; set; }
        public string FilmUrl { get; set; }
        public int Likes { get; set; }
        public float Rating { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<MovieReview> MovieReviews { get; set; }


    }
}
