public class TicTacToe
{
    // Dictionary
    // Space: O(n)
    Dictionary<int, Dictionary<int, int>> rowMoveDict;
    Dictionary<int, Dictionary<int, int>> colMoveDict;
    Dictionary<int, Dictionary<int, int>> diagMoveDict;
    int n;
    public TicTacToe(int n)
    {
        rowMoveDict = new Dictionary<int, Dictionary<int, int>>();
        colMoveDict = new Dictionary<int, Dictionary<int, int>>();
        diagMoveDict = new Dictionary<int, Dictionary<int, int>>();
        this.n = n;
        for (int i = 0; i < n; i++)
        {
            rowMoveDict[i] = new Dictionary<int, int>();
            colMoveDict[i] = new Dictionary<int, int>();
        }
        diagMoveDict[0] = new Dictionary<int, int>();
        diagMoveDict[1] = new Dictionary<int, int>();
    }

    // Time: O(1)
    public int Move(int row, int col, int player)
    {
        // update dicts
        rowMoveDict[row][player] = rowMoveDict[row].GetValueOrDefault(player, 0) + 1;

        colMoveDict[col][player] = colMoveDict[col].GetValueOrDefault(player, 0) + 1;

        if (row == col)
        {
            diagMoveDict[0][player] = diagMoveDict[0].GetValueOrDefault(player, 0) + 1;
        }
        if (row + col == n - 1)
        {
            diagMoveDict[1][player] = diagMoveDict[1].GetValueOrDefault(player, 0) + 1;
        }

        // check dicts
        if (rowMoveDict[row].GetValueOrDefault(player, 0) == n)
            return player;
        if (colMoveDict[col].GetValueOrDefault(player, 0) == n)
            return player;
        if (diagMoveDict[0].GetValueOrDefault(player, 0) == n)
            return player;
        if (diagMoveDict[1].GetValueOrDefault(player, 0) == n)
            return player;
        
        return 0;
    }
}

/**
 * Your TicTacToe object will be instantiated and called as such:
 * TicTacToe obj = new TicTacToe(n);
 * int param_1 = obj.Move(row,col,player);
 */
