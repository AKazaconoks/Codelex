using System;
using System.Collections.Generic;
using System.Linq;

namespace VideoStore
{
    class VideoStore
    {
        private List<Video> list;
        public VideoStore()
        {
            this.list = new List<Video>();
        }

        public void AddVideo(string title)
        {
            list.Add(new Video(title));
        }
        
        public void Checkout(string title)
        {
            list.Where(video => video.Title == title).ToList().ForEach(video => video.BeingCheckedOut());
        }

        public void ReturnVideo(string title)
        {
            list.Where(video => video.Title == title).ToList().ForEach(video => video.BeingReturned());
        }

        public void TakeUsersRating(double rating, string title)
        {
            list.Where(video => video.Title == title).ToList().ForEach(video => video.ReceivingRating(rating));
        }

        public void ListInventory()
        {
            Console.WriteLine(string.Join("\n", list) + "\n");
        }
    }
}
