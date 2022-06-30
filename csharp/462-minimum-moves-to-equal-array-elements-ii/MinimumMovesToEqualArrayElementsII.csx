public class Solution
{
    // Sorting + Median
    // Time: O(n log n)
    // Space: O(n)
    public int MinMoves2(int[] nums)
    {
        // 1 2 3
        // target = 2,    1 + 0 + 1 = 2
        // 2 2 3   
        // 2 2 2    

        // 1 10 2 9
        // 1 2 9 10, target = 2,    1 + 0 + 7 + 8 = 16

        // 1 0 0 8 6   sum = 15, avg = 3,       2 + 3 + 3 + 5 + 3 = 16
        //                       avg = 4,       3 + 4 + 4 + 4 + 2 = 17
        //                       avg = 2,       1 + 2 + 2 + 6 + 4 = 15
        //                       avg = 1,       0 + 1 + 1 + 7 + 5 = 14
        // 0 0 1 6 8, target = 1,    

        int n = nums.Length;
        if (n == 1)
            return 0;

        // sort nums and find median
        Array.Sort(nums);
        int target = nums[(n - 1) / 2];
        int ans = 0;
        foreach (var num in nums)
        {
            ans += Math.Abs(num - target);
        }

        return ans;
    }
}
