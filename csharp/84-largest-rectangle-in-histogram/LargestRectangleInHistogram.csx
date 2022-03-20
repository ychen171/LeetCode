public class Solution
{
    // Brute force
    // Time: O(n^3)
    // Space: O(1)
    public int LargestRectangleArea1(int[] heights)
    {
        int maxArea = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            for (int j = i; j < heights.Length; j++)
            {
                int minHeight = int.MaxValue;
                for (int k = i; k <= j; k++)
                {
                    minHeight = Math.Min(minHeight, heights[k]);
                }
                maxArea = Math.Max(maxArea, minHeight * (j - i + 1));
            }
        }

        return maxArea;
    }

    // Better brute force
    // Time: O(n^2)
    // Space: O(1)
    public int LargestRectangleArea2(int[] heights)
    {
        int maxArea = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            int minHeight = int.MaxValue;
            for (int j = i; j < heights.Length; j++)
            {
                minHeight = Math.Min(minHeight, heights[j]);
                maxArea = Math.Max(maxArea, minHeight * (j - i + 1));
            }
        }

        return maxArea;
    }

    // Divide and Conquer (similar to Quick Sort)
    // Time: O(n log n) in average, O(n^2) in worst
    // Space: O(n)
    public int LargestRectangleArea3(int[] heights)
    {
        return Helper(heights, 0, heights.Length - 1);
    }
    private int Helper(int[] heights, int left, int right)
    {
        // base case
        if (left > right) return 0;
        // divide: shortest bar, everything on the left, everything on the right
        var minIndex = left;
        for (int i = left; i <= right; i++)
        {
            if (heights[minIndex] > heights[i])
            {
                minIndex = i;
            }
        }
        // conquer:
        var wholeArea = heights[minIndex] * (right - left + 1);
        var leftArea = Helper(heights, left, minIndex - 1);
        var rightArea = Helper(heights, minIndex + 1, right);
        // combine
        return Math.Max(wholeArea, Math.Max(leftArea, rightArea));
    }

    // Stack | Width = rightLimit - leftLimit - 1
    // Time: O(n)
    // Space: O(n)
    public int LargestRectangleArea4(int[] heights)
    {
        var stack = new Stack<int>();
        stack.Push(-1);
        int maxArea = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            while (stack.Peek() != -1 && heights[stack.Peek()] >= heights[i])
            {
                var currHeight = heights[stack.Pop()];
                var currWidth = i - stack.Peek() - 1; // rightLimit - leftLimit - 1
                maxArea = Math.Max(maxArea, currHeight * currWidth);
            }
            stack.Push(i);
        }
        while (stack.Peek() != -1)
        {
            var currHeight = heights[stack.Pop()];
            var currWidth = heights.Length - stack.Peek() - 1; // rightLimit - leftLimit - 1
            maxArea = Math.Max(maxArea, currHeight * currWidth);
        }

        return maxArea;
    }
}
 