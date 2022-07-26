public class Solution
{
    // Diff Array
    // Time: O(n)
    // Space: O(n)
    public bool CarPooling(int[][] trips, int capacity)
    {
        // find location range
        int left = int.MaxValue;
        int right = int.MinValue;
        foreach (var trip in trips)
        {
            int from = trip[1];
            int to = trip[2];
            left = Math.Min(left, from);
            right = Math.Max(right, to);
        }
        // create diff array
        int len = right - left + 1;
        var diff = new int[len];
        // update diff array of numPassenger
        foreach (var trip in trips)
        {
            int num = trip[0];
            int from = trip[1];
            int to = trip[2];
            int start = from - left;
            int end = to - left;
            diff[start] += num;
            if (end + 1 < len)
                diff[end] -= num;
        }
        // construct final array of numPassenger
        // check if out of capacity
        if (diff[0] > capacity)
            return false;
        var nums = new int[len];
        nums[0] = diff[0];
        for (int i = 1; i < len; i++)
        {
            nums[i] = nums[i - 1] + diff[i];
            if (nums[i] > capacity)
                return false;
        }
        return true;
    }
}
