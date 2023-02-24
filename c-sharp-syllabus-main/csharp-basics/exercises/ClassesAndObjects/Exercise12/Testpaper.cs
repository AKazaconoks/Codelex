using Microsoft.Win32.SafeHandles;

namespace Exercise12
{
    public interface ITestpaper
    {
        string subject { get; set; }
        string[] markScheme { get; set; }
        string passMark { get; set; }
    }
    public class Testpaper : ITestpaper
    {
        public string subject { get; set; }
        public string[] markScheme { get; set; }
        public string passMark { get; set; }

        public Testpaper(string subject, string[] markScheme, string passMark)
        {
            this.subject = subject;
            this.markScheme = markScheme;
            this.passMark = passMark;
        }
        
        
    }
}