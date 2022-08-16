public class Solution
{
    // DP | Memoization Recursion
    // Time: O(n)
    // Space: O(n)
    public bool CanWinNim(int n)
    {
        /*
            1, 2, 3      true
            4            false
        */
        var memo = new int[n + 1];
        return CanWin(n, memo);
    }

    private bool CanWin(int i, int[] memo)
    {
        if (memo[i] != 0)
            return memo[i] == 1;

        if (i == 4)
            return false;
        if (i < 4)
            return true;

        bool result = false;
        for (int k = 1; k <= 3; k++)
        {
            if (!CanWin(i - k, memo)) // if friend can lose
            {
                result = true; // I can win
                break;
            }
        }
        memo[i] = result ? 1 : -1;
        return result;
    }

    // Fuck
    // Time: O(1)
    // Space: O(1)
    public bool CanWinNim1(int n)
    {
        return n % 4 != 0;
    }
}
