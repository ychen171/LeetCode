public class Solution
{
    public int[] SortArray(int[] nums)
    {
        Shuffle(nums);
        Quicksort(nums, 0, nums.Length - 1);
        // MergeSort(nums, 0, nums.Length - 1);
        return nums;
    }

    public void MergeSort(int[] nums, int lo, int hi)
    {
        // base case
        if (lo >= hi)
            return;

        // recursive case
        int mid = lo + (hi - lo) / 2;
        MergeSort(nums, lo, mid);
        MergeSort(nums, mid + 1, hi);

        Merge(nums, lo, mid, hi);
    }

    public void Merge(int[] nums, int lo, int mid, int hi)
    {
        int len = hi - lo + 1;
        var merged = new int[len];
        int i = lo, j = mid + 1;
        // [lo, mid] [mid+1, hi]
        for (int k = 0; k < len; k++)
        {
            if (i == mid + 1)
                merged[k] = nums[j++];
            else if (j == hi + 1)
                merged[k] = nums[i++];
            else if (nums[i] <= nums[j])
                merged[k] = nums[i++];
            else
                merged[k] = nums[j++];
        }

        for (int k = 0; k < len; k++)
            nums[lo + k] = merged[k];
    }

    public void Quicksort(int[] nums, int lo, int hi)
    {
        // base case
        if (lo >= hi)
            return;

        // recursive case
        int pivotIndex = Partition(nums, lo, hi);
        Quicksort(nums, lo, pivotIndex - 1);
        Quicksort(nums, pivotIndex + 1, hi);
    }

    public int Partition(int[] nums, int lo, int hi)
    {
        int pivot = nums[lo];
        int left = lo + 1, right = hi;
        // [lo, left-1] <= pivot && [right+1, hi] > pivot
        while (left <= right)
        {
            while (left < hi && nums[left] <= pivot)
                left++;
            while (right > lo && nums[right] > pivot)
                right--;
            if (left >= right)
                break;
            Swap(nums, left, right);
        }
        Swap(nums, lo, right);

        return right;
    }

    public void Shuffle(int[] nums)
    {
        var rand = new Random();
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            int r = rand.Next(i, n);
            Swap(nums, i, r);
        }
    }

    public void Swap(int[] nums, int left, int right)
    {
        int temp = nums[left];
        nums[left] = nums[right];
        nums[right] = temp;
    }
}

public static void Print(int[] nums)
{
    var sb = new StringBuilder();
    sb.Append('[');
    foreach (var num in nums)
        sb.Append($"{num}, ");

    sb.Remove(sb.Length - 2, 2);
    sb.Append(']');
    Console.WriteLine(sb.ToString());
}

var s = new Solution();
var nums = new int[] { 3, 5, 2, 1, 6, 4, 4 };
Print(nums);
s.MergeSort(nums, 0, nums.Length - 1);
Print(nums);
