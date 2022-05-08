public class Solution
{
    // Stack
    // Time: O(n)
    // Space: O(n)
    public int MinimumDeletions(string s)
    {
        int n = s.Length;
        if (n == 1)
            return 0;

        // "aababbab"
        //        ab
        //         b       -1
        //     ab  b 
        //      b  b       -1
        //   a  b  b
        //  aa  b  b

        // "bbaaaaabb"
        // [2,3,4,5,6] 2         [0,1,7,8] 5

        // [2,3,4,5,6]           [7,8]

        // mono stack, from right to left, decreasing
        var stack = new Stack<char>();
        int ans = 0;

        for (int i = n - 1; i >= 0; i--)
        {
            var c = s[i];
            if (stack.Count != 0 && c > stack.Peek())
            {
                stack.Pop();
                ans++;
            }
            else
            {
                stack.Push(c);
            }
        }

        return ans;
    }

    // DP | Tabulation 
    // Time: O(n)
    // Space: O(n)
    public int MinimumDeletions1(string s)
    {
        int n = s.Length;
        // table stores the number of chars to remove to make s.Substring(0, i) valid
        int[] table = new int[n+1];
        int bCount = 0;
        for (int i = 0; i < n; i++)
        {
            if (s[i] == 'a')
            {
                // case 1: keep current 'a' and remove all 'b's
                // case 2: remove current 'a' and whatever makes previous substring valid, which is table[i]
                table[i + 1] = Math.Min(table[i] + 1, bCount);
            }
            else
            {
                // since it is always valid to append 'b', just update using the previous value
                table[i + 1] = table[i];
                bCount++;
            }
        }

        return table[n];
    }
}

