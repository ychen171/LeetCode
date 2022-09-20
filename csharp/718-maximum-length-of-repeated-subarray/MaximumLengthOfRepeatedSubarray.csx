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
}

// var sln = new Solution();
// var nums1 = new int[] { 1, 2, 3, 2, 8 };
// var nums2 = new int[] { 5, 6, 1, 4, 7 };
// var result = sln.FindLength(nums1, nums2);
// Console.WriteLine(result);

