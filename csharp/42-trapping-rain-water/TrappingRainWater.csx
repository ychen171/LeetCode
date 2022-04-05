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
}
