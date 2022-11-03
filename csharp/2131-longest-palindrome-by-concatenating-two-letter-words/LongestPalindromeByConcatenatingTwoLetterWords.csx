public class Solution
{
    public int LongestPalindrome(string[] words)
    {
        // wordCount dict
        var wordCount = new Dictionary<string, int>();
        foreach (var word in words)
            wordCount[word] = wordCount.GetValueOrDefault(word, 0) + 1;
        var used = new HashSet<string>();
        int result = 0;
        bool center = false;
        foreach (var word in wordCount.Keys)
        {
            if (used.Contains(word))
                continue;
            var reversedWord = new string(word.ToCharArray().Reverse().ToArray());
            if (word == reversedWord)
            {
                if (wordCount[word] % 2 == 0)
                    result += 2 * wordCount[word];
                else
                {
                    result += 2 * (wordCount[word] - 1);
                    center = true;
                }
            }
            else if (wordCount.ContainsKey(reversedWord))
            {
                result += 4 * Math.Min(wordCount[word], wordCount[reversedWord]);
                used.Add(word);
                used.Add(reversedWord);
            }
        }
        if (center)
            result += 2;
        return result;
    }
}
// Dictionary
// Time: O(n)
// Space: O(n)
var sln = new Solution();
var words = new string[]{"lc","cl","gg"};
var result = sln.LongestPalindrome(words);
Console.WriteLine(result);
