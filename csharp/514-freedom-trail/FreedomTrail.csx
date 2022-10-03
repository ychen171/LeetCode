public class Solution
{
    // DP | Memoization Recursion
    // Time: O(m * n)
    // Space: O(m * n)
    int m;
    int n;
    int[][] memo;
    public int FindRotateSteps(string ring, string key)
    {
        /*
            godding godding
        */
        m = ring.Length; // options
        n = key.Length;  // levels
        memo = new int[m][];
        for (int i = 0; i < m; i++)
            memo[i] = new int[n];
        return Helper(ring, 0, key, 0);
    }

    public int Helper(string ring, int i, string key, int j)
    {
        // base case
        if (j == n)
            return 0;

        if (memo[i][j] != 0)
            return memo[i][j];

        // recursive case
        // press
        int result = int.MaxValue;
        if (ring[i] == key[j])
        {
            result = Math.Min(result, 1 + Helper(ring, i, key, j + 1));
        }
        else
        {
            int moves = int.MaxValue;
            int nextI = i;
            int k = 0;
            // go left / clockwise
            while (k < m - 1)
            {
                k++;
                nextI = nextI == 0 ? m - 1 : nextI - 1;
                if (ring[nextI] == key[j])
                {
                    moves = k;
                    result = Math.Min(result, moves + Helper(ring, nextI, key, j));
                    break;
                }
            }
            // go right / anti-clockwise
            moves = int.MaxValue;
            nextI = i;
            k = 0;
            while (k < m - 1)
            {
                k++;
                nextI = (nextI + 1) % m;
                if (ring[nextI] == key[j])
                {
                    moves = k;
                    result = Math.Min(result, moves + Helper(ring, nextI, key, j));
                    break;
                }
            }
        }
        memo[i][j] = result;
        return result;
    }
}

var sln = new Solution();
var ring = "godding";
var key = "gd";
var result = sln.FindRotateSteps(ring, key);
Console.WriteLine(result);
