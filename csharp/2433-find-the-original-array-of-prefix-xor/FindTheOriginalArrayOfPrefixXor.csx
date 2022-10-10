public class Solution
{
    // Bitwise Operation
    // Time: O(n)
    // Space: O(1)
    public int[] FindArray(int[] pref)
    {
        /*
            5   2   0   3   1
            5   7   2   3   2

            5                       5

            5 ^ 7 = 2               5 ^ 2 = 7
                                    
            5 ^ 7 ^ 2 = 0           5 ^ 7 ^ 0 = 2
                                    5 ^ (5 ^ 2) ^ 0 = 2

            5 ^ 7 ^ 2 ^ 3 = 3       5 ^ 7 ^ 2       ^ 3 = 3
                                    5 ^ (5 ^ 2) ^ (5 ^ 7 ^ 0)       ^ 3 = 3
                                    5 ^ (5 ^ 2) ^ (5 ^ (5 ^ 2) ^ 0)

            5 ^ 7 ^ 2 ^ 3 ^ 2 = 1   5 ^ 7 ^ 2 ^ 3 ^ 1 = 2



        */
        int n = pref.Length;
        var result = new int[n];
        result[0] = pref[0];
        for (int i = 1; i < n; i++)
        {
            result[i] = pref[i] ^ pref[i - 1];
        }
        return result;

    }
}
