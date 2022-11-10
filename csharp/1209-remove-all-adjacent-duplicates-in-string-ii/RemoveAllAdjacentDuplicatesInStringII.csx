public class Solution
{
    // Stack
    // Time: O(n)
    // Space: O(n)
    public string RemoveDuplicates(string s, int k)
    {
        // stack of letter, count pair
        var stack = new Stack<KeyValuePair<char, int>>();
        foreach (char c in s)
        {
            if (stack.Count != 0 && stack.Peek().Key == c)
            {
                var topPair = stack.Pop();
                if (topPair.Value == k - 1)
                    continue;
                var newPair = new KeyValuePair<char, int>(c, topPair.Value + 1);
                stack.Push(newPair);
            }
            else
            {
                var newPair = new KeyValuePair<char, int>(c, 1);
                stack.Push(newPair);
            }
        }

        var sb = new StringBuilder();
        foreach (var pair in stack.Reverse())
        {
            var c = pair.Key;
            var count = pair.Value;
            for (int i = 0; i < count; i++)
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }

    public string RemoveDuplicates1(string s, int k) 
    {
        var stack = new Stack<KeyValuePair<char, int>>(); // key: char, value: count
        int n = s.Length;
        for (int i = n - 1; i >= 0; i--)
        {
            var c = s[i];
            if (stack.Count != 0)
            {
                if (stack.Peek().Key == c)
                {
                    if (stack.Peek().Value + 1 == k)
                    {
                        while (stack.Count != 0 && stack.Peek().Key == c)
                            stack.Pop();
                    }
                    else
                        stack.Push(new KeyValuePair<char, int>(c, stack.Peek().Value + 1));
                }
                else
                    stack.Push(new KeyValuePair<char, int>(c, 1));
            }
            else
                stack.Push(new KeyValuePair<char, int>(c, 1));
        }
        var sb = new StringBuilder();
        while (stack.Count != 0)
            sb.Append(stack.Pop().Key);
        return sb.ToString();
    }
}
