public class Solution
{
    // Binary Search
    // Time: O(N + Q log N)
    // Space: O(N)
    public int[] PlatesBetweenCandles(string s, int[][] queries)
    {
        int n = queries.Length;
        var result = new int[n];
        // create candle to index list
        var candleIndexList = new List<int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '|')
                candleIndexList.Add(i);
        }
        // binary search on index list to find left bound and right bound
        for (int i = 0; i < n; i++)
        {
            var q = queries[i];
            int left = BinarySearchLB(candleIndexList, q[0]);
            if (left == -1)
                continue;
            int right = BinarySearchRB(candleIndexList, q[1]);
            if (right == -1)
                continue;
            if (candleIndexList[right] - candleIndexList[left] < 1)
                continue;
            // in the given range, num of plates = num of plates and candles - num of candles
            result[i] = candleIndexList[right] - candleIndexList[left] - (right - left);
        }
        return result;
    }

    private int BinarySearchLB(List<int> nums, int target)
    {
        int n = nums.Count;
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

    private int BinarySearchRB(List<int> nums, int target)
    {
        int n = nums.Count;
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

var sln = new Solution();
var s = "***|**|*****|**||**|*";
var queries = new int[][] { new int[] { 1, 17 } };
var result = sln.PlatesBetweenCandles(s, queries);
Console.WriteLine(result);
