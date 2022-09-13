public class Solution
{
    // 
    public int LengthOfLIS(int[] nums, int k)
    {
        int n = nums.Length;
        var lastToSeq = new SortedList<int, List<int>>();
        var seq = new List<int>();
        seq.Add(nums[0]);
        lastToSeq.Add(seq.Last(), seq);
        for (int i = 1; i < n; i++)
        {
            var target = nums[i];
            var lasts = lastToSeq.Keys;
            int index = BinarySearchLB(lasts, target);
            if (index == -1 || index == 0)
                lastToSeq.Add(target, new List<int>() { target });
            else
            {
                if (lasts[index] - target <= k)
                {
                    lastToSeq[lasts[index]].Add(target);
                }
                if (target - lasts[index - 1] <= k)
                {
                    var newList = new List<int>(lastToSeq[lasts[index - 1]]);
                    newList.Add(target);
                    lastToSeq.Remove(lasts[index - 1]);
                    lastToSeq.Add(newList.Last(), newList);
                }
                if (lasts[index] - target > k && target - lasts[index - 1] > k)
                {
                    lastToSeq.Add(target, new List<int>(target));
                }
            }
        }
        int ans = int.MinValue;
        foreach (var list in lastToSeq.Values)
        {
            ans = Math.Max(ans, list.Count);
        }

        return ans;
    }

    public int BinarySearchLB(IList<int> nums, int target)
    {
        int n = nums.Count;
        int left = 0;
        int right = n - 1;
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

    // DP
    // Time: O(n^2) | TLE
    // Space: O(n)
    public int LengthOfLIS1(int[] nums, int k)
    {
        /*
            states: dp[i], i: the last index, [0, n-1]
            dp: length of LIS
            options: add to previous, start new
            goal: dp.Max()

            dp[i] = Math.Max(dp[i], dp[j] + 1), j < i, nums[j] < nums[i] && nums[i] - nums[j] <= k

            base case:
            dp[i] = 1; 
        */
        int n = nums.Length;
        var dp = new int[n];
        for (int i = 0; i < n; i++)
            dp[i] = 1;

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i] && nums[i] - nums[j] <= k)
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
            }
        }

        return dp.Max();
    }
}


var sln = new Solution();
var nums = new int[] { 1, 4, 7, 15, 5 };
int k = 1;
var result = sln.LengthOfLIS(nums, k);
Console.WriteLine(result);

