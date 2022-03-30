public class Solution
{
    // DP | Top-down | Recursion | Memoization
    // Time: O(N * L * L)
    // Space: O(N)
    public int LongestStrChain(string[] words)
    {
        var memo = new Dictionary<string, int>();
        int globMax = 1;
        HashSet<string> wordSet = words.ToHashSet();
        foreach (string word in words)
        {

            int currMax = Helper(word, wordSet, memo);
            globMax = Math.Max(globMax, currMax);
        }

        return globMax;
    }

    // Time: O(L * L)
    // Space: O(N)
    private int Helper(string word, HashSet<string> words, Dictionary<string, int> memo)
    {
        if (memo.ContainsKey(word)) return memo[word];
        // base case
        if (word.Length == 0 || !words.Contains(word)) return 0;
        int max = 1;
        // recursive case
        for (int i = 0; i < word.Length; i++)
        {
            var newWord = word.Remove(i, 1);
            var currMax = Helper(newWord, words, memo);
            max = Math.Max(max, currMax + 1);
        }

        memo[word] = max;
        return max;
    }

    // DP | Bottom-up | Tabulation | Iteration
    // Time: O(N log N + N * L * L)
    // Space: O(N)
    public int LongestStrChain1(string[] words)
    {
        // initialize table with default value
        int[] table = new int[words.Length];
        // seed the trivial answer into the table
        // sort by length in ascending order
        Array.Sort(words, (a, b) => a.Length - b.Length);
        var wordDict = new Dictionary<string, int>();
        for (int i = 0; i < words.Length; i++)
        {
            wordDict[words[i]] = i;
            table[i] = 1;
        }
        // fill further positions with current position
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            for (int j = 0; j < word.Length; j++)
            {
                string candidate = word.Remove(j, 1);
                if (candidate.Length != 0 && wordDict.ContainsKey(candidate))
                {
                    var index = wordDict[candidate];
                    table[i] = Math.Max(table[i], table[index] + 1);
                }
            }
        }

        return table.Max();
    }
}

var s = new Solution();
Console.WriteLine(s.LongestStrChain1(new string[]{"a","b","ba","bca","bda","bdca"}));
