public class Solution
{
    // One Pass
    // Time: O(n)
    // Space: O(1)
    public int ArraySign(int[] nums)
    {
        int n = nums.Length;
        int ans = 1;
        for (int i = 0; i < n; i++)
        {
            var num = nums[i];
            if (num == 0)
                return 0;
            else if (num < 0)
                ans *= (-1);
        }

        return ans;
    }
}
