public class Solution
{
    // Two Pointers
    // Time: O(n)
    // Space: O(n)
    public string PushDominoes(string dominoes)
    {
        int n = dominoes.Length;
        // add two virtual positions: left most and right most
        var indexes = new int[n + 2];  // store index of all 'L's and 'R's
        var symbols = new char[n + 2]; // store symbol(L or R)
        // 1. populate two arrays
        int len = 1;
        indexes[0] = -1;  // len -> index,  virtual -1 index at the left most
        symbols[0] = 'L'; // len -> symbol, virtual 'L' at the left most
        for (int i = 0; i < n; i++)
        {
            if (dominoes[i] != '.')
            {
                indexes[len] = i;
                symbols[len] = dominoes[i];
                len++;
            }
        }
        indexes[len] = n;   // virtual n index at the right most
        symbols[len] = 'R'; // virtual 'R' at the right most
        len++;

        // 2. fill out all '.'s
        var ans = dominoes.ToCharArray();
        for (int index = 0; index < len - 1; index++)
        {
            int i = indexes[index];
            int j = indexes[index + 1];
            char x = symbols[index];
            char y = symbols[index + 1];
            if (x == y) // L...L or R...R
            {
                for (int k = i + 1; k < j; k++)
                {
                    ans[k] = x; // update .
                }
            }
            else if (x > y) // R...L
            {
                for (int k = i + 1; k < j; k++)
                {
                    ans[k] = k - i == j - k ? '.' : k - i < j - k ? 'R' : 'L';
                }
            }
            else // L...R
            {
                // skip
            }
        }

        return new string(ans);
    }
}
