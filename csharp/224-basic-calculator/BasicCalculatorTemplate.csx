public class Solution
{
    // Stack
    // Time: O(n)
    // Space: O(n)
    public int Calculate(string s)
    {
        var q = new Queue<char>();
        foreach (var c in s)
        {
            if (c == ' ')
                continue;
            q.Enqueue(c);
        }
        return Cal(q);
    }

    private int Cal(Queue<char> q)
    {
        var stack = new Stack<int>();
        int num = 0;
        char sign = '+';
        while (q.Count != 0)
        {
            char c = q.Dequeue();
            // create num
            if (char.IsDigit(c))
                num = 10 * num + (c - '0');
            // start recursion
            if (c == '(')
                num = Cal(q);
            // push the completed num into stack
            // c = [+, -, *, /, )]
            if ((c != ' ' && !char.IsDigit(c)) || q.Count == 0)
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
                // reset num and sign
                num = 0;
                sign = c; // assign the next sign
            }
            // if the next sign is not a sign, which can only be ')', stop current recursive call
            if (c == ')')
                break;
        }
        // sum up 
        int ans = 0;
        while (stack.Count != 0)
            ans += stack.Pop();

        return ans;
    }
}
