public class Solution
{
    // Brute force using HashSet
    // Time: O(n^2)
    // Space: O(n^2)
    public int LongestRepeatingSubstring(string s)
    {
        // iterate through every subtring
        // if it has been seen before, its length is the candidate answer
        // get the maximum length from candidates
        var seen = new HashSet<string>();
        int answer = 0;
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i; j < s.Length; j++)
            {
                var candidate = s.Substring(i, j - i + 1);
                if (seen.Add(candidate))
                    continue;
                answer = Math.Max(answer, candidate.Length);
            }
        }

        return answer;
    }

    // Binary Search
    // Time: O(n log n)
    // Space: O(n)
    public int LongestRepeatingSubstring1(string s)
    {
        // n = s.Length
        // the length of the longest substring = [0, n-1]
        // binary search to find mid = the length in [0, n-1]
        // with the given mid/length, find all substrings
        // if any of them has repeating substring, we found the candidate/mid/length
        // we need to find the longest candidate/mid/length, which is right most index
        int n = s.Length;
        int left = 0, right = n - 1;
        while (left < right)
        {
            int mid = left + (right - left + 1) / 2;
            if (HasRepeatingSubstring(s, mid))
                left = mid;
            else
                right = mid - 1;
        }

        return left;
    }

    private bool HasRepeatingSubstring(string s, int length)
    {
        var seen = new HashSet<string>();
        for (int i = 0; i <= s.Length - length; i++)
        {
            var candidate = s.Substring(i, length);
            if (seen.Add(candidate))
                continue;
            return true;
        }

        return false;
    }
}
