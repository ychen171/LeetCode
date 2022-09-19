public class Solution
{
    // Brute force
    // Time: O(n^2)
    // Space: O(1)
    public IList<IList<int>> PalindromePairs(string[] words)
    {
        /*
            Input: words = ["abcd","dcba","lls","s","sssll"]
            Output: [[0,1],[1,0],[3,2],[2,4]]
            Explanation: The palindromes are ["abcddcba", "dcbaabcd", "slls","llssssll"]
        */
        var result = new List<IList<int>>();
        int n = words.Length;
        var memo = new Dictionary<string, bool>();
        string s1, s2;
        bool valid1 = false, valid2 = false;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                s1 = words[i] + words[j];
                s2 = words[j] + words[i];
                valid1 = false;
                valid2 = false;
                if (memo.ContainsKey(s1))
                    valid1 = memo[s1];
                else
                    valid1 = IsPalindrome(s1);
                if (memo.ContainsKey(s2))
                    valid2 = memo[s2];
                else
                    valid2 = IsPalindrome(s2);

                if (valid1)
                    result.Add(new List<int> { i, j });
                if (valid2)
                    result.Add(new List<int> { j, i });
                memo[s1] = valid1;
                memo[s2] = valid2;
            }
        }

        return result;
    }

    public bool IsPalindrome(string s)
    {
        var k = s.Length;
        int left = 0, right = k - 1;
        while (left < right)
        {
            if (s[left] != s[right])
                return false;
            left++;
            right--;
        }

        return true;
    }
}

var sln = new Solution();
var words = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
var result = sln.PalindromePairs1(words);
Console.WriteLine(result);
