public class Solution
{
    // Binary Search
    // Time: O(n log ((maxVal - minVal) / 0.00001))
    // Space: O(1)
    public double FindMaxAverage(int[] nums, int k)
    {
        /*
            (nums[i] + nums[i+1] + nums[i+2] + ... + nums[j]) / (j - i + 1) > x
            nums[i] + nums[i+1] + nums[i+2] + ... + nums[j] > x * (j - i + 1)
            nums[i] - x + nums[i+1] - x + nums[i+2] - x + ... + nums[j] - x > 0
        */

        double left = int.MinValue, right = int.MaxValue;
        int n = nums.Length;
        while (right - left >= 0.00001)
        {
            // double mid = left + (right - left) * 0.5;
            double mid = (left + right) / 2;
            if (Check(nums, k, mid))
                left = mid;
            else
                right = mid;
        }

        return right;
    }

    // Check whether we can find a subarray whose average is bigger than x
    public bool Check(int[] nums, int k, double x)
    {
        int n = nums.Length;
        var a = new double[n];
        for (int i = 0; i < n; i++)
            a[i] = nums[i] - x;

        double curr = 0, prev = 0;
        for (int i = 0; i < k; i++)
            curr += a[i];
        if (curr >= 0)
            return true;
        for (int i = k; i < n; i++)
        {
            curr += a[i];
            prev += a[i - k];
            if (prev < 0)
            {
                curr -= prev;
                prev = 0;
            }
            if (curr >= 0)
                return true;
        }
        return false;
    }
}
