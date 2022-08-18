public class Solution
{
    // Stack
    // Time: O(n)
    // Space: O(n)
    public int Calculate(string s)
    {
        // (1+(4+5+2)-3)+(6+8)
        // (1
        // (1+(4+5+2)
        // (1+11
        // (1+11-3)
        // 9
        // 9+(6+8
        // 9+14
        s = s.Replace(" ", "");
        int n = s.Length;
        var stringStack = new Stack<string>();
        int currSum = 0;
        int sign = 1;
        int i = 0;
        for (int j = 0; j < n; j++)
        {
            if (s[j] == ')') // keep poping strings until it reaches "("
            {
                var onePairStack = new Stack<string>();
                while (stringStack.Peek() != "(")
                {
                    onePairStack.Push(stringStack.Pop());
                }
                stringStack.Pop(); // pop "("

                // calcuate sum within ( ) pair
                currSum = 0;
                sign = 1;
                while (onePairStack.Count != 0)
                {
                    string currString = onePairStack.Pop();
                    if (currString == "+")
                    {
                        sign = 1;
                    }
                    else if (currString == "-")
                    {
                        sign = -1;
                    }
                    else
                    {
                        currSum += sign * int.Parse(currString);
                    }
                }
                // push sum back to stack
                stringStack.Push(currSum.ToString());
                // reset i to the start of next num
                i = j + 1;
            }
            else if (s[j] == '(' || s[j] == '+' || s[j] == '-') // push to stack and reset i
            {
                stringStack.Push(s[j].ToString());
                i = j + 1;
            }
            else // num, find the entire num string and push to stack; reset i to the start of next num
            {
                if (j == n - 1 || !char.IsNumber(s[j + 1])) // s[j] is the last digit or s[j+1] is not a digit
                {
                    stringStack.Push(s.Substring(i, j - i + 1));
                    i = j + 1;
                }
            }
        }

        // reverse stack
        var reversedStack = new Stack<string>();
        while (stringStack.Count != 0)
            reversedStack.Push(stringStack.Pop());
        // sum up all num string, with +/- sign
        int ans = 0;
        sign = 1;
        while (reversedStack.Count != 0)
        {
            var currString = reversedStack.Pop();
            if (currString == "+")
            {
                sign = 1;
            }
            else if (currString == "-")
            {
                sign = -1;
            }
            else
            {
                ans += sign * int.Parse(currString);
            }
        }

        return ans;
    }

    public int Calculate1(string s)
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
            if (c == '(')
                num = Cal(q);

            // push the completed num into stack
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


var s = new Solution();
var result = s.Calculate("(3-(2-(5-(9-(4)))))");
Console.WriteLine(result);
var result1 = s.Calculate1("(3-(2-(5-(9-(4)))))");
Console.WriteLine(result1);
