public class Solution
{
    // Sort
    // Time: O(n log n)
    // Space: O(n)
    public int SmallestRangeII(int[] nums, int k)
    {
        // sort array
        int n = nums.Length;
        int mid = 0 + (n - 1) / 2;
        Array.Sort(nums);
        // iterate through
        int ans = nums[n-1] - nums[0];
        for (int i = 1; i < n; i++)
        {
            int curr = nums[i];
            int prev = nums[i-1];
            int min = Math.Min(nums[0] + k, curr - k);
            int max = Math.Max(nums[n-1] - k, prev + k);
            ans = Math.Min(ans, max - min);
        }
        return ans;
    }
}
var sln = new Solution();
var nums = new int[] { 0, 10 };
var k = 2;
var result = sln.SmallestRangeII(nums, k);
Console.WriteLine(result);
