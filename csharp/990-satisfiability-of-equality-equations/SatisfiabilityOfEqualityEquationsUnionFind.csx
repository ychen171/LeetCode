public class Solution
{
    // Uninon Find
    // Time: O(n)
    // Space: O(1)
    public bool EquationsPossible(string[] equations)
    {
        var uf = new UnionFind(26); // [a,b,c,...,z]
        // connect all variables which are equal
        foreach (var equation in equations)
        {

            bool areEqual = equation[1] == '=';
            if (areEqual)
            {
                char x = equation[0];
                char y = equation[3];
                uf.Union(x - 'a', y - 'a');
            }
        }
        foreach (var equation in equations)
        {

            bool areEqual = equation[1] == '=';
            if (!areEqual)
            {
                char x = equation[0];
                char y = equation[3];
                if (uf.Connected(x - 'a', y - 'a'))
                    return false;
            }
        }

        return true;
    }
}

public class UnionFind
{
    private int[] parents;
    public int Count { get; private set; }
    public UnionFind(int n)
    {
        parents = new int[n];
        for (int i = 0; i < n; i++)
            parents[i] = i;
        Count = n;
    }

    public void Union(int p, int q)
    {
        int rootP = Find(p);
        int rootQ = Find(q);
        if (rootP == rootQ)
            return;

        parents[rootP] = rootQ;
        Count--;
    }

    public int Find(int p)
    {
        if (parents[p] != p)
            parents[p] = Find(parents[p]);

        return parents[p];
    }

    public bool Connected(int p, int q)
    {
        int rootP = Find(p);
        int rootQ = Find(q);

        return rootP == rootQ;
    }
}

var s = new Solution();
var equations = new string[] { "a!=a" };
var result = s.EquationsPossible(equations);
Console.WriteLine(result);

