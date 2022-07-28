public class Solution
{
    // Mono stack + HashSet + Dictionary
    // Time: O(n)
    // Space: O(n)
    public string RemoveDuplicateLetters(string s)
    {
        /*
            bcabc
              abc

            cbacdcbc
              acd
              acdc
              a  c
              a  cb
              a   bc
        */

        int n = s.Length;
        if (n <= 1)
            return s;

        var count = new Dictionary<char, int>();
        foreach (var c in s)
            count[c] = count.GetValueOrDefault(c, 0) + 1;

        var stack = new Stack<char>();
        var seen = new HashSet<char>();
        foreach (var c in s)
        {
            count[c]--;
            if (seen.Contains(c))
                continue;

            while (stack.Count != 0 && stack.Peek() > c)
            {
                if (count[stack.Peek()] == 0)
                    break;
                var d = stack.Pop();
                seen.Remove(d);
            }

            stack.Push(c);
            seen.Add(c);
        }

        var sb = new StringBuilder();
        while (stack.Count != 0)
            sb.Append(stack.Pop());

        return new string(sb.ToString().Reverse().ToArray());
    }
}
