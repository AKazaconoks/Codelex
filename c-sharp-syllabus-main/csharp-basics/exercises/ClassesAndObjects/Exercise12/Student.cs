using System;
using System.Collections.Generic;

namespace Exercise12
{
    interface IStudent
    {
        string[] TestsTaken { get; set; }
        void takeTest(ITestpaper paper, string[] answers);
    }
    public class Student : IStudent
    {
        public string[] TestsTaken { get; set; }
        private List<string> papersDone;

        public Student()
        {
            papersDone = new List<string>();
        }

        public void takeTest(ITestpaper paper, string[] answers)
        {
            var score = 0;
            for (var i = 0; i < answers.Length; i++)
            {
                score += answers[i] == paper.markScheme[i] ? 1 : 0;
            }
            papersDone.Add($"{paper.subject}: {(100 * score / answers.Length >= 80 ? "Passed!" : "Failed")} ({100 * score / answers.Length}%)");
        }

        public void testsTaken()
        {
            Console.WriteLine(string.Join("\n", papersDone));
        }
    }
}