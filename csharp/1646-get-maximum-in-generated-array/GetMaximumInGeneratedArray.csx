public class Solution
{
    // Loop
    // Time: O(n)
    // Space: O(n)
    public int GetMaximumGenerated(int n)
    {
        if (n <= 1)
            return n;
        var nums = new int[n + 1];
        nums[0] = 0;
        nums[1] = 1;
        int ans = 1;
        for (int i = 2; i <= n; i++)
        {
            if (i % 2 == 0) // even
            {
                nums[i] = nums[i / 2];
            }
            else // odd
            {
                nums[i] = nums[i / 2] + nums[i / 2 + 1];
            }
            ans = Math.Max(ans, nums[i]);
        }

        return ans;
    }
}
