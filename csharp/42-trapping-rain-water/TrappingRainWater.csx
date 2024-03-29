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

    // Two Pointers
    // Time: O(n)
    // Space: O(1)
    public int Trap1(int[] height)
    {
        int leftMaxHei = 0, rightMaxHei = 0;
        int n = height.Length;
        int left = 0, right = n - 1;
        int ans = 0;
        while (left < right)
        {
            leftMaxHei = Math.Max(leftMaxHei, height[left]);
            rightMaxHei = Math.Max(rightMaxHei, height[right]);
            if (leftMaxHei < rightMaxHei)
            {
                ans += leftMaxHei - height[left];
                left++;
            }
            else
            {
                ans += rightMaxHei - height[right];
                right--;
            }
        }

        return ans;
    }

    // Stack | mono decreasing
    // Time: O(n)
    // Space: O(n)
    public int Trap2(int[] height)
    {
        // height = [0,1,0,2,1,0,1,3,2,1,2,1]
        var stack = new Stack<int>();
        int n = height.Length;
        stack.Push(0);
        int ans = 0;
        for (int i = 1; i < n; i++)
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

    // Time: O(n)
    // Space: O(n)
    public int Trap3(int[] height)
    {
        int n = height.Length;
        var leftMax = new int[n];
        var rightMax = new int[n];
        leftMax[0] = height[0];
        rightMax[n - 1] = height[n - 1];
        for (int i = 1; i < n; i++)
            leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
        for (int i = n - 2; i >= 0; i--)
            rightMax[i] = Math.Max(rightMax[i + 1], height[i]);

        int ans = 0;
        for (int i = 1; i < n - 1; i++)
        {
            ans += Math.Min(leftMax[i], rightMax[i]) - height[i];
        }

        return ans;
    }
}
