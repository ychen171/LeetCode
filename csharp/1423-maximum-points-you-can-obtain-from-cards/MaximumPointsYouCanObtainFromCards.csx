public class Solution
{
    // Sliding Window
    // Time: O(n)
    // Space: O(1)
    public int MaxScore(int[] cardPoints, int k)
    {
        // sliding window, keep the window size == n - k
        // find the window with min sum
        int n = cardPoints.Length;
        int windowSize = n - k;
        // edge case
        if (windowSize < 0)
            return -1;

        int left = 0;
        int right = 0;
        int windowSum = 0;
        while (right < windowSize)
        {
            windowSum += cardPoints[right];
            right++;
        }
        int minWindowSum = windowSum;
        // [left, right)
        // keep the window size, slide the window to right
        while (right < n)
        {
            windowSum = windowSum - cardPoints[left] + cardPoints[right];
            minWindowSum = Math.Min(minWindowSum, windowSum);
            left++;
            right++;
        }

        return cardPoints.Sum() - minWindowSum;
    }
}

var s = new Solution();
var cardPoints = new int[] { 1, 2, 3, 4, 5, 6, 1 };
var k = 3;
var result = s.MaxScore(cardPoints, k);
Console.WriteLine(result);
