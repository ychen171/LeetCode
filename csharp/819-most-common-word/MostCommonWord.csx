public class Solution
{
    // Dictionary and HashSet
    // N = paragraph.Length
    // M = banned.Length
    // Time: O(N + M)
    // Space: O(N + M)
    public string MostCommonWord(string paragraph, string[] banned)
    {
        var bannedSet = new HashSet<string>();
        foreach (var bannedWord in banned)
            bannedSet.Add(bannedWord);

        string normalizedString = null;
        var sb = new StringBuilder();
        paragraph = paragraph.ToLower();
        for (int i = 0; i < paragraph.Length; i++)
        {
            var c = paragraph[i];
            if (c >= 'a' && c <= 'z' || c == ' ')
                sb.Append(c);
            else
                sb.Append(' ');
        }
        normalizedString = sb.ToString();
        var words = normalizedString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var wordCountDict = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if (bannedSet.Contains(word)) continue;
            if (wordCountDict.ContainsKey(word))
                wordCountDict[word]++;
            else
                wordCountDict[word] = 1;
        }

        string mostWord = null;
        int mostCount = 0;
        foreach (var kv in wordCountDict)
        {
            if (kv.Value > mostCount)
            {
                mostWord = kv.Key;
                mostCount = kv.Value;
            }
        }

        return mostWord;
    }
}

var s = new Solution();
// Console.WriteLine(s.MostCommonWord("Bob hit a ball, the hit BALL flew far after it was hit.", new string[] { "hit" }));

Console.WriteLine(s.MostCommonWord("Bob. hIt, baLl", new string[] { "bob", "hit" }));
