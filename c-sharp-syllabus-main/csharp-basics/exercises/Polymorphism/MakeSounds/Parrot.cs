using System;

namespace MakeSounds
{
    public class Parrot : ISound
    {
        public void PlaySound()
        {
            Console.WriteLine("Chik Chirik... Actually I can speak");
        }
    }
}