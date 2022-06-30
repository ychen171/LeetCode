public class Solution
{
    // TLE
    // Sorting
    // Time: O(k * n log n)
    // Space: O(n)
    public int MinMoves(int[] nums)
    {
        // 1 2 3
        // 2 3 3
        // 3 4 3  -> 3 3 4
        // 4 4 4

        // find the max and sum, 
        // if max * n == sum, all equal, return the number of moves
        // else increment all other than tha max

        int n = nums.Length;
        if (n == 1)
            return 0;

        int count = 0;
        while (true)
        {
            Array.Sort(nums);
            int sum = nums.Sum();
            int max = nums.Last();
            if (max * n == sum)
                return count;

            count++;
            for (int i = 0; i < n - 1; i++)
                nums[i]++;
        }
    }

    // Sorting
    // Time: O(n log n)
    // Space: O(n)
    public int MinMoves1(int[] nums)
    {
        // incrementing every num except the max num == only decrementing the max num
        int n = nums.Length;
        if (n == 1)
            return 0;

        int count = 0;
        Array.Sort(nums);
        int min = nums[0];
        int max = nums[n - 1];
        foreach (var num in nums)
        {
            count += num - min;
        }

        return count;
    }

    // Math
    // Time: O(n)
    // Space: O(1)
    public int MinMoves2(int[] nums)
    {
        /*  sum + (n-1) * m = n * e
            min + m = e

            m = s - n * min
            
        */
        // incrementing every num except the max num == only decrementing the max num
        int n = nums.Length;
        if (n == 1)
            return 0;

        int sum = 0;
        int min = int.MaxValue;
        foreach (var num in nums)
        {
            sum += num;
            min = Math.Min(min, num);
        }

        int moves = sum - n * min;
        return moves;
    }
}
