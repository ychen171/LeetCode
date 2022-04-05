public class Solution
{
    // Sliding Window
    // Time: O(n)
    // Space: O(1)
    public int LengthOfLongestSubstringTwoDistinct(string s)
    {
        // two pointers, left and right, 
        // sliding window, keeps 2 distinct characters in the window
        // dict stores the rightmost index for each character
        // iterate through the string, 
        // record the rightmost index and check if the number of characters
        // if > 2, find the smallest index in the dict, and its character
        // set left = smallest index + 1, remove the char from the dict
        int left = 0;
        int right = 0;
        var rightMostIndex = new Dictionary<char, int>();
        int maxLen = 0;
        for (right = 0; right < s.Length; right++)
        {
            rightMostIndex[s[right]] = right;
            if (rightMostIndex.Keys.Count > 2)
            {
                int smallestIndex = rightMostIndex.Values.Min();
                char charToRemove = s[smallestIndex];
                left = smallestIndex + 1;
                rightMostIndex.Remove(charToRemove);
            }
            // count of dict.Keys <= 2
            maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen;
    }
}
