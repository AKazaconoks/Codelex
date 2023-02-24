namespace Exercise12
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var paper1 = new Testpaper("Maths", new string[] { "1A", "2C", "3D", "4A", "5A" }, "60%");
            var paper2 = new Testpaper("Chemistry", new string[] { "1C", "2C", "3D", "4A" }, "75%");
            var paper3 = new Testpaper("Computing", new string[] { "1D", "2C", "3C", "4B", "5D", "6C", "7A" }, "75%");

            var student1 = new Student();
            var student2 = new Student();

            student1.testsTaken();
            student1.takeTest(paper1, new string[] { "1A", "2D", "3D", "4A", "5A" });
            student1.testsTaken();

            student2.takeTest(paper2, new [] { "1C", "2D", "3A", "4C" });
            student2.takeTest(paper3, new [] { "1A", "2C", "3A", "4C", "5D", "6C", "7B" });
            student2.testsTaken();
        }
    }
}