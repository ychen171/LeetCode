public class Solution
{
    // DP | Tabulation
    // Time: O(n^2)
    // Space: O(n)
    public int WiggleMaxLength(int[] nums)
    {
        // 1  7  4  9  2  5
        // 0  6 -3  5 -7  3
        int n = nums.Length;
        if (n < 2)
            return n;
        // initialize the table with default values
        var up = new int[n];
        var down = new int[n];
        // seed the trivial answer into the table
        // fill further positions based on current position
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i]) // goes up
                {
                    up[i] = Math.Max(up[i], down[j] + 1);
                }
                else if (nums[j] > nums[i]) // goes down
                {
                    down[i] = Math.Max(down[i], up[j] + 1);
                }
            }
        }

        return 1 + Math.Max(up[n - 1], down[n - 1]);
    }

    // DP | Tabulation
    // Time: O(n)
    // Space: O(n)
    public int WiggleMaxLength1(int[] nums)
    {
        // three possible states:
        // 1. up position: nums[i-1] < nums[i], up[i] = down[i-1] + 1, down[i] = down[i-1]
        // 2. down position: nums[i-1] > nums[i], down[i] = up[i-1] + 1, up[i] = ip[i-1]
        // 3. equal to position: nums[i] == nums[i-1], up[i] = up[i-1], down[i] = down[i-1]
        int n = nums.Length;
        if (n < 2)
            return n;

        // initialize the table with default values
        var up = new int[n];
        var down = new int[n];
        // seed the trivial answer into the table
        up[0] = 1;
        down[0] = 1;
        // fill further positions based on current position
        for (int i = 1; i < n; i++)
        {
            if (nums[i - 1] < nums[i]) // goes up
            {
                up[i] = down[i - 1] + 1;
                down[i] = down[i - 1];
            }
            else if (nums[i - 1] > nums[i]) // goes down
            {
                down[i] = up[i - 1] + 1;
                up[i] = up[i - 1];
            }
            else // equals to
            {
                up[i] = up[i - 1];
                down[i] = down[i - 1];
            }
        }

        return Math.Max(up[n - 1], down[n - 1]);
    }

    // Greedy
    // Time: O(n)
    // Space: O(1)
    public int WiggleMaxLength2(int[] nums)
    {
        int n = nums.Length;
        if (n < 2)
            return n;

        int prevDiff = nums[1] - nums[0];
        int count = prevDiff != 0 ? 2 : 1;
        for (int i = 2; i < n; i++)
        {
            int diff = nums[i] - nums[i - 1];
            if ((diff > 0 && prevDiff <= 0) || (diff < 0 && prevDiff >= 0))
            {
                count++;
                prevDiff = diff;
            }
        }

        return count;
    }
}
