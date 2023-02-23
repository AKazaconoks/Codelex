using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateArea
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var choice = GetMenu();
                if(choice == 1) CalculateCircleArea();
                else if(choice == 2) CalculateRectangleArea();
                else if(choice == 3) CalculateTriangleArea();
                else if (choice == 4)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
            }
            
        }

        public static int GetMenu()
        {
            int userChoice;
            Console.WriteLine("Geometry Calculator\n");
            Console.WriteLine("1. Calculate the Area of a Circle");
            Console.WriteLine("2. Calculate the Area of a Rectangle");
            Console.WriteLine("3. Calculate the Area of a Triangle");
            Console.WriteLine("4. Quit\n");
            Console.WriteLine("Enter your choice (1-4) : ");
            userChoice = int.Parse(Console.ReadLine());
            return userChoice;
        }

        public static void CalculateCircleArea()
        {
            Console.WriteLine("What is the circle's radius? ");
            var radius = int.Parse(Console.ReadLine());
            Console.WriteLine("The circle's area is "
                              + Geometry.AreaOfCircle(radius));
        }

        public static void CalculateRectangleArea()
        {
            double length = 0;
            double width = 0;
            Console.WriteLine("Enter length? ");
            length = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter width? ");
            width = double.Parse(Console.ReadLine());
            Console.WriteLine("The rectangle's area is "
                              + Geometry.AreaOfTriangle(length, width));
        }

        public static void CalculateTriangleArea()
        {
            double ground = 0;
            double height = 0;
            Console.WriteLine("Enter length of the triangle's base? ");
            ground = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter triangle's height? ");
            height = double.Parse(Console.ReadLine());
            Console.WriteLine("The triangle's area is "
                              + Geometry.AreaOfRectangle(ground, height));
        }

    }
}
