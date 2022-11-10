public class Solution
{
    // Stack
    // Time: O(n)
    // Space: O(n)
    public string RemoveStars(string s) 
    {
        var stack = new Stack<char>();
        foreach (var c in s)
        {
            if (stack.Count != 0 && c == '*')
                stack.Pop();
            else
                stack.Push(c);
        }
        var sb = new StringBuilder();
        foreach (var c in stack.Reverse())
            sb.Append(c);
        return sb.ToString();
    }
}
