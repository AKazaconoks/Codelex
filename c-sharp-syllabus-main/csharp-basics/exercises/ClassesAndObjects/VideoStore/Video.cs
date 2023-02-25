using System.Collections.Generic;
using System.Linq;

namespace VideoStore
{
    class Video
    {
        private string _title;
        private bool _isChecked;
        private List<double> _list;

        public Video(string title)
        {
            _title = title;
            _isChecked = true;
            _list = new List<double>();
        }

        public void BeingCheckedOut()
        {
            _isChecked = false;
        }

        public void BeingReturned()
        {
            _isChecked = true;
        }

        public void ReceivingRating(double rating)
        {
            _list.Add(rating);
        }

        public double AverageRating()
        {
            return _list.Sum() /_list.Count;
        }

        public string Available()
        {
            return _isChecked ? "Available" : "Not available";
        }

        public string Title => _title;

        public override string ToString()
        {
            return $"{Title} {AverageRating()} {Available()}";
        }
    }
}
