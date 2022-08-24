public class Solution
{
    // Monotonic Stack | TLE
    // Time: O(n^2)
    // Space: O(n)
    public int TotalStrength(int[] strength)
    {
        // create prefix sum
        var preSum = new int[strength.Length + 1];
        for (int i = 0; i < strength.Length; i++)
            preSum[i + 1] = preSum[i] + strength[i];

        // find the next lesser element
        // iterate from left to right
        var stack = new Stack<int>();
        var nums = strength.ToList();
        nums.Add(0);
        stack.Push(-1);
        long ans = 0;
        int count = 0;
        for (int i = 0; i < nums.Count; i++)
        {
            while (stack.Count > 1 && nums[i] <= nums[stack.Peek()]) // found new small
            {
                // (leftLimit, rightLimit)
                int index = stack.Pop();
                int leftLimit = stack.Peek();
                int rightLimit = i;
                Console.WriteLine($"leftLimit:{leftLimit}, rightLimit:{rightLimit}");
                int leftRange = index - leftLimit;
                int rightRange = rightLimit - index;
                // [l, r]
                for (int l = index; l > leftLimit; l--)
                {
                    for (int r = index; r < rightLimit; r++)
                    {
                        ans += (preSum[r + 1] - preSum[l]) * nums[index];
                    }
                }
                ans %= 1000000007;
            }
            stack.Push(i);
        }

        Console.WriteLine($"count:{count}");
        return (int)(ans % 1000000007);
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

