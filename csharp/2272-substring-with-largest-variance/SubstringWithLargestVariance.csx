public class Solution
{
    // DP + array
    // Time: O(26 * 26 * n) => O(n)
    // Space: O(26) => O(1)
    public int LargestVariance(string s)
    {
        /*
            a   a   b   a   b   b   b
            1   1   -1  1   -1  -1  -1      a = 1, b = -1
            1   2   1   2   1   0   -1      max countA in subarray

            -1  -1  1   -1  1   1   1       a = -1, b = 1
            -1  -1  1   0   1   2   3       max countB in subarray
            0   0   0   0   1   2   3
            01  01  10  11  21  31  41
        */
        int n = s.Length;
        if (n == 1)
            return 0;

        var count = new int[26];
        foreach (var c in s)
            count[c - 'a']++;

        int ans = 0;
        for (char x = 'a'; x <= 'z'; x++)
        {
            int remainCountX = count[x - 'a'];
            if (remainCountX == 0)
                continue;
            for (char y = 'a'; y <= 'z'; y++)
            {
                int remainCountY = count[y - 'a'];
                if (remainCountY == 0)
                    continue;
                if (x == y)
                    continue;
                // find MaxSubArray | Max Window, x = 1, y = -1, rest = 0
                var nums = new int[n];
                for (int i = 0; i < n; i++)
                {
                    var c = s[i];
                    if (c == x)
                        nums[i] = 1;
                    else if (c == y)
                        nums[i] = -1;
                }
                // var max = MaxSubArray(nums);
                int currCountX = 0;
                int currCountY = 0;
                int variance = 0;
                for (int i = 0; i < n; i++)
                {
                    if (nums[i] == 0)
                        continue;
                    if (nums[i] == 1)
                        currCountX++;
                    if (nums[i] == -1)
                    {
                        currCountY++;
                        remainCountY--;
                    }

                    variance = currCountX - currCountY;
                    if (currCountX > 0 && currCountY > 0 && variance > 0)
                        ans = Math.Max(ans, variance);

                    if (variance < 0 && remainCountY >= 1)
                    {
                        currCountX = 0;
                        currCountY = 0;
                    }
                }
            }
        }
        return ans;
    }

    // Time: O(n)
    // Space: O(n)
    public int MaxSubArray(int[] nums)
    {
        /*
            -1  -1  1   -1  1   1   1
            -1  -1  1   0   1   2   3

            states: dp[i], i: [0, n-1]
            options: 1. add curr num to pre sum 2. start sum with curr num
            goal: dp.Max()

            dp[i] = Math.Max(dp[i-1] + nums[i], nums[i]);
            
            base case:
            dp[0] = Math.Max(dp[-1] + nums[0], nums[0]) = nums[0];
        */

        int n = nums.Length;
        var dp = new int[n];
        for (int i = 0; i < n; i++)
        {
            if (i == 0)
            {
                dp[i] = nums[0];
                continue;
            }
            dp[i] = Math.Max(dp[i - 1] + nums[i], nums[i]);
        }

        return dp.Max();
    }

    // Brute force | TLE
    // Time: O(n^2)
    // Space: O(n)
    public int LargestVariance1(string s)
    {
        int n = s.Length;
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                var subStr = s.Substring(i, j - i + 1);
                var diff = Diff(subStr);
                ans = Math.Max(ans, diff);
            }
        }

        return ans;
    }

    private int Diff(string s)
    {
        var count = new Dictionary<char, int>();
        foreach (var c in s)
        {
            count[c] = count.GetValueOrDefault(c, 0) + 1;
        }

        return count.Values.Max() - count.Values.Min();
    }
}

var sln = new Solution();
var s = "lripaa";
var result = sln.LargestVariance(s);
Console.WriteLine(result);
