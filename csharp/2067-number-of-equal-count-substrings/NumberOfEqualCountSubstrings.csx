public class Solution
{
    // Sliding Window
    // Time: O(26n) or O(n)
    // Space: O(26) or O(1)
    public int EqualCountSubstrings(string s, int count)
    {
        // fixed window size: 1*count, 2*count, 3*count ... 26*count
        // number of unique char: 1, 2, 3, ... 26
        // foreach number of unique char, do sliding window with fixed window size (unique * count)
        int n = s.Length;
        int ans = 0;
        for (int unique = 1; unique <= 26; unique++)
        {
            int l = 0;
            int r = 0;
            int windowSize = unique * count;
            if (windowSize > n)
                break;
            var countArray = new int[26];
            int currUnique = 0;
            // populate countArray for [0, windowSize - 2]
            for (r = 0; r < windowSize - 1; r++)
            {
                countArray[s[r] - 'a']++;
                if (countArray[s[r] - 'a'] == count)
                    currUnique++;
            }

            // sliding window with fixed size, starting from [0, windowSize - 1]
            for (r = windowSize - 1; r < n; r++)
            {
                countArray[s[r] - 'a']++;
                if (countArray[s[r] - 'a'] == count)
                    currUnique++;
                
                if (currUnique == unique)
                    ans++;
                
                countArray[s[l] - 'a']--;
                if (countArray[s[l] - 'a'] == count - 1)
                    currUnique--;
                l++;
            }
        }

        return ans;
    }

    // TLE
    // Sliding Window
    // Time: O(n^2)
    // Space: O(26) or O(1)
    public int EqualCountSubstrings1(string s, int count)
    {
        // sliding window
        // countArray to maintain the count of each letter in the window

        // a a a b c b b c c             count = 3
        // lr
        // l   r                     aaa
        // l     r
        // l               r         aaabcbbcc
        //       l         r         bcbbcc

        // a a a b b b c c c             count = 3
        // l   r                     aaa
        // l         r               aaabbb    bbb
        // l               r         aaabbbccc bbbccc ccc

        int n = s.Length;
        var countArray = new int[26];
        int ans = 0;
        for (int r = 0; r < n; r++)
        {
            char c = s[r];
            countArray[c - 'a']++;
            var copyArray = new int[26];
            countArray.CopyTo(copyArray, 0);
            int currCount = 0;
            for (int l = 0; l <= r; l++)
            {
                if (IsEqualCountString(copyArray, count))
                {
                    currCount++;
                }
                copyArray[s[l] - 'a']--;
            }
            ans += currCount;
        }

        return ans;
    }

    private bool IsEqualCountString(int[] countArray, int count)
    {
        bool ans = true;
        for (int i = 0; i < 26; i++)
        {
            if (countArray[i] != 0 && countArray[i] != count)
            {
                ans = false;
                break;
            }
        }

        return ans;
    }
}

var s = new Solution();
var result1 = s.EqualCountSubstrings("aaabbbccc", 3);
Console.WriteLine(result1);

var result2 = s.EqualCountSubstrings("aaaaaaaa", 4);
Console.WriteLine(result2);
