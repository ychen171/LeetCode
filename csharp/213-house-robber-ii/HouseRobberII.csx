public class Solution
{
    // DP |Tabulation
    // Time: O(n)
    // Space: O(n)
    public int Rob(int[] nums)
    {
        // [2,3,2]
        // [2,3]
        // 2
        // 2  3
        // [3,2]
        // 3
        // 3  3

        // [1,2,3,1]
        // [1,2,3]
        // 1
        // 1 2
        // 1 2 4
        // [2,3,1]
        // 2
        // 2  3
        // 2  3  3


        // [1,2,3]
        // 1
        // 1  2
        // 1  2  3

        // [1,3,1,3,100]
        // [1,3,1,3]
        // 1
        // 1 3
        // 1 3 3
        // 1 3 3 6

        // [3,1,3,100]
        // 3
        // 3 3
        // 3 3 6
        // 3 3 6 103

        int n = nums.Length;
        // edge case
        if (n == 1)
            return nums[0];
        if (n == 2)
            return Math.Max(nums[0], nums[1]);

        // break the cycle into two different arrays
        // try both
        int max1 = RobSimple(nums, 0, n - 1);
        int max2 = RobSimple(nums, 1, n);
        return Math.Max(max1, max2);
    }

    private int RobSimple(int[] nums, int start, int end)
    {
        var table = new int[end - start];
        table[0] = nums[start];
        table[1] = Math.Max(table[0], nums[start + 1]);
        for (int i = start + 2; i < end; i++)
        {
            table[i - start] = Math.Max(table[i - 1 - start], table[i - 2 - start] + nums[i]);
        }

        return table.Last();
    }
}
