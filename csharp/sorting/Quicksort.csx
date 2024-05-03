public class Quicksort
{
    // Time: O(n log n)
    // Space: O(n log n)
    public static void Sort(int[] nums)
    {
        Shuffle(nums);
        Sort(nums, 0, nums.Length - 1);
    }
    private static void Sort(int[] nums, int lo, int hi)
    {
        // base case
        if (lo >= hi)
            return;
        
        // recursive case
        int p = Partition(nums, lo, hi);
        Sort(nums, lo, p - 1);
        Sort(nums, p + 1, hi);
    }
    private static int Partition(int[] nums, int lo, int hi)
    {
        int pivot = nums[lo];
        // nums[lo], nums[lo + 1...hi]
        // nums[lo + 1...j] <= nums[lo] < nums[i...hi]
        int i = lo + 1, j = hi;
        while (i <= j)
        {
            while (i < hi && nums[i] <= pivot)
                i++;
            while (j > lo && nums[j] > pivot)
                j--;

            if (i >= j)
                break;
            Swap(nums, i, j);
        }
        Swap(nums, lo, j);
        // nums[lo...j - 1] <= nums[j] < nums[i...hi]
        return j;
    }

    private static void Shuffle(int[] nums)
    {
        var rand = new Random();
        int n = nums.Length;
        for (int i = 0; i < n; i++)
            Swap(nums, i, rand.Next(i, n));
    }

    private static void Swap(int[] nums, int i, int j)
    {
        var temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}

// var nums = new int[] { 2, 3, 1, 5, 2, 3, 2, 7, 9, 5 };
// Quicksort.Sort(nums);
// Console.WriteLine();
// foreach (var num in nums)
// {
//     Console.Write(num + ",");
// }
// Console.WriteLine();
