public class Solution
{
    // DP | Tabulation 
    // Time: O(n)
    // Space: O(n)
    public int MinCost(string colors, int[] neededTime)
    {
        int n = colors.Length;
        if (n == 1)
            return 0;
        // initialize table with default values
        var table = new int[n, 2];
        // seed the trivial answer into the table
        // fill further positions based on the current position
        for (int i = 1; i < n; i++)
        {
            var prevColorIndex = table[i - 1, 0];
            var usedTime = table[i - 1, 1];
            if (colors[prevColorIndex] == colors[i])
            {
                if (neededTime[prevColorIndex] < neededTime[i])
                {
                    table[i, 0] = i;
                    table[i, 1] = usedTime + neededTime[prevColorIndex];
                }
                else
                {
                    table[i, 0] = prevColorIndex;
                    table[i, 1] = usedTime + neededTime[i];
                }
            }
            else
            {
                table[i, 0] = i;
                table[i, 1] = table[i - 1, 1];
            }
        }

        return table[n - 1, 1];
    }
}
