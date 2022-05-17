public class Solution
{
    // Stack
    // Time: O(n)
    // Space: O(n)
    public int Calculate(string s)
    {
        // 3 + 2 * 2
        // 3
        // 3 2
        // 3        2*2 = 4
        // 3 4
        // 3 + 4 = 7
        s = s.Replace(" ", "");
        int n = s.Length;
        var stack = new Stack<int>();
        int currInt = 0;
        int sign = 1;
        int i = 0;
        while (i < n)
        {
            char currChar = s[i];
            if (char.IsDigit(currChar))
            {
                currInt = currInt * 10 + int.Parse(currChar.ToString());
                i++;
            }
            else
            {
                currInt = sign * currInt;
                stack.Push(currInt);
                currInt = 0;
                if (currChar == '+')
                {
                    sign = 1;
                    i++;
                }
                else if (currChar == '-')
                {
                    sign = -1;
                    i++;
                }
                else if (currChar == '*')
                {
                    sign = 1;
                    i++;
                    while (i < n && char.IsDigit(s[i]))
                    {
                        currInt = currInt * 10 + int.Parse(s[i].ToString());
                        i++;
                    }
                    currInt = stack.Pop() * currInt;
                }
                else if (currChar == '/')
                {
                    sign = 1;
                    i++;
                    while (i < n && char.IsDigit(s[i]))
                    {
                        currInt = currInt * 10 + int.Parse(s[i].ToString());
                        i++;
                    }
                    currInt = stack.Pop() / currInt;
                }
            }
        }
        if (currInt != 0)
        {
            currInt = sign * currInt;
            stack.Push(currInt);
        }

        int ans = 0;
        while (stack.Count != 0)
        {
            ans += stack.Pop();
        }

        return ans;
    }
}

var s = new Solution();
var result = s.Calculate("2*3*4");
Console.WriteLine(result);