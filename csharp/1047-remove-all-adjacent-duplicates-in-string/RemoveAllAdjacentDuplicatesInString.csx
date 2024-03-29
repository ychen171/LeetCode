public class Solution
{
    // Two Pointers
    // Time: O(n)
    // Space: O(n)
    public string RemoveDuplicates(string s)
    {
        if (s.Length <= 1) return s;
        int left = 0;
        int right = 1;
        List<char> charList = s.ToList();
        
        while (right < charList.Count)
        {
            if (charList[left] == charList[right])
            {
                charList.RemoveRange(left, 2);
                left = left == 0 ? left : left - 1;
                right = left + 1;
            }
            else
            {
                left++;
                right++;
            }
        }

        return new string(charList.ToArray());
    }

    // Stack | StringBuilder
    // Time: O(n)
    // Space: O(n - d)
    public string RemoveDuplicates1(string s)
    {
        var sb = new StringBuilder();
        for (int i=0; i<s.Length; i++)
        {
            if (sb.Length == 0 || sb[sb.Length - 1] != s[i])
            {
                sb.Append(s[i]);
            }
            else
            {
                sb.Remove(sb.Length - 1, 1);
            }
        }

        return sb.ToString();
    }

    // Stack + StringBuilder
    // Time: O(n)
    // Space: O(n - d)
    public string RemoveDuplicates2(string s) 
    {
        var stack = new Stack<char>();
        int n = s.Length;
        for (int i = n - 1; i >= 0; i--)
        {
            var c = s[i];
            if (stack.Count != 0 && stack.Peek() == c)
                stack.Pop();
            else
                stack.Push(c);
        }
        var sb = new StringBuilder();
        while (stack.Count != 0)
            sb.Append(stack.Pop());
        return sb.ToString();
    }
}
