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
                sum += (long)nums[index] * count;
            }
            stack.Push(i);
        }

        return (int)(sum % 1000000007);
    }
}
