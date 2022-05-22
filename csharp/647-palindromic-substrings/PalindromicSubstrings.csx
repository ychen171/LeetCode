public class Solution
{
    // DP | Tabulation 
    // Time: O(n^2)
    // Space: O(n^2)
    public int CountSubstrings(string s)
    {
        int n = s.Length;
        if (n == 1)
            return 1;

        bool[,] table = new bool[n, n]; // start, end
        int count = 0;
        // base case: len == 1
        for (int i = 0; i < n; i++) // len == 1
        {
            table[i, i] = true;
            count++;
        }
        // base case: len == 2
        for (int i = 0; i < n - 1; i++) // len == 2
        {
            if (s[i] == s[i + 1])
            {
                table[i, i + 1] = true;
                count++;
            }
        }

        // from len == 3 to len == n 
        // iterate through every start,end pair / substring
        // check if it is palindrome
        for (int len = 3; len <= n; len++)
        {
            for (int start = 0; start < n; start++)
            {
                int end = start + len - 1;
                if (end >= n)
                    continue;

                // check [start+1, end-1] to see if it is a palindrome
                if (table[start + 1, end - 1])
                {
                    if (s[start] == s[end])
                    {
                        table[start, end] = true;
                        count++;
                    }
                }
            }
        }

        return count;
    }

    // expand from center
    // Time: O(n^2)
    // Space: O(1)
    public int CountSubstrings1(string s)
    {
        int n = s.Length;
        if (n == 1)
            return 1;

        int count = 0;
        for (int i = 0; i < n; i++)
        {
            // check odd len
            int countOdd = ExpandFromCenter(s, i, i);
            // check even len
            int countEven = ExpandFromCenter(s, i, i + 1);
            count += countOdd + countEven;
        }

        return count;
    }

    private int ExpandFromCenter(string s, int left, int right)
    {
        int count = 0;
        while (left >= 0 && right < s.Length)
        {
            if (s[left] != s[right])
                break;
            count++;
            left--;
            right++;
        }

        return count;
    }
}
