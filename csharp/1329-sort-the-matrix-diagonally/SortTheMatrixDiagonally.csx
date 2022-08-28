public class Solution
{
    // Sorting + List
    // Time: O(m * n + (m + n) * min(m, n) * log (min(m, n))) => O((m + n) * min(m, n) * log (min(m, n)))
    // Space: O(m * n)
    public int[][] DiagonalSort(int[][] mat)
    {
        // find each matrix diagonal
        // sort it
        // update matrix
        int m = mat.Length;
        int n = mat[0].Length;
        // k = c - r, [-(m-1), n-1]
        // len = m + n - 1
        // index = k + m - 1
        int len = m + n - 1;
        var diagList = new List<List<int>>();
        for (int i = 0; i < len; i++)
            diagList.Add(new List<int>());

        for (int r = 0; r < m; r++)
        {
            for (int c = 0; c < n; c++)
            {
                int k = c - r;
                int i = k + m - 1;
                diagList[i].Add(mat[r][c]);
            }
        }

        foreach (var diag in diagList)
        {
            diag.Sort();
        }

        for (int r = 0; r < m; r++)
        {
            for (int c = 0; c < n; c++)
            {
                int k = c - r;
                int i = k + m - 1;
                int j = k < 0 ? c : r;
                mat[r][c] = diagList[i][j];
            }
        }

        return mat;
    }

    // Sorting + Dictionary of Priority Queue
    // Time: O(m * n * log (min(m, n)))
    // Space: O(m * n)
    public int[][] DiagonalSort1(int[][] mat)
    {
        // find each matrix diagonal
        // sort it
        // update matrix
        int m = mat.Length;
        int n = mat[0].Length;
        var diagDict = new Dictionary<int, PriorityQueue<int, int>>();
        for (int r = 0; r < m; r++)
        {
            for (int c = 0; c < n; c++)
            {
                int key = r - c;
                if (!diagDict.ContainsKey(key))
                    diagDict[key] = new PriorityQueue<int, int>();
                diagDict[key].Enqueue(mat[r][c], mat[r][c]);
            }
        }

        for (int r = 0; r < m; r++)
        {
            for (int c = 0; c < n; c++)
            {
                int key = r - c;
                mat[r][c] = diagDict[key].Dequeue();
            }
        }

        return mat;
    }
}
