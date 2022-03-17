
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


