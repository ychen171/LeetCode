public class Solution
{
    // Monotonic Stack 
    // Time: O(n)
    // Space: O(n)
    public int[] DailyTemperatures(int[] temperatures)
    {
        int n = temperatures.Length;
        int[] result = new int[n];
        // Stack definition: contains the index whose value is greater than the value at current index i
        var stack = new Stack<int>();
        for (int i = n - 1; i >= 0; i--)
        {
            while (stack.Count != 0 && temperatures[stack.Peek()] <= temperatures[i])
                stack.Pop();

            if (stack.Count == 0)
                result[i] = 0;
            else
                result[i] = stack.Peek() - i;
            stack.Push(i);
        }

        return result;
    }

    // Stack | easy to understand
    public int[] DailyTemperatures1(int[] temperatures)
    {
        int n = temperatures.Length;
        int[] result = new int[n];
        var stack = new Stack<int>();
        int i = 0;
        while (i < n)
        {
            if (stack.Count == 0 || temperatures[stack.Peek()] >= temperatures[i])
            {
                stack.Push(i);
                i++;
            }
            else
            {
                var top = stack.Pop();
                result[top] = i - top;
            }
        }

        return result;
    }

    public int[] DailyTemperatures2(int[] temperatures)
    {
        int n = temperatures.Length;
        var result = new int[n];
        var greaterIndex = NextGreaterIndex(temperatures);
        for (int i = 0; i < n; i++)
        {
            var index = greaterIndex[i];
            if (index == -1)
                continue;

            result[i] = index - i;
        }

        return result;
    }

    private int[] NextGreaterIndex(int[] nums)
    {
        int n = nums.Length;
        var result = new int[n];
        var stack = new Stack<int>();
        for (int i = n - 1; i >= 0; i--)
        {
            while (stack.Count != 0 && nums[stack.Peek()] <= nums[i])
                stack.Pop();

            result[i] = stack.Count == 0 ? -1 : stack.Peek();
            stack.Push(i);
        }

        return result;
    }
}
