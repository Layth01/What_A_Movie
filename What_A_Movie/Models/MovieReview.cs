namespace What_A_Movie.Models
{
    public class MovieReview
    {
        public int MovieReviewId { get; set; }
        public Movie Movie { get; set; }
        public string Review { get; set; }
    }
}
