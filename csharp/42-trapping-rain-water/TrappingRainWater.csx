public class Solution
{
    // Two Pointers
    // Time: O(n)
    // Space: O(1)
    public int Trap(int[] height)
    {
        // two pointers, two directions
        // left = 0, right = n - 1
        // h[left] < h[right], move left
        // h[left] >= h[right],, move right
        // in each move, find the left/rightMaxHeight
        // if h[left/right] < left/rightMaxHeight, add maxHeight - h[left/right] to ans
        int left = 0;
        int right = height.Length - 1;
        int leftMaxHei = 0;
        int rightMaxHei = 0;
        int ans = 0;
        while (left < right)
        {
            if (height[left] < height[right])
            {
                if (height[left] < leftMaxHei)
                    ans += leftMaxHei - height[left];
                else
                    leftMaxHei = height[left];
                left++;
            }
            else
            {
                if (height[right] < rightMaxHei)
                    ans += rightMaxHei - height[right];
                else
                    rightMaxHei = height[right];
                right--;
            }
        }

        return ans;
    }

    // Stack | mono decreasing
    // Time: O(n)
    // Space: O(n)
    public int Trap1(int[] height)
    {
        // height = [0,1,0,2,1,0,1,3,2,1,2,1]
        var stack = new Stack<int>();
        int n = height.Length;
        stack.Push(0);
        int ans = 0;
        for (int i= 1; i < n; i++)
        {
            while (stack.Count != 0 && height[stack.Peek()] < height[i])
            {
                int currIndex = stack.Pop();
                if (stack.Count == 0)
                    break;
                int currHeight = height[currIndex];
                int wid = i - stack.Peek() - 1;
                int hei = Math.Min(height[i], height[stack.Peek()]) - currHeight;
                ans += wid * hei;
            }
            stack.Push(i);
        }

        return ans;
    }
}
