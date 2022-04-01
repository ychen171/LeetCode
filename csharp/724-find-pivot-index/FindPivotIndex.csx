public class Solution
{
    // Brute force
    // Time: O(n^2)
    // Space: O(1)
    public int PivotIndex(int[] nums)
    {
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            int leftSum = Sum(nums, 0, i - 1);
            int rightSum = Sum(nums, i + 1, n - 1);
            if (leftSum == rightSum)
                return i;
        }

        return -1;
    }

    private int Sum(int[] nums, int start, int end)
    {
        int sum = 0;
        for (int i = start; i <= end; i++)
        {
            sum += nums[i];
        }

        return sum;
    }

    // List
    // Time: O(n)
    // Space: O(n)
    public int PivotIndex1(int[] nums)
    {
        // populate list of sum
        var sumList = new List<int>();
        int sum = 0;
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            sum += nums[i];
            sumList.Add(sum);
        }

        // iterate through and compare left sum with right sum
        for (int i = 0; i < n; i++)
        {
            int midValue = nums[i];
            int leftSum = i - 1 >= 0 ? sumList[i - 1] : 0;
            int rightSum = sumList[n - 1] - leftSum - midValue;
            if (leftSum == rightSum)
                return i;
        }

        return -1;
    }
}
