public class Solution
{
    // Brute force | TLE
    // Time: O(n * k * k * n * k) => O(n^2 * k^3)
    public int[] SumPrefixScores(string[] words)
    {
        int n = words.Length;
        var result = new int[n];
        // foreach word in words, find all prefixes
        // foreach prefix, calculate the score
        var scoreDict = new Dictionary<string, int>();
        for (int i = 0; i < n; i++)
        {
            var word = words[i];
            var prefixes = AllPrefixes(word);
            int sum = 0;
            foreach (var prefix in prefixes) // k
            {
                if (!scoreDict.ContainsKey(prefix))
                {
                    var score = PrefixScore(words, prefix);
                    scoreDict[prefix] = score;
                }
                sum += scoreDict[prefix];

            }
            result[i] = sum;
        }

        return result;
    }

    // Time: O(n * k)
    // Space: O(1)
    public int PrefixScore(string[] words, string prefix)
    {
        int n = words.Length;
        int score = 0;
        for (int i = 0; i < n; i++)
        {
            var word = words[i];
            if (word.Length >= prefix.Length && word.StartsWith(prefix))
                score++;
        }

        return score;
    }

    // Time: O(k)
    // Space: O(k)
    public List<string> AllPrefixes(string word)
    {
        var prefixes = new List<string>();
        var sb = new StringBuilder();
        foreach (var c in word)
        {
            sb.Append(c);
            prefixes.Add(sb.ToString());
        }
        return prefixes;
    }
}
