public class Solution
{
    // DP | Tabulation
    // Time: O(m * n)
    // Space: O(m * n)
    public int FindLength(int[] nums1, int[] nums2)
    {
        /*
            states: dp[i][j] the max lenght of a subarray ending at i and j, 
                    i: nums1[0..i], j: nums2[0..j]
            goal: max(dp)
            options:

            dp[i][j] = dp[i-1][j-1] + 1 if nums1[i] == nums[j]

            base case:
            dp[0][0] = 1 if nums[0] == nums[0]
            dp[-1][..] = 0
            dp[..][-1] = 0
        */
        int ans = 0;
        int m = nums1.Length;
        int n = nums2.Length;
        // var dp = new int[m + 1][];
        // for (int i = 0; i < m + 1; i++)
        //     dp[i] = new int[n + 1];
        // for (int i = 1; i < m + 1; i++)
        // {
        //     for (int j = 1; j < n + 1; j++)
        //     {
        //         if (nums1[i - 1] == nums2[j - 1])
        //         {
        //             dp[i][j] = dp[i - 1][j - 1] + 1;
        //             ans = Math.Max(ans, dp[i][j]);
        //         }
        //     }
        // }

        // return ans;
        var dp = new int[m][];
        for (int i = 0; i < m; i++)
            dp[i] = new int[n];
        for (int i = 0; i < m; i++)
        {
            dp[i][0] = nums1[i] == nums2[0] ? 1 : 0;
            ans = Math.Max(ans, dp[i][0]);
        }
        for (int j = 0; j < n; j++)
        {
            dp[0][j] = nums1[0] == nums2[j] ? 1 : 0;
            ans = Math.Max(ans, dp[0][j]);
        }
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                if (nums1[i] == nums2[j])
                {
                    dp[i][j] = Math.Max(dp[i][j], dp[i - 1][j - 1] + 1);
                    ans = Math.Max(ans, dp[i][j]);
                }
            }
        }

        return ans;
    }

    int p = 113;
    int MOD = 1000000007;
    int pinv = 0;
    public int FindLength2(int[] nums1, int[] nums2)
    {
        pinv = ModInverse(p, MOD);
        int m = nums1.Length;
        int n = nums2.Length;

        // Binary Search
        int left = 0, right = Math.Min(m, n) + 1;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (Check(mid, nums1, nums2))
                left = mid + 1;
            else
                right = mid;
        }
        return left - 1;
    }

    public int[] Rolling(int[] source, int length)
    {
        var ans = new int[source.Length - length + 1];
        long h = 0, power = 1;
        if (length == 0)
            return ans;
        for (int i = 0; i < source.Length; i++)
        {
            h = (h + source[i] * power) % MOD;
            if (i < length - 1)
            {
                power = (power * p) % MOD;
            }
            else
            {
                ans[i - (length - 1)] = (int)h;
                h = (h - source[i - (length - 1)]) * pinv % MOD;
                if (h < 0)
                    h += MOD;
            }
        }

        return ans;
    }

    public bool Check(int guess, int[] A, int[] B)
    {
        var hashes = new Dictionary<int, List<int>>();
        int k = 0;
        foreach (int x in Rolling(A, guess))
        {
            hashes.GetValueOrDefault(x, new List<int>()).Add(k);
            k++;
        }
        int j = 0;
        foreach (int x in Rolling(B, guess))
        {
            foreach (int i in hashes.GetValueOrDefault(x, new List<int>()))
            {
                bool matched = true;
                for (int p = 0; p < guess; p++)
                {
                    if (A[i + p] != B[j + p])
                    {
                        matched = false;
                        break;
                    }
                }
                if (matched) return true;
            }
            j++;
        }
        return false;
    }
    public int ModInverse(int a, int m)
    {
        if (m == 1) return 0;
        int m0 = m;
        (int x, int y) = (1, 0);

        while (a > 1)
        {
            int q = a / m;
            (a, m) = (m, a % m);
            (x, y) = (y, x - q * y);
        }
        return x < 0 ? x + m0 : x;
    }
}



// var sln = new Solution();
// var nums1 = new int[] { 1, 2, 3, 2, 8 };
// var nums2 = new int[] { 5, 6, 1, 4, 7 };
// var result = sln.FindLength(nums1, nums2);
// Console.WriteLine(result);

