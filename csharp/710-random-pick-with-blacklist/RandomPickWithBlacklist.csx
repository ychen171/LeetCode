public class Solution
{
    Dictionary<int, int> remap;
    Random random;
    int n;
    int m;
    // Time: O(b)
    // Space: O(b)
    public Solution(int n, int[] blacklist)
    {
        random = new Random();
        this.n = n;
        this.m = n - blacklist.Length;
        remap = new Dictionary<int, int>();
        foreach (var b in blacklist)
            remap[b] = 0;

        int last = n - 1;

        // [0, m)
        foreach (var b in blacklist)
        {
            // [m, n)
            if (b >= m)
                continue;

            while (remap.ContainsKey(last))
                last--;
            remap[b] = last;
            last--;
        }
    }
    // Time: O(1)
    // Space: O(1)
    public int Pick()
    {
        int num = random.Next(0, m);
        return remap.ContainsKey(num) ? remap[num] : num;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(n, blacklist);
 * int param_1 = obj.Pick();
 */
