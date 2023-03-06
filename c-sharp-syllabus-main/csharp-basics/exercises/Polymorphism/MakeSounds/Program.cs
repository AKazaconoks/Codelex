using System;

namespace MakeSounds
{
    class Program
    {
        private static void Main(string[] args)
        {
            new Firework().PlaySound();
            new Parrot().PlaySound();
            new Radio().PlaySound();
        }
    }
}