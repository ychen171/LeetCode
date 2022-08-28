public class Solution
{
    // Sorting + Prefix Sum + Binary Search
    // Time: O(n log n + n + m log n) => O((m + n) log n)
    // Space: O(n)
    public int[] AnswerQueries(int[] nums, int[] queries)
    {
        // sort
        // prefix sum
        // binary search right bound
        int n = nums.Length;
        int m = queries.Length;
        Array.Sort(nums);

        var preSum = new int[n + 1];
        for (int i = 1; i < n + 1; i++)
        {
            preSum[i] = preSum[i - 1] + nums[i - 1];
        }

        var result = new int[m];
        for (int i = 0; i < m; i++)
        {
            var target = queries[i];
            var index = BinarySearchRightBound(preSum, target);
            result[i] = index;
        }
        return result;
    }

    public int BinarySearchRightBound(int[] nums, int target)
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
                left = mid + 1;
        }
        if (right == -1) return -1;
        return right;
    }
}
