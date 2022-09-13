public class Solution
{
    // DP | Tabulation
    // Time: O(n^2)
    // Space: O(n^2)
    public int LengthOfLIS(int[] nums, int k)
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

    // DP | Segment Tree
    public int LengthOfLIS1(int[] nums, int k)
    {
        int n = nums.Max();
        int ans = 1;
        var seg = new SegmentTree(n);
        foreach (var num in nums)
        {
            var p = num - 1;
            var preMax = seg.Query(Math.Max(0, p - k), p);
            var curMax = preMax + 1;
            ans = Math.Max(ans, curMax);
            seg.Modify(p, curMax);
        }

        return ans;
    }
}

public class SegmentTree
{
    int n;
    int[] tree;
    public SegmentTree(int n)
    {
        this.n = n;
        this.tree = new int[2 * n];
    }
    public SegmentTree(int[] arr)
    {
        this.n = arr.Length;
        this.tree = new int[2 * n];
        for (int i = 0; i < n; i++)
            tree[n + i] = arr[i];
    }

    public void Build()
    {
        for (int i = n - 1; i > 0; i--)
        {
            tree[i] = tree[i << 1] + tree[i << 1 | 1];
        }
    }

    public void Modify(int p, int value)
    {
        p += n;
        tree[p] = value;
        while (p > 1)
        {
            p >>= 1;
            tree[p] = Math.Max(tree[2 * p], tree[2 * p + 1]);
        }
    }

    public int Query(int l, int r) // sum on [l, r)
    {
        int result = 0;
        for (l += n, r += n; l < r; l >>= 1, r >>= 1)
        {
            if (l % 2 == 1) // l is right child
                result = Math.Max(result, tree[l++]);
            if (r % 2 == 1) // r is left child
                result = Math.Max(result, tree[--r]);
        }

        return result;
    }
}

var sln = new Solution();
// nums = [4,2,1,4,3,4,5,8,15], k = 3
var nums = new int[] { 4, 2, 1, 4, 3, 4, 5, 8, 1 };
int k = 3;
var result = sln.LengthOfLIS1(nums, k);
Console.WriteLine(result);

