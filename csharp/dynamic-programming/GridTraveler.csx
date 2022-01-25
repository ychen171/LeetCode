
using System.Collections.Generic;
// Brute force recursion
// Time: O(2^(m+n))
// Space: O(m+n)
public long GridTraveler(int m, int n)
{
    if (m == 1 && n == 1) return 1;
    if (m == 0 || n == 0) return 0;
    return GridTraveler(m - 1, n) + GridTraveler(m, n - 1);
}

Console.WriteLine(GridTraveler(1, 1)); // 1
Console.WriteLine(GridTraveler(2, 3)); // 3
Console.WriteLine(GridTraveler(3, 2)); // 3
Console.WriteLine(GridTraveler(3, 3)); // 6
// Console.WriteLine(GridTraveler(18, 18)); // 2333606220



// Memoized recursion
// Time: O(m*n)
// Space: O(m+n)
public long GridTraveler(int m, int n, Dictionary<string, long> memo)
{
    var key = $"{m},{n}";
    if (memo.ContainsKey(key)) return memo[key];
    if (m == 1 && n == 1) return 1;
    if (m == 0 || n == 0) return 0;
    var result = GridTraveler(m - 1, n, memo) + GridTraveler(m, n - 1, memo);
    memo[key] = result;
    return result;
}

Console.WriteLine(GridTraveler(1, 1, new Dictionary<string, long>())); // 1
Console.WriteLine(GridTraveler(2, 3, new Dictionary<string, long>())); // 3
Console.WriteLine(GridTraveler(3, 2, new Dictionary<string, long>())); // 3
Console.WriteLine(GridTraveler(3, 3, new Dictionary<string, long>())); // 6
Console.WriteLine(GridTraveler(18, 18, new Dictionary<string, long>())); // 2333606220



// Iteration | Bottom-up
// Time: O(m*n)
// Space: O(m*n)
public long GridTravelerBottomUp(int m, int n)
{
    var resultGrid = new List<List<long>>();
    int row = 0;
    int col = 0;
    // populate row-0 with value 0
    resultGrid.Add(new List<long>());
    for (col = 0; col <= n; col++)
        resultGrid[0].Add(0);
    // populate row-1 with value 1 except for col-0
    resultGrid.Add(new List<long>());
    resultGrid[1].Add(0);
    for (col = 1; col <= n; col++)
        resultGrid[1].Add(1);
    // for the rest of rows, set col-0 to value 0 and apply the logic to the rest of cols
    for (row = 2; row <= m; row++)
    {
        resultGrid.Add(new List<long>());
        resultGrid[row].Add(0);
        for (col = 1; col <= n; col++)
            resultGrid[row].Add(resultGrid[row - 1][col] + resultGrid[row][col - 1]);
    }

    return resultGrid[m][n];
}

Console.WriteLine(GridTravelerBottomUp(1, 1)); // 1
Console.WriteLine(GridTravelerBottomUp(2, 3)); // 3
Console.WriteLine(GridTravelerBottomUp(3, 2)); // 3
Console.WriteLine(GridTravelerBottomUp(3, 3)); // 6
Console.WriteLine(GridTravelerBottomUp(18, 18)); // 2333606220



// Iteration | Tabulation
// Time: O(m*n)
// Space: O(m*n)
public long GridTravelerTabulation(int m, int n)
{
    var table = new List<List<long>>();
    int row = 0;
    int col = 0;
    // initialize table with default value 0
    for (row = 0; row <= m; row++)
    {
        table.Add(new List<long>());
        for (col = 0; col <= n; col++)
            table[row].Add(0);
    }
    // seed the trivial answer into the table
    table[1][1] = 1;
    // fill further positions based on current position
    for (row = 1; row <= m; row++)
    {
        for (col = 1; col <= n; col++)
        {
            if (row < m) table[row + 1][col] += table[row][col];
            if (col < n) table[row][col + 1] += table[row][col];
        }
    }

    return table[m][n];
}

Console.WriteLine(GridTravelerTabulation(1, 1)); // 1
Console.WriteLine(GridTravelerTabulation(2, 3)); // 3
Console.WriteLine(GridTravelerTabulation(3, 2)); // 3
Console.WriteLine(GridTravelerTabulation(3, 3)); // 6
Console.WriteLine(GridTravelerTabulation(18, 18)); // 2333606220



