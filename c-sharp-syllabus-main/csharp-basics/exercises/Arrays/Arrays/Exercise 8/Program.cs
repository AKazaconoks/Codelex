using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_8
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Play();
        }

        public static void Play()
        {
            string[] words = new[] { "meningoencefalomieloradikuloneirits", "hibridlietojumprogrammatura", "visneiedomajamakais" };
            var word = new Random().Next(0, words.Length);
            char[] guess = new string('_', words[word].Length).ToCharArray();
            var misses = new List<string>();
            while (string.Join(" ", guess).Contains("_"))
            {
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-\n");
                Console.WriteLine("Word:\t" + string.Join(" ", guess) +"\n");
                Console.WriteLine("Misses:\t" + string.Join("", misses) + "\n");
                Console.WriteLine("Guess:\n");
                var shot = Console.ReadLine();
                if(!words[word].Contains(shot)) misses.Add(shot);
                for (int i = 0; i < words[word].Length; i++)
                {
                    if (words[word][i].ToString() == shot) guess[i] = shot[0];
                }
            }
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-\n");
            Console.WriteLine("Word:\t" + string.Join(" ", guess) +"\n");
            Console.WriteLine("Misses:\t" + string.Join("", misses) + "\n");
            Console.WriteLine("YOU GOT IT!\n");
            Console.WriteLine("Play 'again' or 'quit'?");
            var decision = Console.ReadLine();
            if(decision == "again") Play();
        }
    }
}