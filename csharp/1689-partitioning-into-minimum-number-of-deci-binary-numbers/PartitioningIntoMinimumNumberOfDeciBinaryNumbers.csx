public class Solution
{
    // Greedy
    // Time: O(m)
    // Space: O(1)
    public int MinPartitions(string n)
    {
        int maxDigit = 0;
        foreach (char c in n)
        {
            maxDigit = Math.Max(maxDigit, int.Parse(c.ToString()));
        }

        return maxDigit;
    }
}
