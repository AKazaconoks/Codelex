using System;

namespace Exercise8
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Point p1 = new Point(5, 2);
            Point p2 = new Point(-3, 6);
            SwapPoints(p1, p2);
            Console.WriteLine("(" + p1._x + ", " + p1._y + ")");
            Console.WriteLine("(" + p2._x + ", " + p2._y + ")");
        }

        private static void SwapPoints(Point p1, Point p2)
        {
            var tempX = p1._x;
            var tempY = p1._y;
            p1._x = p2._x;
            p1._y = p2._y;
            p2._x = tempX;
            p2._y = tempY;
        }
    }

    internal class Point
    {
        public int _x { get; set; }
        public int _y { get; set; }

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}