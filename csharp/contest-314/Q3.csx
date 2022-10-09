public class Solution
{
    public string RobotWithString(string s)
    {
        /*
            p           s               t
                        bydizfve            
                                        bdda
            a                           bdd
        */
        var charToIndex = new int[26];
        int n = s.Length;
        for (int i = 0; i < n; i++)
        {
            var c = s[i];
            charToIndex[c - 'a'] = i + 1;
        }
        // reverse substring before secondStart, and append substring from secondStart
        int secondStart = n;
        for (int k = 0; k < 26; k++)
        {
            if (charToIndex[k] != 0)
            {
                secondStart = charToIndex[k];
                break;
            }
        }
        var sb = new StringBuilder();
        for (int i = secondStart - 1; i >= 0; i--)
        {
            sb.Append(s[i]);
        }
        for (int i = secondStart; i < n; i++)
        {
            sb.Append(s[i]);
        }
        return sb.ToString();
    }
}

/*
in: "bydizfve"

ou: "bdevfziy"
*/
var s = "bydizfve";
var sln = new Solution();
var result = sln.RobotWithString(s);
Console.WriteLine(result);
