public class Solution
{
    // Iterative
    // Time: O(n^2)
    // Space: O(n^2)
    public IList<int> GetRow(int rowIndex)
    {
        var prevRow = new List<int>();
        var currRow = new List<int>();
        prevRow.Add(1);
        if (rowIndex == 0) return prevRow;
        currRow.Add(1);
        for (int i = 1; i <= rowIndex; i++)
        {
            currRow[0] = 1;
            for (int j = 1; j < i; j++)
            {
                currRow[j] = prevRow[j - 1] + prevRow[j];
            }
            currRow.Add(1);
            prevRow = currRow;
            currRow = new List<int>(currRow);
        }
        return currRow;
    }

    // Brute force recursion | Time Limit Exceeded
    // Time: O(2^k)
    // Space: O(k)
    public IList<int> GetRow1(int rowIndex)
    {
        var row = new List<int>();
        for (int i = 0; i <= rowIndex; i++)
            row.Add(GetNum1(rowIndex, i));
        return row;
    }
    private int GetNum1(int row, int col)
    {
        if (row == 0 || col == 0 || row == col) return 1;
        return GetNum1(row - 1, col - 1) + GetNum1(row - 1, col);
    }

    // Recursion | Memoization
    // Time: O(k^2)
    // Space: O(k^2)
    public IList<int> GetRow2(int rowIndex)
    {
        var row = new List<int>();
        var memo = new Dictionary<string, int>();
        for (int i = 0; i <= rowIndex; i++)
        {
            row.Add(GetNum2(rowIndex, i, memo));
        }
        return row;
    }
    private int GetNum2(int row, int col, Dictionary<string, int> memo)
    {
        var key = row.ToString() + col.ToString();
        if (memo.ContainsKey(key)) return memo[key];
        if (row == 0 || col == 0 || row == col)
        {
            memo[key] = 1;
            return 1;
        }
        var result = GetNum2(row - 1, col - 1, memo) + GetNum2(row - 1, col, memo);
        memo[key] = result;
        return result;
    }

    // Math! (specifically Combinatorics)
    // Time: O(k)
    // Space: O(k)
    public IList<int> GetRow3(int rowIndex)
    {
        var row = new List<int>(){1};
        for (int i = 1; i <= rowIndex; i++)
            row.Add((int) (row[row.Count-1] * (long) (rowIndex - i + 1) / i));
        
        return row;
    }
}

var s = new Solution();
var result = s.GetRow(3);
Console.WriteLine(result);


