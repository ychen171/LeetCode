public class Solution
{
    // Greedy
    // Time: O(n)
    // Space: O(1)
    public bool WinnerOfGame(string colors)
    {
        int n = colors.Length;
        if (n < 3)
            return false;
        int moveA = 0, moveB = 0;
        int countA = 0, countB = 0;
        for (int i = 0; i < n; i++)
        {
            char curr = colors[i];
            if (curr == 'A')
                countA++;
            else
                countB++;
            // last char
            if (i == n - 1)
            {
                if (curr == 'A')
                    moveA += Math.Max(0, countA - 2);
                else
                    moveB += Math.Max(0, countB - 2);
                break;
            }
            
            char next = colors[i + 1];
            if (curr != next) // start new
            {
                if (curr == 'A') // 'A' -> 'B'
                {
                    moveA += Math.Max(0, countA - 2);
                    countA = 0;
                }
                else // 'B' -> 'A'
                {
                    moveB += Math.Max(0, countB - 2);
                    countB = 0;
                }
            }
        }

        return moveA > moveB;
    }
}

var colors = "AAAABBBB";
var sln = new Solution();
var result = sln.WinnerOfGame(colors);
Console.WriteLine(result);

