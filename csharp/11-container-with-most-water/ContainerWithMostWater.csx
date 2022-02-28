public class Solution
{
    // Brute force
    // Time: O(n^2)
    // Space: O(1)
    public int MaxArea(int[] height)
    {
        int max = 0;
        for (int i = 0; i < height.Length - 1; i++)
        {
            for (int j = i + 1; j < height.Length; j++)
            {
                var hi = Math.Min(height[i], height[j]);
                var wi = j - i;
                max = Math.Max(max, hi * wi);
            }
        }

        return max;
    }

    // Two pointer | move the shorter line
    // Time: O(n)
    // Space: O(1)
    public int MaxArea1(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;
        int area = 0;

        while (left < right)
        {
            if (height[left] < height[right])
            {
                area = Math.Max(area, height[left] * (right - left));
                left++;
            }
            else
            {
                area = Math.Max(area, height[right] * (right - left));
                right--;
            }
        }

        return area;
    }
}

