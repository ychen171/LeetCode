public class Solution
{
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

var logs = new int[][] { new int[] { 36, 3 }, new int[] { 1, 5 }, new int[] { 12, 8 }, new int[] { 25, 9 } };
var sln = new Solution();
var result = sln.HardestWorker(70, logs);
Console.WriteLine(result);
