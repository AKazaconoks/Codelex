namespace Hierarchy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var branch = new Branch();
            branch.Branches.Add(new Branch());
            branch.Branches[0].Branches.Add(new Branch());
            branch.Branches.Add(new Branch());
            branch.Branches[1].Branches.Add(new Branch());
            branch.Branches[1].Branches[0].Branches.Add(new Branch());
            branch.Branches[1].Branches.Add(new Branch());
            branch.Branches[1].Branches[1].Branches.Add(new Branch());
            branch.Branches[1].Branches[1].Branches[0].Branches.Add(new Branch());
            branch.Branches[1].Branches[1].Branches.Add(new Branch());
            branch.Branches[1].Branches.Add(new Branch());
            var result = CountDepth(branch);
            Console.WriteLine($"Tree depth is {result}");
        }

        private static int CountDepth(Branch branch)
        {
            if (branch.Branches.Count == 0)
            {
                return 1;
            }

            var maxDepth = 0;
            foreach (var item in branch.Branches)
            {
                var depth = CountDepth(item);
                maxDepth = Math.Max(depth, maxDepth);
            }
            return maxDepth + 1;
        }
    }
}