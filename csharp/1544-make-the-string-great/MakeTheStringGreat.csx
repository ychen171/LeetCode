public class Solution
{
    // Stack
    // Time: O(n)
    // Space: O(n)
    public string MakeGood(string s)
    {
        var stack = new Stack<char>();
        int n = s.Length;
        for (int i = 0; i < n; i++)
        {
            if (stack.Count != 0 && stack.Peek() != s[i] && char.ToLower(stack.Peek()) == char.ToLower(s[i]))
                stack.Pop();
            else
                stack.Push(s[i]);
        }
        var cs = new char[stack.Count];
        for (int i = cs.Length - 1; i >= 0; i--)
            cs[i] = stack.Pop();
        return new string(cs);
    }
}
