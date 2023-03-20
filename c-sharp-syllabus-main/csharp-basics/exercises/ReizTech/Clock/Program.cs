namespace ReizTech;

public class Program
{
    public static void Main(string[] args)
    {
        var isCorrectFormat = false;
        while (!isCorrectFormat)
        {
            Console.Write("Please input time in 'hh:mm' format: ");
            var time = Console.ReadLine();
            var parts = time.Split(":");
            if (int.Parse(parts[0]) is >= 0 and < 24 && int.Parse(parts[1]) is >= 0 and < 60)
            {
                isCorrectFormat = true;
                var hours = int.Parse(parts[0]) % 12;
                var minutes = decimal.Parse(parts[1]) / 5;
                Console.WriteLine($"The lesser angle between hours and minutes arrow is {Math.Min(Math.Abs(hours - minutes) * 30, 360 - Math.Abs(hours- minutes) * 30)} degrees");
            }
            else
            {
                Console.WriteLine("Incorrect time format");
            }  
        }
    }
}