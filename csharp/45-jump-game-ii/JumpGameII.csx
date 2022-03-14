public class Solution
{
    // DP | Bottom-up | Tabulation | Iteration
    // Time: O(n^2)
    // Space: O(n)
    public int Jump(int[] nums)
    {
        // initialize table with default value
        var table = new List<int>();
        // seed the trivial answer into the table
        table.Add(0);
        for (int i = 1; i < nums.Length; i++)
        {
            table.Add(int.MaxValue);
        }
        // fill further positions with current position
        for (int i = 0; i < nums.Length; i++)
        {
            var maxLen = nums[i];
            for (int k = 1; k <= maxLen && i + k < nums.Length; k++)
            {
                table[i + k] = Math.Min(table[i + k], table[i] + 1);
            }
        }
        return table[table.Count - 1];
    }

    // Greedy
    // Time: O(n)
    // Space: O(1)
    public int JumpGreedy(int[] nums)
    {
        int jumps = 0;
        int currentJumpEnd = 0;
        int farthest = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            farthest = Math.Max(farthest, i + nums[i]);
            if (i == currentJumpEnd)
            {
                jumps++;
                currentJumpEnd = farthest;
            }
        }

        return jumps;
    }
}
