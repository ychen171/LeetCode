public class Solution
{
    // Time: O(n)
    // Space: O(n)
    public int MinimumRounds(int[] tasks)
    {
        var taskCountDict = new Dictionary<int, int>();
        foreach (var task in tasks)
        {
            taskCountDict[task] = taskCountDict.GetValueOrDefault(task, 0) + 1;
        }

        int ans = 0;

        // [2] = 1, [3] = 2
        // countList = [1, 2]
        // count = 1, ans = -1
        // divisor = count / 3, remainder = 1 or 2
        // remainder == 1 && divisor != 0, ans = divisor + 1
        // remainder == 2, ans = divisor + 1

        foreach (var count in taskCountDict.Values)
        {
            int divisor = count / 3;
            int remainder = count % 3;
            if (remainder == 1 && divisor == 0)
                return -1;
            if ((remainder == 1 && divisor != 0) || remainder == 2)
            {
                ans += (divisor + 1);
            }
            else
            {
                ans += divisor;
            }
        }

        return ans;
    }
}
