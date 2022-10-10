public class Solution
{
    // Stack
    // Time: O(n)
    // Space: O(n)
    public string RobotWithString(string s)
    {
        /*
            p           s               t
                        bdda            
                                        bdda
            a                           bdd
        */
        var charCount = new int[26];
        int n = s.Length;
        foreach (var c in s)
        {
            charCount[c - 'a']++;
        }
        var stack = new Stack<char>();
        var sb = new StringBuilder();
        foreach (var c in s)
        {
            stack.Push(c);
            charCount[c - 'a']--;
            // pop out of stack as long as it is not empty 
            // and the top of stack is lexicographically smaller 
            // than smallest remaining character
            while (stack.Count != 0 && stack.Peek() <= GetMinChar(charCount))
            {
                sb.Append(stack.Pop());
            }

        }
        // add remaining to sb
        while (stack.Count != 0)
        {
            sb.Append(stack.Pop());
        }

        return sb.ToString();
    }

    private char GetMinChar(int[] charCount)
    {
        for (int i = 0; i < 26; i++)
        {
            if (charCount[i] > 0)
                return (char)('a' + i);
        }
        return 'a';
    }
}
