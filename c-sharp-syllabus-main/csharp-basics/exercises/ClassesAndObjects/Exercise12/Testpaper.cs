using Microsoft.Win32.SafeHandles;

namespace Exercise12
{
    public interface ITestpaper
    {
        string _subject { get; set; }
        string[] _markScheme { get; set; }
        string _passMark { get; set; }
    }
    public class Testpaper : ITestpaper
    {
        public string _subject { get; set; }
        public string[] _markScheme { get; set; }
        public string _passMark { get; set; }

        public Testpaper(string subject, string[] markScheme, string passMark)
        {
            _subject = subject;
            _markScheme = markScheme;
            _passMark = passMark;
        }
    }
}