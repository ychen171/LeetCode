public class Solution
{
    // monotonic stack
    // Time: O(n)
    // Space: O(n)
    public long SubArrayRanges(int[] nums)
    {
        return SumSubArrayMaxs(nums) - SumSubArrayMins(nums);
    }

    public long SumSubArrayMins(int[] nums)
    {
        // next lesser elements
        var stack = new Stack<int>(); // stack of indexes
        stack.Push(-1);
        var list = new List<long>();
        foreach (var num in nums)
            list.Add(num);
        list.Add(long.MinValue);
        long sum = 0;
        for (int i = 0; i < list.Count; i++)
        {
            while (stack.Count > 1 && list[i] <= list[stack.Peek()]) // new min
            {
                var index = stack.Pop();
                // (leftLimit, index] [index, rightLimit)
                var leftLimit = stack.Peek();
                var rightLimit = i;
                var leftRange = index - leftLimit;
                var rightRange = rightLimit - index;
                var count = leftRange * rightRange;
                sum += list[index] * count;
            }
            stack.Push(i);
        }

        return sum;
    }

    public long SumSubArrayMaxs(int[] nums)
    {
        // next greater elements
        var stack = new Stack<int>(); // stack of indexes
        stack.Push(-1);
        var list = new List<long>();
        foreach (var num in nums)
            list.Add(num);
        list.Add(long.MaxValue);
        long sum = 0;
        for (int i = 0; i < list.Count; i++)
        {
            while (stack.Count > 1 && list[i] >= list[stack.Peek()]) // new max
            {
                var index = stack.Pop();
                // (leftLimit, index] [index, rightLimit)
                var leftLimit = stack.Peek();
                var rightLimit = i;
                var leftRange = index - leftLimit;
                var rightRange = rightLimit - index;
                var count = leftRange * rightRange;
                sum += list[index] * count;
            }
            stack.Push(i);
        }

        return sum;
    }
}
