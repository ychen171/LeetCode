public class Solution
{
    // Sliding Window
    // Time: O(n)
    // Space: O(n)
    public int CharacterReplacement(string s, int k)
    {
        /*
            totalCharCount - maxCharCount <= k
        */
        int n = s.Length;
        var window = new int[26];
        int totalCharCount = 0, maxCharCount = 0;
        int result = 0;
        // [left, right)
        int left = 0, right = 0;
        while (right < n)
        {
            // increase window
            var c = s[right];
            right++;
            window[c - 'A']++;
            totalCharCount++;
            maxCharCount = MaxCharCount(window);

            // decrease window
            while (totalCharCount - maxCharCount > k)
            {
                var d = s[left];
                left++;
                window[d - 'A']--;
                totalCharCount--;
                maxCharCount = MaxCharCount(window);
            }

            // update result
            result = Math.Max(result, right - left);
        }
        return result;
    }

    private int MaxCharCount(int[] arr)
    {
        int result = int.MinValue;
        foreach (var count in arr)
            result = Math.Max(result, count);
        return result;
    }
}
