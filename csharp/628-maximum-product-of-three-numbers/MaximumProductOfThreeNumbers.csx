public class Solution
{
    // Sorting
    // Time: O(n log n)
    // Space: O(n)
    public int MaximumProduct(int[] nums)
    {
        // compare min1 * min2 * max1 with max1 * max2 * max3
        int n = nums.Length;
        Array.Sort(nums);

        int op1 = nums.Last();
        for (int i = 0; i < 2; i++)
            op1 *= nums[i];

        int op2 = 1;
        for (int i = n - 1; i >= n - 3; i--)
            op2 *= nums[i];

        return Math.Max(op1, op2);
    }


    // Time: O(n)
    // Space: O(1)
    public int MaximumProduct1(int[] nums)
    {
        int min1 = int.MaxValue, min2 = int.MaxValue;
        int max1 = int.MinValue, max2 = int.MinValue, max3 = int.MinValue;
        foreach (var num in nums)
        {
            if (num <= min1)
            {
                min2 = min1;
                min1 = num;
            }
            else if (num <= min2)
            {
                min2 = num;
            }
            if (num >= max1)
            {
                max3 = max2;
                max2 = max1;
                max1 = num;
            }
            else if (num >= max2)
            {
                max3 = max2;
                max2 = num;
            }
            else if (num >= max3)
            {
                max3 = num;
            }
        }

        return Math.Max(min1 * min2 * max1, max1 * max2 * max3);
    }
}
