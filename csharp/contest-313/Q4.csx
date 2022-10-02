public class Solution
{
    // DP
    public int DeleteString(string s)
    {
        return Helper(s, 0);
    }
    public int Helper(string s, int start)
    {
        int n = s.Length;
        // base case
        // recursive case
        int result = 1;
        for (int i = 1; i <= (n - start) / 2; i++)
        {
            string leftStr = s.Substring(start, i);
            string rightStr = s.Substring(start + i);
            if (rightStr.StartsWith(leftStr))
            {
                result += Helper(s, start + i);
            }
        }

        return result;
    }
}
