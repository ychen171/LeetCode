public class ValidWordAbbr
{
    Dictionary<string, HashSet<string>> abbrDict;
    public ValidWordAbbr(string[] dictionary)
    {
        abbrDict = new Dictionary<string, HashSet<string>>();
        foreach (string word in dictionary)
        {
            int len = word.Length;
            string abbr;
            if (len < 3)
                abbr = word;
            else
                abbr = $"{word[0]}{len - 2}{word[len - 1]}";
            
            if (!abbrDict.ContainsKey(abbr))
                abbrDict[abbr] = new HashSet<string>();

            abbrDict[abbr].Add(word);
        }
    }

    public bool IsUnique(string word)
    {
        int len = word.Length;
        string abbr;
        if (len < 3)
            abbr = word;
        else
            abbr = $"{word[0]}{len - 2}{word[len - 1]}";
        
        if (abbrDict.ContainsKey(abbr))
        {
            if (abbrDict[abbr].Count == 1 && abbrDict[abbr].Contains(word))
                return true;
            else
                return false;
        }
        else
            return true;
    }
}

/**
 * Your ValidWordAbbr object will be instantiated and called as such:
 * ValidWordAbbr obj = new ValidWordAbbr(dictionary);
 * bool param_1 = obj.IsUnique(word);
 */
