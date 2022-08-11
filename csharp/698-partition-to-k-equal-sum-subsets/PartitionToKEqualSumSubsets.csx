public class Solution
{
    // Backtracking | TLE
    // from the number's perspective
    // Time: O(k^n)
    // Space: O(n)
    public bool CanPartitionKSubsets(int[] nums, int k)
    {
        // edge case
        int n = nums.Length;
        int sum = nums.Sum();
        if (sum % k != 0)
            return false;

        int target = sum / k;
        var buckets = new int[k];
        Array.Sort(nums, (a, b) => b - a);
        return Backtrack(nums, target, buckets, 0);
    }

    public bool Backtrack(int[] nums, int target, int[] buckets, int index)
    {
        // base case
        int n = nums.Length;
        int k = buckets.Length;
        if (index == n)
        {
            foreach (var bucket in buckets)
            {
                if (bucket != target)
                    return false;
            }
            return true;
        }

        // recursive case
        for (int i = 0; i < k; i++)
        {
            var num = nums[index];
            if (buckets[i] + num > target)
                continue;
            buckets[i] += num;
            if (Backtrack(nums, target, buckets, index + 1))
                return true;
            buckets[i] -= num;
        }

        return false;
    }

    // Backtracking + Memoization
    // from the bucket's perspective
    // Time: O(n * 2^n)
    // Space: O(n * 2^n)
    Dictionary<string, bool> memo;
    public bool CanPartitionKSubsets1(int[] nums, int k)
    {
        int n = nums.Length;
        int sum = nums.Sum();
        if (sum % k != 0)
            return false;
        int target = sum / k;
        var used = new char[n];
        memo = new Dictionary<string, bool>();
        return Backtrack1(nums, n, k, target, 0, 0, used, 0);
    }

    public bool Backtrack1(int[] nums, int n, int k, int target, int bucketIndex, int bucket, char[] used, int start)
    {
        var state = new string(used);
        if (memo.ContainsKey(state))
            return memo[state];
        // base case
        if (bucketIndex == k - 1) // skip the last bucket
            return true;


        if (bucket == target)
            return Backtrack1(nums, n, k, target, bucketIndex + 1, 0, used, 0);

        // recursive case
        bool ans = false;
        for (int i = start; i < n; i++)
        {
            if (used[i] == '1')
                continue;
            var num = nums[i];
            if (bucket + num > target)
                continue;

            bucket += num;
            used[i] = '1';
            if (Backtrack1(nums, n, k, target, bucketIndex, bucket, used, i + 1))
            {
                ans = true;
                break;
            }
            bucket -= num;
            used[i] = '0';
        }

        memo[state] = ans;
        return ans;
    }
}
