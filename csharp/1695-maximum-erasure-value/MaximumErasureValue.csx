public class Solution
{
    // Sliding Window
    // Time: O(n)
    // Space: O(n)
    public int MaximumUniqueSubarray(int[] nums) 
    {
        int n = nums.Length;
        var window = new Dictionary<int, int>();
        int windowSum = 0;
        int result = int.MinValue;
        int left = 0, right = 0;
        while (right < n)
        {
            // expand window
            var c = nums[right];
            right++;
            window[c] = window.GetValueOrDefault(c, 0) + 1;
            windowSum += c;
            
            // shrink window
            while (window[c] > 1)
            {
                var d = nums[left];
                left++;
                window[d]--;
                windowSum -= d;
            }
            // update result
            result = Math.Max(result, windowSum);
        }
        
        return result;
    }

    // Sliding Window | Dictionary + Prefix Sum
    // Time: O(n)
    // Space: O(n)
    public int MaximumUniqueSubarray1(int[] nums)
    {
        // sliding window
        // numIndexDict to maintain the window with unique elments
        // 4 2 4 5 6
        // lr        [4]=0     sum=4
        // l r       [4]=0 [2]=1   sum=6
        // l   r     
        //   l r     [4]=2 [2]=1   sum=6
        //   l   r   [4]=2,[2]=1,[5]=3, sum=11
        //   l     r [4]=2,[2]=1,[5]=3,[6]=4  sum=17
        int n = nums.Length;
        // create prefix sum array
        var prefixSum = new int[n + 1];
        // 0 4 6 10 15 21
        for (int i = 1; i < n + 1; i++)
        {
            prefixSum[i] = prefixSum[i - 1] + nums[i - 1];
        }
        var numIndexDict = new Dictionary<int, int>();
        int ans = 0;
        int l = 0;
        for (int r = 0; r < n; r++)
        {
            if (numIndexDict.ContainsKey(nums[r]))
            {
                l = Math.Max(l, numIndexDict[nums[r]] + 1);
            }
            numIndexDict[nums[r]] = r;
            int sum = prefixSum[r + 1] - prefixSum[l];
            ans = Math.Max(ans, sum);
        }

        return ans;
    }
}
