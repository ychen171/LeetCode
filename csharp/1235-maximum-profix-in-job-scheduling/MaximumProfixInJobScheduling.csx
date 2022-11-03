public class Solution
{
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
    {
        /*
            states: dp[i], i: from i to the end, [0, n-1]
            dp[i]: max profit starting at position i
            goal: dp[0]
            option: j: positions without overlapping with current position i
                    j = [i + 1, n - 1]
            
            dp[i] = Math.Max(dp[i + 1], dp[j] + profit[i]), i and j are not overlapping
            
            base case:
            dp[n-1] = profit[n-1]
        */
        // sort
        int n = startTime.Length;
        var jobs = new int[n][];
        for (int i = 0; i < n; i++)
            jobs[i] = new int[] { startTime[i], endTime[i], profit[i] };
        Array.Sort(startTime, jobs);
        // DP + Binary Search
        var dp = new int[n];
        for (int i = n - 1; i >= 0; i--)
        {
            if (i == n - 1)
            {
                dp[i] = jobs[i][2];
                continue;
            }
            int currProfit = 0;
            int target = jobs[i][1]; // end time
            int nextIndex = BinarySearchLB(startTime, target);
            if (nextIndex == -1) // not found
                currProfit = jobs[i][2];
            else
                currProfit = jobs[i][2] + dp[nextIndex];

            dp[i] = Math.Max(currProfit, dp[i + 1]);
        }
        return dp[0];
    }

    private int BinarySearchLB(int[] nums, int target)
    {
        int n = nums.Length;
        int left = 0, right = n - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] < target)
                left = mid + 1;
            else if (nums[mid] > target)
                right = mid - 1;
            else // ==
                right = mid - 1;
        }
        if (left == n) return -1;
        return left;
    }
}
// Sort + DP + Binary Search
// Time: O(n log n)
// Space: O(n)
