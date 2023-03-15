namespace Hierarchy;

public class Branch
{
    public List<Branch> Branches { get;}

    public Branch()
    {
        Branches = new List<Branch>();
    }
}