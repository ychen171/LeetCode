public class Solution
{
    // Time: O(n)
    // Space: O(n)
    public int CountValidWords(string sentence)
    {
        // split sentence by ' '
        string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // check every word
        int ans = 0;
        foreach (string word in words)
        {
            bool seenHyphen = false;
            bool seenPunctuation = false;
            bool valid = true;
            for (int i = 0; i < word.Length; i++)
            {
                char curr = word[i];
                if (char.IsNumber(curr))
                {
                    valid = false;
                    break;
                }

                if (curr == '-')
                {
                    if (seenHyphen)
                    {
                        valid = false;
                        break;
                    }
                    seenHyphen = true;
                    // invalid
                    if (i == 0 || i == word.Length - 1)
                    {
                        valid = false;
                        break;
                    }
                    var prev = word[i - 1];
                    var next = word[i + 1];
                    if (!char.IsLower(prev) || !char.IsLower(next))
                    {
                        valid = false;
                        break;
                    }
                }
                else if (curr == '.' || curr == ',' || curr == '!')
                {
                    if (seenPunctuation)
                    {
                        valid = false;
                        break;
                    }

                    seenPunctuation = true;
                    if (i != word.Length - 1)
                    {
                        valid = false;
                        break;
                    }
                }
            }
            if (valid) ans++;
        }

        return ans;
    }
}
