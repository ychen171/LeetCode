public class Solution 
{
    // Sliding Window
    // Time: O(n)
    // Space: O(1)
    public int MaxScore(int[] cardPoints, int k) 
    {
        // sliding window to find min subarray sum, where window size == n - k
        // result = totalSum - minSum
        int n = cardPoints.Length;
        if (n == k)
            return cardPoints.Sum();
        int windowSum = 0;
        int minSum = int.MaxValue;
        int totalSum = 0;
        int left = 0, right = 0;
        // [left, right)
        while (right < n)
        {
            totalSum += cardPoints[right];
            windowSum += cardPoints[right];
            right++;
            
            if (right - left > n - k)
            {
                windowSum -= cardPoints[left];
                left++;
            }
            
            if (right - left == n - k)
                minSum = Math.Min(minSum, windowSum);
        }
        return totalSum - minSum;
    }
}

var s = new Solution();
var cardPoints = new int[] { 1, 2, 3, 4, 5, 6, 1 };
var k = 3;
var result = s.MaxScore(cardPoints, k);
Console.WriteLine(result);
