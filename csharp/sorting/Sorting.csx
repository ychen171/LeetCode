
Console.WriteLine("Hello world!");

public List<int> MergeSort(List<int> nums)
{
    if (nums.Count <= 1) return nums;
    var mid = nums.Count / 2;
    var left = new List<int>();
    var right = new List<int>();
    for (int i = 0; i < mid; i++)
        left.Add(nums[i]);
    for (int j = mid; j < nums.Count; j++)
        right.Add(nums[j]);
    left = MergeSort(left);
    right = MergeSort(right);
    return Merge(left, right);
}

public List<int> Merge(List<int> left, List<int> right)
{
    var result = new List<int>();
    int i = 0;
    int j = 0;
    while (i < left.Count && j < right.Count)
    {
        if (left[i] < right[j])
        {
            result.Add(left[i]);
            i++;
        }
        else
        {
            result.Add(right[j]);
            j++;
        }
    }

    while (i < left.Count)
    {
        result.Add(left[i]);
        i++;
    }

    while (j < right.Count)
    {
        result.Add(right[j]);
        j++;
    }

    return result;
}

var nums = new List<int>() { 4, 3, 2, 1 };
var result = MergeSort(nums);
Console.WriteLine(result);

// Time: O(n log n)
// Space: O(n)
public void MergeSort(List<int> nums, int start, int end)
{
    // base case
    if (start >= end) return;
    // divide
    var mid = start + (end - start) / 2;
    // conquer
    MergeSort(nums, start, mid);
    MergeSort(nums, mid + 1, end);
    // combine
    Merge(nums, start, mid, end);
}

public void Merge(List<int> nums, int start, int mid, int end)
{
    var result = new List<int>();
    int i = start, j = mid + 1;
    while (i <= mid && j <= end)
    {
        if (nums[i] < nums[j])
            result.Add(nums[i++]);
        else
            result.Add(nums[j++]);
    }
    while (i <= mid)
        result.Add(nums[i++]);
    while (j <= end)
        result.Add(nums[j++]);

    for (i = start; i <= end; i++)
        nums[i] = result[i - start];
}

nums = new List<int>() { 6, 5, 4, 3, 2, 1 };
MergeSort(nums, 0, nums.Count - 1);
Console.WriteLine(nums);

// Time: O(N log N) in average, O(N^2) in worst but very rare
// Space: O(log N) in average, O(N) in worst but very rare
public void QuickSort(int[] nums)
{
    QuickSort(nums, 0, nums.Length - 1);
}
private void QuickSort(int[] nums, int lo, int hi)
{
    if (lo >= hi) return;
    int pivotIndex = Partition(nums, lo, hi);
    QuickSort(nums, lo, pivotIndex - 1);
    QuickSort(nums, pivotIndex + 1, hi);
}
private int Partition(int[] nums, int lo, int hi)
{
    // pick the last element hi as a pivot
    // return the index of pivot value in the sorted array
    int pivot = nums[hi];
    int left = lo; // temp pivot index
    for (int right = lo; right < hi; right++)
    {
        if (nums[right] < pivot)
        {
            Swap(nums, left, right);
            left++;
        }
    }
    Swap(nums, left, hi);
    return left;
}
private void Swap(int[] nums, int left, int right)
{
    var temp = nums[left];
    nums[left] = nums[right];
    nums[right] = temp;
}

var numsArray = new int[] { 6, 5, 4, 3, 2, 1 };
QuickSort(numsArray);
Console.WriteLine(numsArray);
