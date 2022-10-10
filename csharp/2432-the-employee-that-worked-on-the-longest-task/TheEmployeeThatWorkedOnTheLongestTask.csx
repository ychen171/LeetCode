public class Solution
{
    // Loop 
    // Time: O(n)
    // Space: O(1)
    public int HardestWorker(int n, int[][] logs)
    {
        int maxTime = logs[0][1];
        int result = logs[0][0];
        for (int i = 1; i < logs.Length; i++)
        {
            var time = logs[i][1] - logs[i - 1][1];
            if (time == maxTime)
            {
                result = Math.Min(result, logs[i][0]);
            }
            else if (time > maxTime)
            {
                maxTime = time;
                result = logs[i][0];
            }
        }
        return result;
    }
}
