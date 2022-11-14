public class Solution
{
    public int NumPairsDivisibleBy60(int[] time)
    {
        /*
            time[i] % 60 + time[j] % 60 == 0 or 60
            time[i] % 60 == - time[j] % 60;
            time[i] % 60 == 60 - time[j] % 60
        */
        int n = time.Length;
        if (n < 2) return 0;
        var numCountDict = new Dictionary<int, int>();
        int result = 0;
        for (int i = 0; i < n; i++)
        {
            int ti = time[i] % 60;
            if (ti == 0)
            {
                if (numCountDict.ContainsKey(ti))
                    result += numCountDict[ti];
            }
            else
            {
                if (numCountDict.ContainsKey(60 - ti))
                    result += numCountDict[60 - ti];
            }
            numCountDict[ti] = numCountDict.GetValueOrDefault(ti, 0) + 1;
        }
        return result;
    }
}
// Two Sum + Dictionary + Mod
// Time: O(n)
// Space: O(n)
