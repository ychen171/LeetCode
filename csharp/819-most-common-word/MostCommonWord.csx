public class Solution
{
    // Dictionary and HashSet
    // N = paragraph.Length
    // M = banned.Length
    // Time: O(N + M)
    // Space: O(N + M)
    public string MostCommonWord(string paragraph, string[] banned) 
    {
        // split paragraph into list of words
        string[] words = paragraph.ToLower().Split(new char[] {' ', '!', '?', '\'', ',', ';', '.'}, StringSplitOptions.RemoveEmptyEntries);
        // use dictionary to store word: count if it is not banned
        HashSet<string> bannedSet = banned.ToHashSet();
        var dict = new Dictionary<string, int>();
        string result = null;
        int max = 0;
        foreach (string word in words)
        {
            if (bannedSet.Contains(word))
                continue;
            int count = dict.GetValueOrDefault(word, 0) + 1;
            dict[word] = count;
            if (count > max)
            {
                result = word;
                max = count;
            }
        }
        
        return result;
    }
}

var s = new Solution();
// Console.WriteLine(s.MostCommonWord("Bob hit a ball, the hit BALL flew far after it was hit.", new string[] { "hit" }));

Console.WriteLine(s.MostCommonWord("Bob. hIt, baLl", new string[] { "bob", "hit" }));
