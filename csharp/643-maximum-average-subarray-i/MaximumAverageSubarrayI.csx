public class Solution
{
    // Sliding Window | Moving Average
    // Time: O(n)
    // Space: O(1)
    public double FindMaxAverage(int[] nums, int k)
    {
        int n = nums.Length;
        int left = 0, right = 0;
        // [left, right)
        double windowSum = 0;
        double ans = double.MinValue;
        while (right < n)
        {
            windowSum += nums[right];
            right++;
            if (right - left == k)
            {
                ans = Math.Max(ans, windowSum / k);
                windowSum -= nums[left];
                left++;
            }
        }

        return ans;
    }
}

var sln = new Solution();
var nums = new int[] { -1 };
var k = 1;
var result = sln.FindMaxAverage(nums, k);
Console.WriteLine(result);

