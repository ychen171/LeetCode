public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int[] RunningSum(int[] nums)
    {
        int n = nums.Length;
        var ans = new int[n];

        ans[0] = nums[0];
        for (int i = 1; i < n; i++)
        {
            ans[i] = ans[i-1] + nums[i];
        }

        return ans;
    }
}
