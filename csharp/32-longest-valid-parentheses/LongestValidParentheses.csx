public class Solution
{
    // DP | Tabulation
    // Time: O(n)
    // Space: O(n)
    public int LongestValidParentheses(string s)
    {
        int ans = 0;
        int n = s.Length;
        var table = new int[n];
        for (int i = 1; i < n; i++)
        {
            if (s[i] == ')')
            {
                if (s[i - 1] == '(')
                {
                    table[i] = (i >= 2 ? table[i - 2] : 0) + 2;
                }
                else if (i - table[i - 1] > 0 && s[i - table[i - 1] - 1] == '(')
                {
                    table[i] = table[i - 1] + ((i - table[i - 1]) >= 2 ? table[i - table[i - 1] - 2] : 0) + 2;
                }

                ans = Math.Max(ans, table[i]);
            }
        }

        return ans;
    }

    // Stack
    // Time: O(n)
    // Space: O(n)
    public int LongestValidParentheses1(string s)
    {
        // )()())
        // -1      <- 0 )
        // 0       <- 1 (
        // 0 1     <- 2 )
        // 0                    len = 2 - 0 = 2   max = 2
        // 0       <- 3 (
        // 0 3     <- 4 )
        // 0                    len = 4 - 0 = 4   max = 4
        // 0       <- 5 )
        // 5
        int n = s.Length;
        int ans = 0;
        var stack = new Stack<int>();
        stack.Push(-1);
        for (int i = 0; i < n; i++)
        {
            var c = s[i];
            if (c == '(')
            {
                stack.Push(i);
            }
            else // ')'
            {
                int index = stack.Pop();
                // the top of the stack is the left boundary
                if (stack.Count == 0) // index == -1
                {
                    stack.Push(i);
                }
                else // index >= 0
                {
                    ans = Math.Max(ans, i - stack.Peek());
                }
            }
        }

        return ans;
    }

    // Two Pointers + Two Scans
    // Time: O(n)
    // Space: O(1)
    public int LongestValidParentheses2(string s)
    {
        int n = s.Length;
        int ans = 0;
        int left = 0;
        int right = 0;
        // scan from left to right
        for (int i = 0; i < n; i++)
        {
            var c = s[i];
            if (c == '(')
                left++;
            else
                right++;
            if (left == right)
            {
                ans = Math.Max(ans, 2 * left);
            }
            else if (right > left)
            {
                left = 0;
                right = 0;
            }
        }

        // scan from right to left
        left = 0;
        right = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            var c = s[i];
            if (c == ')')
                right++;
            else
                left++;
            if (left == right)
            {
                ans = Math.Max(ans, 2 * right);
            }
            else if (left > right)
            {
                left = 0;
                right = 0;
            }
        }

        return ans;
    }
}
