public class MergeSort
{
    // Algorithms 4 Version
    // Time: O(n log n)
    // Space: O(n)
    private static int[] temp;
    public static void Sort(int[] nums)
    {
        temp = new int[nums.Length];
        Sort(nums, 0, nums.Length - 1);
    }
    private static void Sort(int[] nums, int lo, int hi)
    {
        // base case
        if (lo >= hi)
            return;

        // recursive case
        var mid = lo + (hi - lo) / 2;
        Sort(nums, lo, mid);
        Sort(nums, mid + 1, hi);
        Merge(nums, lo, mid, hi);
    }

    private static void Merge(int[] nums, int lo, int mid, int hi)
    {
        // copy over original to temp
        for (int k = lo; k <= hi; k++)
            temp[k] = nums[k];
        
        // merge two sorted lists
        int i = lo, j = mid + 1;
        for (int k = lo; k <= hi; k++)
        {
            if (i == mid + 1)
                nums[k] = temp[j++];
            else if (j == hi + 1)
                nums[k] = temp[i++];
            else if (temp[i] > temp[j])
                nums[k] = temp[j++];
            else
                nums[k] = temp[i++];
        }
    }
}

var nums = new int[] { 2, 3, 1, 2, 5, 7, 4, 7 };
MergeSort.Sort(nums);
Console.WriteLine();
foreach (var num in nums)
{
    Console.Write(num + ",");
}
Console.WriteLine();
