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

    // Hashing
    // Time: O(n * k^2)
    // Space: O(n)
    public IList<IList<int>> PalindromePairs1(string[] words)
    {
        // Build a word -> original index mapping for efficient lookup
        var wordDict = new Dictionary<string, int>();
        int n = words.Length;
        for (int i = 0; i < n; i++)
            wordDict[words[i]] = i;

        // Make a list to put all the palindrome pairs we find in
        var result = new List<IList<int>>();
        foreach (var word in wordDict.Keys)
        {
            var index = wordDict[word];
            var reversedWord = new string(word.Reverse().ToArray());

            // Build result of case 1. This word will be word 1
            if (wordDict.ContainsKey(reversedWord))
            {
                var reversedIndex = wordDict[reversedWord];
                if (index != reversedIndex)
                    result.Add(new List<int> { index, reversedIndex });
            }

            // Build result of case 2. This word will be word 1
            var validPrefixes = AllValidPrefixes(word);
            foreach (var prefix in validPrefixes)
            {
                var reversedPrefix = new string(prefix.Reverse().ToArray());
                if (wordDict.ContainsKey(reversedPrefix))
                {
                    var reversedPrefixIndex = wordDict[reversedPrefix];
                    if (index != reversedPrefixIndex)
                        result.Add(new List<int> { index, reversedPrefixIndex });
                }

            }

            // Build result of case 3. This word will be word 2
            var validSuffixes = AllValidSuffixes(word);
            foreach (var suffix in validSuffixes)
            {
                var reversedSuffix = new string(suffix.Reverse().ToArray());
                if (wordDict.ContainsKey(reversedSuffix))
                {
                    var reversedSuffixIndex = wordDict[reversedSuffix];
                    if (index != reversedSuffixIndex)
                        result.Add(new List<int> { reversedSuffixIndex, index });
                }

            }
        }

        return result;
    }

    public bool IsPalindromeBetween(string word, int l, int r)
    {
        while (l < r)
        {
            if (word[l] != word[r])
                return false;
            l++;
            r--;
        }

        return true;
    }

    public List<string> AllValidPrefixes(string word)
    {
        var validPrefixes = new List<string>();
        int k = word.Length;
        for (int i = 0; i < k; i++)
        {
            if (IsPalindromeBetween(word, i, k - 1))
            {
                validPrefixes.Add(word.Substring(0, i));
            }
        }

        return validPrefixes;
    }

    public List<string> AllValidSuffixes(string word)
    {
        var validSuffixes = new List<string>();
        int k = word.Length;
        for (int i = 0; i < k; i++)
        {
            if (IsPalindromeBetween(word, 0, i))
            {
                validSuffixes.Add(word.Substring(i + 1));
            }
        }

        return validSuffixes;
    }
}

var sln = new Solution();
var words = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
var result = sln.PalindromePairs1(words);
Console.WriteLine(result);
