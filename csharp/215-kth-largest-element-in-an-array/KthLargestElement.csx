public class Solution
{
    // Sort
    // Time: O(n log n)
    // Space: O(1)
    public int FindKthLargest(int[] nums, int k)
    {
        Array.Sort(nums);
        return nums[nums.Length - k];
    }

    // Priority Queue | Min heap
    // Time: O(n log k)
    // Space: O(k)
    public int FindKthLargestPQ(int[] nums, int k)
    {
        var pq = new PriorityQueue<int, int>();
        foreach (var num in nums)
        {
            pq.Enqueue(num, num);
            if (pq.Count > k)
                pq.Dequeue();
        }
        return pq.Peek();
    }

    // Quickselect
    // Time: O(n) in average, O(n^2) in worst
    // Space: O(1)
    public int FindKthLargestQS(int[] nums, int k)
    {
        Shuffle(nums);
        int n = nums.Length;
        int lo = 0, hi = n - 1;
        int target = n - k;
        while (lo <= hi)
        {
            var pivotIndex = Partition(nums, lo, hi);
            if (pivotIndex < target)
                lo = pivotIndex + 1;
            else if (pivotIndex > target)
                hi = pivotIndex - 1;
            else
                return nums[pivotIndex];
        }

        return -1;
    }

    public void Shuffle(int[] nums)
    {
        var n = nums.Length;
        var rand = new Random();
        for (int i = 0; i < n; i++)
        {
            var r = rand.Next(i, n);
            Swap(nums, i, r);
        }
    }

    public int Partition(int[] nums, int lo, int hi)
    {
        var pivot = nums[lo];
        int left = lo + 1, right = hi;
        // [lo+1, left-1] <= pivot && [right+1, hi] > pivot
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

    public void Swap(int[] nums, int left, int right)
    {
        var temp = nums[left];
        nums[left] = nums[right];
        nums[right] = temp;
    }
}


var s = new Solution();
var result = s.FindKthLargestPQ(new int[] { 3, 2, 1, 5, 6, 4 }, 2);

