public class Solution
{
    // Stack
    // Time: O(n)
    // Space: O(n)
    public bool IsValid(string s)
    {
        if (s.Length % 2 != 0) return false;
        var dict = new Dictionary<char, char>
        {
            ['('] = ')',
            ['['] = ']',
            ['{'] = '}',
        };
        var stack = new Stack<char>();
        stack.Push(s[0]);
        int i = 1;
        while (i < s.Length)
        {
            if (stack.Count != 0 && dict.ContainsKey(stack.Peek()) && dict[stack.Peek()] == s[i])
            {
                stack.Pop();
            }
            else
            {
                stack.Push(s[i]);
            }
            i++;
        }

        return i == s.Length && stack.Count == 0;
    }
}
