public class Solution
{
    public int FindMinDifference(IList<string> timePoints)
    {
        int n = timePoints.Count;
        var intList = new List<int>();
        // convert time string to int [0, 23 * 60 + 59], length = 24 * 60
        foreach (string timeStr in timePoints)
        {
            var parts = timeStr.Split(new char[] { ':' });
            int hour = int.Parse(parts[0]);
            int minute = int.Parse(parts[1]);
            intList.Add(hour * 60 + minute);
        }
        // sort the list
        intList.Sort();
        // iterate through the sorted list and find the difference
        int ans = int.MaxValue;
        for (int i = 1; i < n; i++)
        {
            int diff = intList[i] - intList[i - 1];
            ans = Math.Min(ans, diff);
        }

        ans = Math.Min(ans, intList[0] + 24 * 60 - intList.Last());

        return ans;
    }
}
