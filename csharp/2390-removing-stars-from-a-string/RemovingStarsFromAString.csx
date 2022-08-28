public class Solution
{
    // Stack
    // Time: O(n)
    // Space: O(n)
    public string RemoveStars(string s)
    {
        int n = s.Length;
        var stack = new Stack<char>();
        for (int i = 0; i < n; i++)
        {
            var c = s[i];
            if (c == '*')
            {
                if (stack.Count == 0)
                    continue;
                stack.Pop();
            }
            else
            {
                stack.Push(c);
            }
        }

        var list = new List<char>();
        while (stack.Count != 0)
        {
            list.Add(stack.Pop());
        }

        return new string(list.ToArray().Reverse().ToArray());
    }
}
