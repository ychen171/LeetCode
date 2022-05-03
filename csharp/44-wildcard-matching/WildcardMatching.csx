public class Solution
{
    // Doesn't work
    // DP | Recursion Memoization
    // Time: O(S * P)
    // Space: O(S * P)
    public bool IsMatch(string s, string p)
    {
        // clean up input string p
        var sb = new StringBuilder();
        for (int i = 0; i < p.Length; i++)
        {
            if (sb.Length > 0 && sb[sb.Length - 1] == '*' && p[i] == '*')
                continue;
            sb.Append(p[i]);
        }
        string simplifiedP = sb.ToString();
        Console.WriteLine($"{s} -- {simplifiedP}");
        var memo = new Dictionary<int, bool>();
        return Helper(s, simplifiedP, 0, 0, memo);
    }

    private bool Helper(string s, string p, int sIndex, int pIndex, Dictionary<int, bool> memo)
    {
        Console.WriteLine($"sIndex{sIndex}, pIndex:{pIndex}");
        int key = sIndex * p.Length + pIndex;
        if (memo.ContainsKey(key))
            return memo[key];

        bool result;
        if (pIndex == p.Length - 1 && p[pIndex] == '*')
            result = true;
        else if (pIndex == p.Length && sIndex < s.Length)
            result = false;
        else if (sIndex == s.Length && pIndex < p.Length)
            result = false;
        else if (pIndex == p.Length && sIndex == s.Length)
            result = true;
        else if (p[pIndex] == s[sIndex] || p[pIndex] == '?')
            result = Helper(s, p, sIndex + 1, pIndex + 1, memo);
        else if (p[pIndex] == '*')
            result = Helper(s, p, sIndex, pIndex + 1, memo) || Helper(s, p, sIndex + 1, pIndex, memo) || Helper(s, p, sIndex + 1, pIndex + 1, memo);
        else
            result = false;
        
        memo[key] = result;
        return result;
    }

    // DP | Tabulation
    // Time: O(S * P)
    // Space: O(S * P)
    public bool IsMatch1(string s, string p)
    {
        int sLen = s.Length;
        int pLen = p.Length;
        if (p == s)
            return true;
        if (pLen > 0 && p.ToCharArray().All(x => x == '*'))
            return true;
        if (pLen == 0 || sLen == 0)
            return false;
        
        // initialize the table with default values
        bool[,] table = new bool[pLen + 1, sLen + 1];  
        // seed the trivial answer into the table
        table[0, 0] = true;
        // fill further positions based on default position
        for (int pIndex = 0; pIndex < pLen; pIndex++)
        {
            // the current character in the pattern in '*'
            if (p[pIndex] == '*')
            {
                int sIndex = 0;
                // table[pIndex, sIndex] is a string-pattern match
                // on the previous step, i.e. one character before
                // find the first index in string with the previous match
                for (sIndex = 0; sIndex < sLen; sIndex++)
                {
                    if (table[pIndex, sIndex])
                        break;
                }

                // If (string) matches (pattern),
                // when (string) matches (pattern)* as well
                table[pIndex + 1, sIndex] = table[pIndex, sIndex];

                // If (string) matches (pattern),
                // when (string)(whatever_characters) matches (pattern)* as well
                while (sIndex < sLen)
                {
                    table[pIndex + 1, sIndex + 1] = true;
                    sIndex++;
                }
            }
            // the current character in the pattern is '?'
            else if (p[pIndex] == '?')
            {
                for (int sIndex = 0; sIndex < sLen; sIndex++)
                {
                    table[pIndex + 1, sIndex + 1] = table[pIndex, sIndex];
                }
            }
            // the current character in the pattern is not '*' or '?'
            else 
            {
                for (int sIndex = 0; sIndex < sLen; sIndex++)
                {
                    // match is possible if there is a previous match
                    // and current characters are the same
                    if (table[pIndex, sIndex] && p[pIndex] == s[sIndex])
                        table[pIndex + 1, sIndex + 1] = true;
                }
            }
        }

        return table[pLen, sLen];
    }
}
