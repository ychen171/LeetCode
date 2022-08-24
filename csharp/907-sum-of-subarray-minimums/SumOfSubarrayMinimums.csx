public class Solution
{
    // Brute force
    // Time: O(n^2)
    // Space: O(1)
    public int SumSubarrayMins(int[] arr)
    {
        // Two Pointers
        // iterate through each subarray
        // foreach subarray, find the min, and add to the sum

        int n = arr.Length;
        int sum = 0;
        int mod = (int)Math.Pow(10, 9) + 7;
        for (int i = 0; i < n; i++)
        {
            int min = arr[i];
            for (int j = i; j < n; j++)
            {
                if (j > i && arr[j] < min)
                {
                    min = arr[j];
                }
                Console.WriteLine(min);
                sum += min;
                sum %= mod;
            }
        }

        return sum;
    }

    // Monotonic Stack
    // Time: O(n)
    // Space: O(n)
    public int SumSubarrayMins1(int[] arr)
    {
        // stack stores index
        // the values at the index are monotinically increasing
        // the value at the top index is the current max in the stack
        // iterate through arr
        // for each index, num, 
        // if num < the value at the top index, found the new min, 
        // pop the stack, for its value (max), count the number of subarrays whose min is this value, and update Sum
        // keep poping until num >= the value at top index
        // push index to stack (keeps it mono increasing)
        var stack = new Stack<int>();
        stack.Push(-1);
        var nums = arr.ToList();
        nums.Add(0);
        long sum = 0;
        for (int i = 0; i < nums.Count; i++)
        {
            int num = nums[i];
            while (stack.Count > 1 && nums[stack.Peek()] > num)
            {
                int index = stack.Pop();
                Console.WriteLine($"i:{i}, index:{index}, top:{stack.Peek()}");
                int leftRange = index - stack.Peek();
                int rightRange = i - index;
                int count = leftRange * rightRange;
                Console.WriteLine($"left: {leftRange}, right:{rightRange}, count:{count}");
                Console.WriteLine($"{index}: {nums[index]}");
                sum += (long)nums[index] * count;
            }
            stack.Push(i);
        }

        return (int)(sum % 1000000007);
    }

    // Monotonic Stack
    // Time: O(n)
    // Space: O(n)
    public int SumSubarrayMins2(int[] arr)
    {
        var stack = new Stack<int>();
        // find the next lesser element
        // iterate from right to left
        int n = arr.Length;
        stack.Push(n);
        long sum = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            while (stack.Count > 1 && arr[i] <= arr[stack.Peek()])
            {
                int index = stack.Pop();
                int leftRange = index - i;
                int rightRange = stack.Peek() - index;
                int count = leftRange * rightRange;
                sum += (long)arr[index] * count;
                sum %= 1000000007;
            }
            stack.Push(i);
        }

        while (stack.Count > 1)
        {
            int index = stack.Pop();
            int leftRange = index - (-1);
            int rightRange = stack.Peek() - index;
            int count = leftRange * rightRange;
            sum += (long)arr[index] * count;
            sum %= 1000000007;
        }

        return (int)(sum % 1000000007);
    }

    public int[] NextLesserElement(int[] nums)
    {
        int n = nums.Length;
        var result = new int[n];
        var stack = new Stack<int>();
        for (int i = n - 1; i >= 0; i--)
        {
            var num = nums[i];
            while (stack.Count != 0 && num <= stack.Peek())
                stack.Pop();
            result[i] = stack.Count == 0 ? -1 : stack.Peek();
            stack.Push(num);
        }

        return result;
    }
}

var sln = new Solution();
// var nums = new int[] { 3, 1, 2, 4 };
var nums = new int[] { 3, 3, 2, 2, 3, 2 };
var result = sln.NextLesserElement(nums);
Console.WriteLine(result);

