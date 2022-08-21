public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int MinInsertions(string s)
    {
        var need = 0; // the number of '))' needed
        int ans = 0;
        int n = s.Length;
        for (int i = 0; i < n; i++)
        {
            if (s[i] == '(')
            {
                need++;
            }
            else // s[i] == ')'
            {
                if (i + 1 < n && s[i + 1] == ')')
                {
                    need--; // found '))' that match '('
                    i++;
                }
                else // not the last char or next char == '('
                {
                    ans++; // need to insert ')'
                    need--;
                }
                if (need == -1)
                {
                    need++;
                    ans++;
                }
            }
        }

        ans += need * 2;
        return ans;
    }

    public int MinInsertions1(string s)
    {
        var need = 0; // the number of ')' needed
        int ans = 0;
        int n = s.Length;
        for (int i = 0; i < n; i++)
        {
            if (s[i] == '(')
            {
                need += 2;
                if (need % 2 == 1)
                {
                    ans++;
                    need--;
                }
            }
            else // s[i] == ')'
            {
                need--;
                if (need == -1)
                {
                    ans++;
                    need += 2;
                }
            }
        }

        ans += need;
        return ans;
    }
}
