public class Solution
{
    // Greedy
    // Time: O(n)
    // Space: O(1)
    public int MinAddToMakeValid(string s)
    {
        int need = 0;
        int ans = 0;
        foreach (var c in s)
        {
            if (c == ')')
            {
                if (need == 0)
                    ans++;
                else
                    need--;
            }
            else // c == '('
            {
                need++;
            }
        }
        ans += need;

        return ans;
    }
}
