public class Solution
{
    // Sliding Window
    public int LongestContinuousSubstring(string s)
    {
        int n = s.Length;
        if (n <= 1)
            return n;

        var window = new List<char>();
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            char c = s[i];
            if (window.Count == 0 || c - window.Last() == 1)
                window.Add(c);
            else
            {
                ans = Math.Max(ans, window.Count);
                window.Clear();
                window.Add(c);
            }
        }

        return Math.Max(ans, window.Count);
    }
}

var sln = new Solution();
var s = "abcde";
var result = sln.LongestContinuousSubstring(s);
Console.WriteLine(result);
