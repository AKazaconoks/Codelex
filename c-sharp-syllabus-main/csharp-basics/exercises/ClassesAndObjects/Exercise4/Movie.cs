using System.Linq;

namespace Exercise4
{
    public class Movie
    {
        private string _title;
        private string _studio;
        private string _rating { get; }

        public Movie(string title, string studio, string rating)
        {
            _title = title;
            _studio = studio;
            _rating = rating;
        }

        public Movie(string title, string studio)
        {
            _title = title;
            _studio = studio;
            _rating = "PG";
        }
        
        public Movie[] GetPg (Movie[] movies)
        {
            return movies.Where(m => m._rating == "PG").ToArray();
        }
    }
}