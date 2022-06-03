// Prefix Sum | Caching
public class NumArray
{
    int[] prefixSum;
    // Time: O(n)
    // Space: O(n)
    public NumArray(int[] nums)
    {
        int n = nums.Length;
        prefixSum = new int[n + 1];
        for (int i = 1; i < n + 1; i++)
        {
            prefixSum[i] = prefixSum[i - 1] + nums[i - 1];
        }
    }

    // Time: O(1)
    // Space: O(1)
    public int SumRange(int left, int right)
    {
        return prefixSum[right + 1] - prefixSum[left];
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left,right);
 */
