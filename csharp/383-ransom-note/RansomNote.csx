public class Solution
{
    // Dictionary / Array
    // Time: O(m + n)
    // Space: O(1)
    public bool CanConstruct(string ransomNote, string magazine)
    {
        if (ransomNote.Length > magazine.Length)
            return false;
        
        var noteLetterCount = new int[26];
        var magazineLetterCount = new int[26];

        foreach (var c in ransomNote)
        {
            noteLetterCount[c - 'a']++;
        }

        foreach (var c in magazine)
        {
            magazineLetterCount[c - 'a']++;
        }

        for (int i = 0; i < 26; i++)
        {
            if (noteLetterCount[i] > magazineLetterCount[i])
                return false;
        }
        return true;
    }
}
