public class Solution
{
    // Merge Sort
    // Time: O(n log n)
    // Space: O(n)
    long[] temp;
    int lower;
    int upper;
    int count;
    public int CountRangeSum(int[] nums, int lower, int upper)
    {
        this.lower = lower;
        this.upper = upper;
        this.count = 0;
        // prefix sum
        int n = nums.Length;
        var preSum = new long[n + 1];
        for (int i = 0; i < n; i++)
            preSum[i + 1] = preSum[i] + nums[i];

        Sort(preSum);
        return count;
    }

    public void Sort(long[] nums)
    {
        temp = new long[nums.Length];
        Sort(nums, 0, nums.Length - 1);
    }

    private void Sort(long[] nums, int lo, int hi)
    {
        // base case
        if (lo >= hi) return;

        // recursive case
        int mid = lo + (hi - lo) / 2;
        Sort(nums, lo, mid);
        Sort(nums, mid + 1, hi);
        Merge(nums, lo, mid, hi);
    }

    private void Merge(long[] nums, int lo, int mid, int hi)
    {
        for (int k = lo; k <= hi; k++)
            temp[k] = nums[k];

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

        int start = mid + 1, end = mid + 1;
        for (i = lo; i <= mid; i++)
        {
            while (start <= hi && nums[start] - nums[i] < lower)
                start++;
            while (end <= hi && nums[end] - nums[i] <= upper)
                end++;
            count += end - start;
        }

        i = lo;
        j = mid + 1;
        for (int k = lo; k <= hi; k++)
        {
            if (i == mid + 1)
                nums[k] = temp[j++];
            else if (j == hi + 1)
                nums[k] = temp[i++];
            else if (temp[i] > temp[j])
                nums[k] = temp[j++];
            else // temp[i] <= temp[j]
                nums[k] = temp[i++];
        }
    }
}