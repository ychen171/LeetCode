public class Solution
{
    // DP | Tabulation
    // Time: O(k * m * n)
    // Space: O(m * n)
    public int FindMaxForm(string[] strs, int m, int n)
    {
        // [10,0001,111001,1,0]     m=5, n=3
        // 1
        // 1    2
        // 1    2     2
        // 1    2     2    3
        // 1    2     2    3  4

        // [10, 0, 1] m = 1, n = 1
        // 1            c0 = 1, c1 = 1
        //      1       c0 = 1, c1 = 0

        int k = strs.Length;
        var countArray = new int[k][];
        for (int i = 0; i < k; i++)
        {
            // count 0 and 1
            int count0 = 0;
            int count1 = 0;
            foreach (char c in strs[i])
            {
                if (c == '0')
                    count0++;
                else
                    count1++;
            }
            countArray[i] = new int[] { count0, count1 };
        }

        var table = new int[m + 1][];
        for (int i = 0; i < m + 1; i++)
            table[i] = new int[n + 1];

        for (int i = 0; i < k; i++)
        {
            int count0 = countArray[i][0];
            int count1 = countArray[i][1];
            for (int remain0 = m; remain0 >= count0; remain0--)
            {
                for (int remain1 = n; remain1 >= count1; remain1--)
                {
                    table[remain0][remain1] = Math.Max(table[remain0][remain1], table[remain0 - count0][remain1 - count1] + 1);
                }
            }
        }

        return table[m][n];
    }
}
