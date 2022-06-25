public class Solution
{
    // mono stack
    // Time: O(n)
    // Space: O(n)
    public bool CheckPossibility(int[] nums)
    {
        // mono increasing from left to right
        // [4, 2, 3]
        // 4
        // 1 2
        // 1 2 3

        // [4, 2, 1]
        // 4
        // 1 2
        // 1 2 

        // [1, 4, 3]
        // 1
        // 1 4
        // 1 4 5

        // [3, 4, 2, 3]
        // 3
        // 3 4
        // 3 4 

        int n = nums.Length;
        if (n == 1)
            return true;

        var stack = new Stack<int>();
        stack.Push(nums[0]);
        bool isModified = false;
        for (int i = 1; i < n; i++)
        {
            if (stack.Peek() > nums[i])
            {
                if (isModified)
                    return false;

                var prev = stack.Pop();
                var curr = nums[i];
                if (stack.Count == 0 || stack.Peek() <= curr)
                {
                    stack.Push(curr);
                    stack.Push(curr);
                }
                else
                {
                    stack.Push(prev);
                    stack.Push(prev);
                }
                isModified = true;
            }
            else
            {
                stack.Push(nums[i]);
            }
        }

        return true;
    }
}
