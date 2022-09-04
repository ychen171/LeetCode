public class Solution
{
    public int LongestNiceSubarray(int[] nums)
    {
        /*
            states: dp[i], i: last index, [0, n-1]
            goal: dp.Max()

            dp[i] = dp[i-1] + 1
            dp[i] = 1

            base case:
            dp[0] = 1

        */
        var n = nums.Length;
        var dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            if (i == 0)
            {
                dp[i] = new int[] { i, i };
                continue;
            }
            bool isNice = true;
            for (int j = dp[i - 1][0]; j <= dp[i - 1][1]; j++)
            {
                if ((nums[j] & nums[i]) != 0)
                {
                    isNice = false;
                    break;
                }
            }
            if (isNice)
                dp[i] = new int[] { dp[i - 1][0], i };
            else
                dp[i] = new int[] { i, i };
        }

        int ans = 0;
        foreach (var item in dp)
        {
            ans = Math.Max(ans, item[1] - item[0] + 1);
        }

        return ans;
    }
}

// var sln = new Solution();
// // var nums = new int[] { 1, 3, 8, 48, 10 };
// var nums = new int[] { 744437702, 379056602, 145555074, 392756761, 560864007, 934981918, 113312475, 1090, 16384, 33, 217313281, 117883195, 978927664 };
// var result = sln.LongestNiceSubarray(nums);
// Console.WriteLine(result);

