public class Solution
{
    // Math
    // Time: O(n)
    // Space: O(1)
    public int[] SumZero(int n)
    {
        var ans = new List<int>();
        if (n % 2 != 0) // odd length
        {
            ans.Add(0);
        }
        for (int i = 1; i <= n / 2; i++)
        {
            ans.Add(i);
            ans.Add(-i);
        }
        return ans.ToArray();
    }
}
