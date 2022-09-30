public class Solution
{
    // Prefix | DP | Two Pointers
    // Time: O(n)
    // Space: O(n)
    public IList<int> GoodIndices(int[] nums, int k)
    {
        int n = nums.Length;
        var result = new List<int>();
        // precompute the length of descreasing to the left of each index (inclusive)
        // precompute the length of increasing to the right of each index (inclusive)
        var des = new int[n];
        des[0] = 1;
        for (int i = 1; i < n; i++)
        {
            if (nums[i - 1] >= nums[i])
                des[i] = des[i - 1] + 1;
            else
                des[i] = 1;

        }
        var inc = new int[n];
        inc[n - 1] = 1;
        for (int i = n - 2; i >= 0; i--)
        {
            if (nums[i] <= nums[i + 1])
                inc[i] = inc[i + 1] + 1;
            else
                inc[i] = 1;
        }

        for (int i = k; i < n - k; i++)
        {
            if (des[i - 1] >= k && inc[i + 1] >= k)
                result.Add(i);
        }

        return result;
    }
    // Brute force | TLE
    // Time: O(n^2)
    // Space: O(1)
    public IList<int> GoodIndices1(int[] nums, int k)
    {
        int n = nums.Length;
        var result = new List<int>();
        for (int i = k; i < n - k; i++)
        {
            // check i
            if (IsMonoDecreasing(nums, i - k, i - 1) && IsMonoIncreasing(nums, i + 1, i + k))
                result.Add(i);
        }
        return result;
    }

    // [i, j]
    public bool IsMonoDecreasing(int[] nums, int i, int j)
    {
        if (i == j)
            return true;
        for (int k = i + 1; k <= j; k++)
        {
            if (nums[k - 1] < nums[k])
                return false;
        }
        return true;
    }

    // [i, j]
    public bool IsMonoIncreasing(int[] nums, int i, int j)
    {
        if (i == j)
            return true;
        for (int k = i + 1; k <= j; k++)
        {
            if (nums[k - 1] > nums[k])
                return false;
        }

        return true;
    }

    public IList<int> GoodIndices2(int[] nums, int k)
    {
        int n = nums.Length;
        var result = new List<int>();
        var leftMinHeap = new PriorityQueue<int[], int[]>(Comparer<int[]>.Create((a, b) =>
        {
            if (a[1] == b[1]) // same num
                return b[0] - a[0];
            return a[1] - b[1];
        }));
        var rightMinHeap = new PriorityQueue<int[], int[]>(Comparer<int[]>.Create((a, b) =>
        {
            if (a[1] == b[1]) // same num
                return a[0] - b[0];
            return a[1] - b[1];
        }));

        for (int i = 0; i < n; i++)
        {
            var num = nums[i];
            var element = new int[] { i, num };
            leftMinHeap.Enqueue(element, element);
            rightMinHeap.Enqueue(element, element);
            if (i >= 2 * k)
            {
                if (leftMinHeap.Peek()[1] >= nums[i - k] && rightMinHeap.Peek()[1] >= nums[i - k])
                    result.Add(i - k);
            }
        }

        return result;
    }

}

var sln = new Solution();
var nums = new int[] { 878724, 201541, 179099, 98437, 35765, 327555, 475851, 598885, 849470, 943442 };
var k = 4;
var result = sln.GoodIndices(nums, k);
Console.WriteLine(result);
