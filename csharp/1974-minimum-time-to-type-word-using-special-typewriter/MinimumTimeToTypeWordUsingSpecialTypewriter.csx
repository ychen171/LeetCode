public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int MinTimeToType(string word)
    {
        int ans = 0;
        int prev = 0; // 'a'
        int curr;
        foreach (var c in word)
        {
            // [0, 25]
            curr = c - 'a';
            if (curr > prev)
            {
                ans += Math.Min(curr - prev, prev + 26 - curr);
            }
            else if (curr < prev)
            {
                ans += Math.Min(prev - curr, curr + 26 - prev);
            }
            else // curr == prev
            {
            }
            ans++;
            prev = curr;
        }

        return ans;
    }
}
