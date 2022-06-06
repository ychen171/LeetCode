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
}


var s = new Solution();
var result = s.Calculate("(3-(2-(5-(9-(4)))))");
Console.WriteLine(result);
