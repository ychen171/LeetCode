public class Solution
{
    // Dictionary + HashSet
    // Time: O(n^2)
    // Space: O(n^2)
    public bool IsValidSudoku(char[][] board)
    {
        // m = board.Length
        // n = board[0].Length
        // rowDict, colDict, boxDict
        // Dictionary<int, HashSet<char>>

        // rowDict[0, ... , 8] = HashSet<char>
        // colDict[0, ... , 8]
        // boxDict[0, ... , 8]

        // HashSet<char> charSet = [1, ... , 9]

        int n = board.Length;
        var rowDict = new Dictionary<int, HashSet<char>>();
        var colDict = new Dictionary<int, HashSet<char>>();
        var boxDict = new Dictionary<int, HashSet<char>>();
        for (int i = 0; i < n; i++)
        {
            rowDict[i] = new HashSet<char>();
            colDict[i] = new HashSet<char>();
            boxDict[i] = new HashSet<char>();
        }

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                char digit = board[r][c];
                if (digit == '.')
                    continue;
                if (!rowDict[r].Add(digit))
                    return false;
                if (!colDict[c].Add(digit))
                    return false;
                // int boxKey = GetBoxKey(r, c);
                int boxKey = r / 3 * 3 + c / 3;
                if (!boxDict[boxKey].Add(digit))
                    return false;
            }
        }

        return true;
    }

    private int GetBoxKey(int r, int c)
    {
        if (r < 3)
        {
            if (c < 3)
                return 0;
            else if (c < 6)
                return 1;
            else
                return 2;
        }
        else if (r < 6)
        {
            if (c < 3)
                return 3;
            else if (c < 6)
                return 4;
            else
                return 5;
        }
        else
        {
            if (c < 3)
                return 6;
            else if (c < 6)
                return 7;
            else
                return 8;
        }
    }
}
