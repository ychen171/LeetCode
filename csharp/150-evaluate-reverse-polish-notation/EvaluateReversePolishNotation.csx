public class Solution
{
    // Stack 
    // Time: O(n)
    // Space: O(n)
    public int EvalRPN(string[] tokens)
    {
        var stack = new Stack<int>();
        int n = tokens.Length;
        
        for (int i = 0; i < n; i++)
        {
            var token = tokens[i];
            bool isInt = int.TryParse(token, out var num);
            if (isInt)
            {
                stack.Push(num);
            }
            else
            {
                var y = stack.Pop();
                var x = stack.Pop();
                if (token == "+")
                    stack.Push(x + y);
                else if (token == "-")
                    stack.Push(x - y);
                else if (token == "*")
                    stack.Push(x * y);
                else
                    stack.Push(x / y);
            }
        }

        return stack.Pop();
    }
}
