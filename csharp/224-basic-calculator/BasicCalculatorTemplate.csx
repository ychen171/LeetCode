public class Solution
{
    // Stack
    // Time: O(n)
    // Space: O(n)
    public int Calculate(string s)
    {
        var stack = new Stack<int>();
        int num = 0;
        char sign = '+';
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            // construct integer
            if (char.IsDigit(c))
                num = 10 * num + (c - '0');

            // push the complete integer into stack
            // only when c in [+, -, *, /] or c is the last char
            if ((!char.IsDigit(c) && c != ' ') || i == s.Length - 1)
            {
                switch (sign)
                {
                    case '+':
                        stack.Push(num);
                        break;
                    case '-':
                        stack.Push(-num);
                        break;
                    case '*':
                        stack.Push(stack.Pop() * num);
                        break;
                    case '/':
                        stack.Push(stack.Pop() / num);
                        break;
                }

                // reset integer and sign
                num = 0;
                sign = c;
            }
        }

        // sum up
        int ans = 0;
        while (stack.Count != 0)
            ans += stack.Pop();

        return ans;
    }
}

var sln = new Solution();
var s = "+ 1 - 12 + 3";
Console.WriteLine(sln.Calculate(s));
