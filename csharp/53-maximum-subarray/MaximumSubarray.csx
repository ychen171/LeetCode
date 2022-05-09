public class Solution
{
    // DP | Tabulation
    // Time: O(n)
    // Space: O(n)
    public int MaxSubArray(int[] nums)
    {
        int n = nums.Length;
        if (n == 1)
            return nums[0];

        // initialize the table
        var table = new int[n];
        // seed the trivial answer into the table
        table[0] = nums[0];
        // fill further positions based on current position
        for (int i = 1; i < n; i++)
        {
            int num = nums[i];
            table[i] = Math.Max(table[i-1], 0) + num;
        }

        return table.Max();
    }
}
