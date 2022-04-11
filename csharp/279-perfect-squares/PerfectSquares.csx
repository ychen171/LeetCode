public class Solution
{
    // find all perfect squares < n
    // n = 12, [9, 4, 1]
    // BFS, shortest path, 

    // n = 13, [9, 4, 1]
    // BFS, shortest path, 
    public int NumSquares(int n)
    {
        List<int> squres = FindPerfectSquares(n);
        return BFS(n, squres);
    }

    // original BFS, containing duplicates
    private int BFS(int n, List<int> squres)
    {
        var queue = new Queue<int>();
        queue.Enqueue(n);
        int level = 1;
        while (queue.Count != 0)
        {
            int levelLen = queue.Count;
            for (int j = 0; j < levelLen; j++)
            {
                var remainder = queue.Dequeue();
                foreach (var squre in squres)
                {
                    if (remainder == squre)
                        return level;
                    else if (remainder < squre)
                        continue;
                    else
                        queue.Enqueue(remainder - squre);
                }
            }
            level++;
        }

        return n;
    }

    // optimized BFS, using HashSet
    private int BFS1(int n, List<int> squres, int start)
    {
        // TODO
        return n;
    }

    private List<int> FindPerfectSquares(int n)
    {
        var ans = new List<int>();
        for (int i = n / 2 + 1; i >= 1; i--)
        {
            var squre = i * i;
            if (squre <= n)
                ans.Add(squre);
        }

        return ans;
    }
}