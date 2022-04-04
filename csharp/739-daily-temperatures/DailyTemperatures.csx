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
}
