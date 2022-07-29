public class Solution
{
    int ans;
    // Time: O(n^2 * log n)
    // Space: O(n)
    public int ReversePairs(int[] nums)
    {
        MergeSort(nums, 0, nums.Length - 1);
        return ans;
    }

    public void MergeSort(int[] nums, int lo, int hi)
    {
        if (lo >= hi)
            return;

        int mid = lo + (hi - lo) / 2;
        MergeSort(nums, lo, mid);
        MergeSort(nums, mid + 1, hi);
        Merge(nums, lo, mid, hi);
    }

    public void Merge(int[] nums, int lo, int mid, int hi)
    {
        int len = hi - lo + 1;
        var merged = new int[len];

        // [mid + 1, end)
        int i = lo;
        int end = mid + 1;

        for (i = lo; i <= mid; i++)
        {
            while (end <= hi && (long)nums[i] > 2 * (long)nums[end])
                end++;

            ans += end - (mid + 1);
        }

        // [lo, mid] [mid + 1, hi]
        i = lo;
        int j = mid + 1;
        for (int k = 0; k < len; k++)
        {
            if (j == hi + 1)
                merged[k] = nums[i++];
            else if (i == mid + 1)
                merged[k] = nums[j++];
            else if (nums[i] <= nums[j])
                merged[k] = nums[i++];
            else
                merged[k] = nums[j++];
        }
        for (int k = 0; k < len; k++)
            nums[lo + k] = merged[k];
    }
}
