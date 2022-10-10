public class Solution 
{
    // Merge Sort
    // Time: O(n log n)
    // Space: O(n)
    int[] temp;
    int count;
    public int ReversePairs(int[] nums) 
    {
        Sort(nums);
        return count;
    }
    
    public void Sort(int[] nums)
    {
        temp = new int[nums.Length];
        Sort(nums, 0, nums.Length - 1);
    }
    
    private void Sort(int[] nums, int lo, int hi)
    {
        // base case
        if (lo >= hi) return;
        // recursive case
        int mid = lo + (hi - lo) / 2;
        Sort(nums, lo, mid);
        Sort(nums, mid + 1, hi);
        Merge(nums, lo, mid, hi);
    }
    
    private void Merge(int[] nums, int lo, int mid, int hi)
    {
        // copy over to temp
        for (int k = lo; k <= hi; k++)
            temp[k] = nums[k];
        
        int i = lo, j = mid + 1;
        for (i = lo; i <= mid; i++)
        {
            long long_num_i = nums[i];
            while (j <= hi && long_num_i > (long) nums[j] * 2)
                j++;
            count += j - mid - 1;
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