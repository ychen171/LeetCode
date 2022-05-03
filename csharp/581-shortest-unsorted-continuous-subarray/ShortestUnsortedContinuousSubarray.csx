public class Solution
{
    // mono stack
    // Time: O(n)
    // Space: O(n)
    public int FindUnsortedSubarray(int[] nums)
    {
        int n = nums.Length;
        if (n == 1)
            return 0;
        // mono stack (increasing)
        var stack = new Stack<int>();
        int start = n;
        int end = -1;
        for (int i = 0; i < n; i++)
        {
            while (stack.Count != 0 && nums[stack.Peek()] > nums[i])
            {
                int index = stack.Pop();
                start = Math.Min(start, index);
            }
            stack.Push(i);
        }
        // mono stack (descreasing)
        for (int i = n - 1; i >= 0; i--)
        {
            while (stack.Count != 0 && nums[stack.Peek()] < nums[i])
            {
                int index = stack.Pop();
                end = Math.Max(end, index);
            }
            stack.Push(i);
        }

        return start < end ? end - start + 1 : 0;
    }
}
