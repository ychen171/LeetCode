public class Solution
{
    // Doesn't work
    // DP | Tabulation 
    // Time: O(S * P)
    // Space: O(S * P)
    public bool IsMatch(string s, string p)
    {
        int sLen = s.Length;
        int pLen = p.Length;
        // corner cases
        if (p == s)
            return true;
        if (pLen > 0 && p.ToCharArray().All(c => c == '*'))
            return true;
        if (pLen == 0 || sLen == 0)
            return false;
        
        // initialize the table
        bool[,] table = new bool[pLen + 1, sLen + 1];
        // seed the trivial answer into the table
        table[0, 0] = true;
        // fill further positions based on current position
        for (int pIndex = 0; pIndex < pLen; pIndex++)
        {
            if (p[pIndex] == '*')
            {
                // find the previous matched substring in s
                int sIndex = 0;
                for (sIndex = 0; sIndex < sLen; sIndex++)
                {
                    if (table[pIndex, sIndex])
                        break;
                }
                // update the table for the zero match
                table[pIndex + 1, sIndex] = table[pIndex, sIndex];
                // update the table for one and more matches
                char prevP = p[pIndex - 1];
                while (sIndex < sLen)
                {
                    if (table[pIndex, sIndex] && (prevP == '.' || prevP == s[sIndex]))
                        table[pIndex + 1, sIndex + 1] = true;
                    sIndex++;
                }
            }
            else if (p[pIndex] == '.')
            {
                // find the previous matched substring in s
                for (int sIndex = 0; sIndex < sLen; sIndex++)
                {
                    if (table[pIndex, sIndex])
                    {
                        // update the table for one match
                        table[pIndex + 1, sIndex + 1] = true;
                    }
                }
            }
            else // p[pIndex] != '*' && p[pIndex] != '.'
            {
                for (int sIndex = 0; sIndex < sLen; sIndex++)
                {
                    // find the previous matched substring in s
                    // and the current character is matched
                    if (table[pIndex, sIndex] && p[pIndex] == s[sIndex])
                    {
                        table[pIndex + 1, sIndex + 1] = true;
                    }
                }
            }
        }

        return table[pLen, sLen];
    }
}