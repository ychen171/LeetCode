public class Solution
{
    // Brute force
    // Time: O(k * n)
    // Space: O(1)
    public int[] SumEvenAfterQueries(int[] nums, int[][] queries)
    {
        int n = nums.Length;
        int k = queries.Length;
        var ans = new int[k];
        for (int i = 0; i < k; i++)
        {
            var query = queries[i];
            int val = query[0];
            int index = query[1];
            nums[index] += val;
            ans[i] = SumEven(nums);
        }

        return ans;
    }

    public int SumEven(int[] nums)
    {
        int ans = 0;
        foreach (var num in nums)
        {
            if (num % 2 == 0)
                ans += num;
        }

        return ans;
    }

    // Maintain Array Sum
    // Time: O(n + k)
    // Space: O(1)
    public int[] SumEvenAfterQueries1(int[] nums, int[][] queries)
    {
        int n = nums.Length;
        int k = queries.Length;
        var ans = new int[k];
        int sum = 0;
        // pre calculate array sum
        foreach (var num in nums)
        {
            if (num % 2 == 0)
                sum += num;
        }

        for (int i = 0; i < k; i++)
        {
            var query = queries[i];
            int val = query[0];
            int index = query[1];
            int oldVal = nums[index];
            nums[index] += val;
            int newVal = nums[index];
            if (oldVal % 2 == 0)
                sum -= oldVal;
            if (newVal % 2 == 0)
                sum += newVal;

            ans[i] = sum;
        }

        return ans;
    }
}
