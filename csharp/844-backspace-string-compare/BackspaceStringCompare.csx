public class Solution
{
    // Stack
    // Time: O(m+n)
    // Space: O(m+n)
    public bool BackspaceCompare(string s, string t)
    {
        var sStack = new Stack<char>();
        var tStack = new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (c == '#')
            {
                if (sStack.Count != 0)
                    sStack.Pop();
            }
            else
                sStack.Push(c);
        }
        for (int j = 0; j < t.Length; j++)
        {
            char c = t[j];
            if (c == '#')
            {
                if (tStack.Count != 0)
                    tStack.Pop();
            }
            else
                tStack.Push(c);
        }

        return new string(sStack.ToArray()) == new string(tStack.ToArray());
    }
}
