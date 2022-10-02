public class Solution
{
    public IList<int> GoodIndices(int[] nums, int k)
    {
        int n = nums.Length;
        var result = new List<int>();
        var left = new Stack<int>();
        var right = new Stack<int>();
        // populate left
        for (int i = 0; i < k; i++)
        {
            while (left.Count != 0 && nums[left.Peek()] < nums[i])
                left.Pop();
            left.Push(i);
        }
        // populate right
        for (int i = k + 1; i <= k + k; i++)
        {
            while (right.Count != 0 && nums[right.Peek()] > nums[i])
                right.Pop();
            right.Push(i);
        }
        // find result
        for (int i = k; i < n - k; i++)
        {
            if (((left.Peek() + 1) == i) && right.Count == k) // found
                result.Add(i);

            while (left.Count != 0 && nums[left.Peek()] < nums[i])
                left.Pop();
            left.Push(i);

            while (right.Count != 0 && nums[right.Peek()] > nums[i])
                right.Pop();
            right.Push(i + k);
        }

        return result;
    }

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
var nums = new int[] { 2, 1, 1, 1, 3, 4, 1 };
int k = 2;
var result = sln.GoodIndices(nums, k);
Console.WriteLine(result);

