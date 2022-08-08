public class Solution
{
    // Mono Stack
    // Time: O(n)
    // Space: O(n)
    public int[] NextGreaterElements(int[] nums)
    {
        // nums = [1,2,1], dict = {}
        // 1        
        // 1 2              dict = {[1]=2}
        // 2
        // 2 1
        // 2
        // _                dict = {[1]=2, [2]=-1}

        var n = nums.Length;
        var stack = new Stack<int>(); // store index
        int[] ans = new int[n];
        for (int i = 0; i < n; i++)
            ans[i] = -1;

        for (int i = 0; i < n * 2; i++)
        {
            var index = i % n;
            var num = nums[index];
            while (stack.Count != 0 && nums[stack.Peek()] < num)
            {
                var topIndex = stack.Pop();
                var top = nums[topIndex];
                var curr = ans[topIndex];
                ans[topIndex] = curr == -1 ? num : curr;
            }
            stack.Push(index);
        }

        return ans;
    }


    public int[] NextGreaterElements1(int[] nums)
    {
        int n = nums.Length;
        var stack = new Stack<int>();
        var ans = new int[n];
        for (int i = 2 * n - 1; i >= 0; i--)
        {
            var num = nums[i % n];
            while (stack.Count != 0 && stack.Peek() <= num)
                stack.Pop();

            ans[i % n] = stack.Count == 0 ? -1 : stack.Peek();

            stack.Push(num);
        }

        return ans;
    }
}
