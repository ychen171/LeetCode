public class Solution
{
    // Monotonic Stack | TLE
    // Time: O(n^2)
    // Space: O(n)
    public int TotalStrength(int[] strength)
    {
        long MOD = 1000000007;
        // subarray + sum => prefix sum
        // subarray + min => mono stack
        // sum of first k elements
        int n = strength.Length;
        var prefix = new long[n + 1];
        for (int i = 0; i < n; i++)
            prefix[i + 1] = (prefix[i] + strength[i]) % MOD;
        // sum of first k prefixes
        var prefixSum = new long[n + 2];
        for (int i = 0; i < n + 1; i++)
            prefixSum[i + 1] = (prefixSum[i] + prefix[i]) % MOD;


        // find the next lesser element on the right
        // find the next lesser or equal element on the left
        // foreach strength[i] as min, find the possible subarray sums

        var stack = new Stack<int>();
        var right = new int[n];
        for (int i = n - 1; i >= 0; i--)
        {
            while (stack.Count != 0 && strength[i] <= strength[stack.Peek()])
                stack.Pop();
            // strength[i] > strength[stack.Peek()]
            right[i] = stack.Count == 0 ? n : stack.Peek();
            stack.Push(i);
        }

        stack.Clear();
        var left = new int[n];
        for (int i = 0; i < n; i++)
        {
            while (stack.Count != 0 && strength[i] < strength[stack.Peek()])
                stack.Pop();
            // strength[stack.Peek()] <= strength[i]
            left[i] = stack.Count == 0 ? -1 : stack.Peek();
            stack.Push(i);
        }

        long ans = 0;
        for (int i = 0; i < n; i++)
        {
            int leftLimit = left[i];
            int rightLimit = right[i];
            ans += ((prefixSum[rightLimit + 1] - prefixSum[i + 1]) * (i - leftLimit) % MOD + MOD * 2 - (prefixSum[i + 1] - prefixSum[leftLimit + 1]) * (rightLimit - i) % MOD) % MOD * strength[i] % MOD;
            // ans += ((prefixSum[rightLimit + 1] - prefixSum[i + 1]) * (i - leftLimit) - (prefixSum[i + 1] - prefixSum[leftLimit + 1]) * (rightLimit - i)) * strength[i];
            ans %= MOD;
        }

        return (int)(ans);
    }

    // Brute force | TLE
    // Time: O(n^2)
    // Space: O(n)
    public int TotalStrength1(int[] strength)
    {
        int n = strength.Length;
        var preSum = new int[n + 1];
        for (int i = 0; i < n; i++)
            preSum[i + 1] = preSum[i] + strength[i];

        long ans = 0;
        // [i, j]
        for (int i = 0; i < n; i++)
        {
            int min = strength[i];
            for (int j = i; j < n; j++)
            {
                // find min
                // find sum
                int sum = preSum[j + 1] - preSum[i];
                min = Math.Min(min, strength[j]);
                ans += min * sum;
                ans %= 1000000007;
            }
        }

        return (int)(ans % 1000000007);
    }
}

var sln = new Solution();
// var strength = new int[] { 1, 3, 1, 2 };
var strength = new int[] { 3, 3, 2, 2, 3, 2 };
var result = sln.TotalStrength(strength);
Console.WriteLine(result);

