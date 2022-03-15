public class Solution
{
    // Backtracking
    // Time: O(K * N!/((N-K)!K!))
    // Space: O(N!/(N-K)!K!)
    public IList<IList<int>> Combine(int n, int k)
    {
        IList<IList<int>> result = new List<IList<int>>();
        var candidates = new HashSet<int>();
        for (int i = 1; i <= n; i++)
            candidates.Add(i);
        var comb = new HashSet<int>();
        Backtrack(n, k, comb, 1, result);
        return result;
    }

    private void Backtrack(int n, int k, HashSet<int> comb, int nextStart, IList<IList<int>> result)
    {
        if (comb.Count == k)
        {
            result.Add(new List<int>(comb));
            return;
        }

        for (int i = nextStart; i <= n; i++)
        {
            if (comb.Add(i))
            {
                Backtrack(n, k, comb, i + 1, result);
                comb.Remove(i);
            }
        }
    }
}
