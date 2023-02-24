using System.Collections.Generic;
using System.Linq;

namespace VideoStore
{
    class Video
    {
        private string title;
        private bool isChecked;
        private List<double> list;

        public Video(string title)
        {
            this.title = title;
            this.isChecked = true;
            this.list = new List<double>();
        }

        public void BeingCheckedOut()
        {
            this.isChecked = false;
        }

        public void BeingReturned()
        {
            this.isChecked = true;
        }

        public void ReceivingRating(double rating)
        {
            list.Add(rating);
        }

        public double AverageRating()
        {
            return this.list.Sum() / this.list.Count;
        }

        public string Available()
        {
            return isChecked ? "Available" : "Not available";
        }

        public string Title => this.title;

        public override string ToString()
        {
            return $"{Title} {AverageRating()} {Available()}";
        }
    }
}
