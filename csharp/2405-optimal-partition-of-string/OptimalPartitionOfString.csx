public class Solution
{
    // Greedy | HashSet
    // Time: O(n)
    // Space: O(n)
    public int PartitionString(string s)
    {
        int n = s.Length;
        if (n == 1)
            return 1;

        var window = new HashSet<char>();
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            var c = s[i];
            if (!window.Add(c))
            {
                ans++;
                window.Clear();
                window.Add(c);
            }
        }
        if (window.Count > 0)
            ans++;
        return ans;
    }
}
