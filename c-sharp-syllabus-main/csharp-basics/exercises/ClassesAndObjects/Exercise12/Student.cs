using System;
using System.Collections.Generic;

namespace Exercise12
{
    interface IStudent
    {
        string[] _testsTaken { get; set; }
        void TakeTest(ITestpaper paper, string[] answers);
    }
    public class Student : IStudent
    {
        public string[] _testsTaken { get; set; }
        private List<string> _papersDone;

        public Student()
        {
            _papersDone = new List<string>();
        }

        public void TakeTest(ITestpaper paper, string[] answers)
        {
            var score = 0;
            for (var i = 0; i < answers.Length; i++)
            {
                score += answers[i] == paper._markScheme[i] ? 1 : 0;
            }
            _papersDone.Add($"{paper._subject}: {(100 * score / answers.Length >= 80 ? "Passed!" : "Failed")} ({100 * score / answers.Length}%)");
        }

        public void TestsTaken()
        {
            Console.WriteLine(string.Join("\n", _papersDone));
        }
    }
}