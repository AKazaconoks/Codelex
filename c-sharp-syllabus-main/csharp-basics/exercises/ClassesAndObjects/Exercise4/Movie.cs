using System.Linq;

namespace Exercise4
{
    public class Movie
    {
        private string title;
        private string studio;
        private string rating { get; }

        public Movie(string title, string studio, string rating)
        {
            this.title = title;
            this.studio = studio;
            this.rating = rating;
        }

        public Movie(string title, string studio)
        {
            this.title = title;
            this.studio = studio;
            this.rating = "PG";
        }
        
        public Movie[] getPG (Movie[] movies)
        {
            return movies.Where(m => m.rating == "PG").ToArray();
        }
    }
}