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
        this.n = n; // [0, n)
        this.m = n - blacklist.Length; // [0, m)
        remap = new Dictionary<int, int>();
        // add all blacklist nums in remap
        foreach (var b in blacklist)
            remap[b] = -1;

        int last = n - 1; // [m, n)
        // [0, m)
        foreach (var b in blacklist)
        {
            // [m, n)
            if (b >= m)
                continue;
            // find the rightmost available num in [m, n)
            while (remap.ContainsKey(last))
                last--;
            // map the blacklist num in [0, m) to the rightmost available num
            remap[b] = last;
            // move to left by 1
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
