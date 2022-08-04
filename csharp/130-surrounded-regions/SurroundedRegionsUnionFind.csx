public class Solution
{
    // Time: O(m*n)
    // Space: O(m*n)
    int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
    public void Solve(char[][] board)
    {
        int m = board.Length;
        int n = board[0].Length;
        if (m == 0) return;
        // give dummy a place
        var uf = new UnionFind(m * n + 1);
        int dummy = m * n;
        // Union Find to connect four edges with dummy
        for (int row = 0; row < m; row++)
        {
            if (board[row][0] == 'O')
                uf.Union(row * n + 0, dummy);
            if (board[row][n - 1] == 'O')
                uf.Union(row * n + n - 1, dummy);
        }
        for (int col = 0; col < n; col++)
        {
            if (board[0][col] == 'O')
                uf.Union(col, dummy);
            if (board[m - 1][col] == 'O')
                uf.Union((m - 1) * n + col, dummy);
        }
        // connect 'O'
        for (int row = 1; row < m - 1; row++)
        {
            for (int col = 1; col < n - 1; col++)
            {
                if (board[row][col] == 'O')
                {
                    foreach (var dir in directions)
                    {
                        int r = row + dir[0];
                        int c = col + dir[1];
                        if (board[r][c] == 'O')
                            uf.Union(row * n + col, r * n + c);
                    }
                }
            }
        }
        // flip 'O' into 'X'
        for (int row = 1; row < m - 1; row++)
        {
            for (int col = 1; col < n - 1; col++)
            {
                if (!uf.Connected(dummy, row * n + col))
                    board[row][col] = 'X';
            }
        }
    }
}

public class UnionFind
{
    public int Count { get; private set; }
    int[] parents;
    public UnionFind(int n)
    {
        Count = n;
        parents = new int[n];
        for (int i = 0; i < n; i++)
            parents[i] = i;
    }

    public void Union(int p, int q)
    {
        int rootP = Find(p);
        int rootQ = Find(q);
        if (rootP == rootQ)
            return;

        parents[rootP] = rootQ;
        Count--;
    }

    public int Find(int p)
    {
        if (parents[p] != p)
            parents[p] = Find(parents[p]);

        return parents[p];
    }

    public bool Connected(int p, int q)
    {
        int rootP = Find(p);
        int rootQ = Find(q);

        return rootP == rootQ;
    }
}
