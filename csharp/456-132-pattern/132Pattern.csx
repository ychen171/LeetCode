public class Solution
{
    // Mono Stack
    // Time: O(n)
    // Space: O(n)
    public bool Find132pattern(int[] nums)
    {
        // mono stack
        // creat an array of minimum to the left
        // mono stack to store j, starting from right to left, decreasing

        //  1   2   3   4
        //  1   1   1   1

        //  3   1   4   2
        //  3   1   1   1

        //  1   0   1   -4  -3
        //  1   0   0   -4  -3

        int n = nums.Length;
        if (n < 3)
            return false;

        var mins = new int[n];
        mins[0] = nums[0];
        for (int i = 1; i < n; i++)
        {
            if (nums[i] > mins[i - 1])
                mins[i] = mins[i - 1];
            else
                mins[i] = nums[i];
        }

        var stack = new Stack<int>();
        for (int j = n - 1; j >= 0; j--)
        {
            var curr = nums[j];
            if (curr > mins[j]) // k candidate: nums[i] < nums[k]
            {
                while (stack.Count != 0 && nums[stack.Peek()] <= mins[j]) // nums[j] <= nums[i]
                    stack.Pop();

                if (stack.Count != 0 && nums[stack.Peek()] < curr) // nums[i] < nums[j] && nums[j] < nums[k]
                    return true;

                stack.Push(j);
            }
        }

        return false;
    }

    // mono stack
    // Time: O(n)
    // Space: O(n)
    public bool Find132pattern1(int[] nums)
    {
        // creat an array of minimum to the left
        // mono stack to store j, starting from left to right, decreasing

        //  1   2   3   4
        //  1   1   1   1

        //  3   1   4   2
        //  3   1   1   1

        //  1   0   1   -4  -3
        //  1   0   0   -4  -3

        //  3   5   0   3   4
        //  3   3   0   0   0

        int n = nums.Length;
        if (n < 3)
            return false;

        var mins = new int[n];
        mins[0] = nums[0];
        for (int i = 1; i < n; i++)
        {
            if (nums[i] > mins[i - 1])
                mins[i] = mins[i - 1];
            else
                mins[i] = nums[i];
        }

        var stack = new Stack<int>();
        for (int k = 0; k < n; k++)
        {
            while (stack.Count != 0 && nums[stack.Peek()] <= nums[k]) // go up
            {
                stack.Pop();
            }
            if (stack.Count != 0)
            {
                var topIndex = stack.Peek();
                if (mins[topIndex] < nums[topIndex] && mins[topIndex] < nums[k])
                    return true;
            }
            stack.Push(k);
        }

        return false;
    }
}
