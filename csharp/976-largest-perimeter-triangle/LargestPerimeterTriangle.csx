public class Solution
{
    // Greedy | Sort + Math
    // Time: O(n log n)
    // Space: O(n)
    public int LargestPerimeter(int[] nums)
    {
        // sort in descending order
        Array.Sort(nums);
        int x, y, z;
        int n = nums.Length;
        for (int i = n - 1; i >= 2; i--)
        {
            x = nums[i];
            y = nums[i - 1];
            z = nums[i - 2];
            if (x < y + z)
                return x + y + z;
        }
        return 0;
    }

    // private bool IsTriangle(int x, int y, int z)
    // {
    //     if (x + y <= z || x + z <= y || y + z <= x)
    //         return false;
    //     if (Math.Abs(x - y) >= z || Math.Abs(x - z) >= y || Math.Abs(y - z) >= x)
    //         return false;
    //     return true;
    // }
}
