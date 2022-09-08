public class Solution
{
    // DP
    // Time: O(n)
    // Space: O(n)
    public int MaxProduct(int[] nums)
    {
        int n = nums.Length;
        if (n == 0)
            return 0;

        var dpMax = new int[n];
        var dpMin = new int[n];
        dpMax[0] = nums[0];
        dpMin[0] = nums[0];
        for (int i = 1; i < n; i++)
        {
            dpMax[i] = Math.Max(nums[i], Math.Max(dpMax[i - 1] * nums[i], dpMin[i - 1] * nums[i]));
            dpMin[i] = Math.Min(nums[i], Math.Min(dpMin[i - 1] * nums[i], dpMax[i - 1] * nums[i]));
        }

        return dpMax.Max();
    }

    // Two Pass
    // Time: O(n)
    // Space: O(1)
    public int MaxProduct1(int[] nums)
    {
        /*
        if the count of negatives is even (including no negative), 
        the l-r pass will get the result;

        if the count of negatives is odd, 
        the l-r pass and the r-l pass can only contain even number of negatives,
        [5,1,-2,3,-4,-6,7,8] => [5,1,-2,3,-4] vs [3,-4,-6,7,8]
        */
        int n = nums.Length;
        if (n == 0)
            return 0;

        var result = int.MinValue;
        int product = 1;
        for (int i = 0; i < n; i++)
        {
            product *= nums[i];
            result = Math.Max(result, product);
            if (product == 0)
                product = 1;
        }
        product = 1;
        for (int i = n-1; i >= 0; i--)
        {
            product *= nums[i];
            result = Math.Max(result, product);
            if (product == 0)
                product = 1;
        }

        return result;
    }
}
