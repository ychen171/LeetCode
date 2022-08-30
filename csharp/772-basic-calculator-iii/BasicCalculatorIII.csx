public class Solution
{
    // stack + queue + recursion
    // Time: O(n)
    // Space: O(n)
    public int Calculate(string s)
    {
        // convert string to char queue
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
            if (c == '(')
                num = Cal(q);

            // calculate and push into stack
            // only when c in [+, -, *, /, )] or c is the last char
            if (!char.IsDigit(c) || q.Count == 0)
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
                sign = c;
            }
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
