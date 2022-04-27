public class Solution
{
    // Two Pointers
    // Time: O(n)
    // Space: O(n)
    public bool IsPalindrome(string s)
    {
        var sb = new StringBuilder();
        int n = s.Length;
        int i;
        for (i = 0; i < n; i++)
        {
            var c = s[i];
            if (Char.IsLetterOrDigit(c))
                sb.Append(char.ToLower(c));
        }

        i = 0;
        int j = sb.Length - 1;
        while (i < j)
        {
            if (sb[i] != sb[j])
                return false;
            i++;
            j--;
        }

        return true;
    }

    // Two Pointers
    // Time: O(n)
    // Space: O(1)
    public bool IsPalindrome1(string s)
    {
        int i = 0;
        int j = s.Length - 1;

        while (i < j)
        {
            if (!char.IsLetterOrDigit(s[i]))
            {
                i++;
                continue;
            }
            if (!char.IsLetterOrDigit(s[j]))
            {
                j--;
                continue;
            }

            if (char.ToLower(s[i]) != char.ToLower(s[j]))
            {
                Console.WriteLine($"{s[i]} - {s[j]}");
                return false;
            }
            i++;
            j--;
        }

        return true;
    }
}
