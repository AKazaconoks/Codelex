Console.Write("Enter a number: ");
var input = int.Parse(Console.ReadLine());
isHappy(input);

void isHappy(int number)
{
    var sum = 0;
    foreach (var num in number.ToString())
    {
        sum += (int) Math.Pow(double.Parse(num.ToString()), 2);
    }

    if(sum == input) Console.WriteLine($"{input} is not a happy number");
    else if(sum == 1) Console.WriteLine($"{input} is a happy number");
    else isHappy(sum);
}
