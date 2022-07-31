public class Solution
{
    int count;
    int lower;
    int upper;
    // Time: O(n log n)
    // Space: O(n)
    public int CountRangeSum(int[] nums, int lower, int upper)
    {
        this.count = 0;
        this.lower = lower;
        this.upper = upper;
        int n = nums.Length;
        var prefixSum = new long[n + 1];
        for (int i = 1; i < n + 1; i++)
            prefixSum[i] = prefixSum[i - 1] + nums[i - 1];

        MergeSort(prefixSum, 0, prefixSum.Length - 1);
        return count;
    }

    public void MergeSort(long[] nums, int lo, int hi)
    {
        // base case
        if (lo >= hi) return;

        // recursive case
        int mid = lo + (hi - lo) / 2;
        MergeSort(nums, lo, mid);
        MergeSort(nums, mid + 1, hi);
        Merge(nums, lo, mid, hi);
    }

    public void Merge(long[] nums, int lo, int mid, int hi)
    {
        int len = hi - lo + 1;
        var temp = new long[len];
        int i, j;

        // count the rang sums lie in [lower, upper]
        
        // // TLE
        // for (i = lo; i <= mid; i++)
        // {
        //     for (j = mid + 1; j <= hi; j++)
        //     {
        //         var diff = nums[j] - nums[i];
        //         if (diff <= upper && diff >= lower)
        //             count++;
        //     }
        // }

        // Sliding Window

        int start = mid + 1, end = mid + 1;
        for (i = lo; i <= mid; i++)
        {
            while (start <= hi && nums[start] - nums[i] < lower)
                start++;
            while (end <= hi && nums[end] - nums[i] <= upper)
                end++;
            count += end - start;
        }

        // [lo, mid] [mid+1, hi]
        i = lo;
        j = mid + 1;
        for (int k = 0; k < len; k++)
        {
            if (i == mid + 1)
                temp[k] = nums[j++];
            else if (j == hi + 1)
                temp[k] = nums[i++];
            else if (nums[i] <= nums[j])
                temp[k] = nums[i++];
            else
                temp[k] = nums[j++];
        }

        for (int k = 0; k < len; k++)
            nums[k + lo] = temp[k];
    }
}
