public class Solution
{
    // BFS
    // Time: O(m * n)
    // Space: O(m * n)
    public int ShortestPath(int[][] grid, int k)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        var directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };

        var queue = new Queue<int[]>();
        var visited = new bool[m, n, k + 1];
        var ans = new int[m, n, k + 1];

        var curr = new int[] { 0, 0, k };
        queue.Enqueue(curr);
        visited[0, 0, k] = true;
        ans[0, 0, k] = 0;

        while (queue.Count != 0)
        {
            curr = queue.Dequeue();
            int row = curr[0];
            int col = curr[1];
            int remaining = curr[2];
            int step = ans[row, col, remaining];
            if (row == m - 1 && col == n - 1)
                return step;
            foreach (var dir in directions)
            {
                int r = row + dir[0];
                int c = col + dir[1];
                if (r < 0 || r >= m || c < 0 || c >= n) // invalid
                    continue;
                int rem = remaining - grid[r][c];
                if (rem < 0) // invalid
                    continue;
                if (visited[r, c, rem]) // visited
                    continue;
                curr = new int[] { r, c, rem };
                queue.Enqueue(curr);
                visited[r, c, rem] = true;
                ans[r, c, rem] = step + 1;
            }
        }

        return -1;
    }
}

// public class StepState : Object
// {
//     public int steps;
//     public int row;
//     public int col;
//     public int k;

//     public StepState(int steps, int row, int col, int k)
//     {
//         this.steps = steps;
//         this.row = row;
//         this.col = col;
//         this.k = k;
//     }

//     public override bool Equals(object obj)
//     {
//         StepState stepState = obj as StepState;
//         if (stepState == null)
//             return false;
//         return (stepState.row == this.row) && (stepState.col == this.row) && (stepState.k == this.k);
//     }

//     public override int GetHashCode()
//     {
//         // int result = 0;
//         // result += this.row * 40;
//         // result += this.col * 40;
//         // result += this.k * 40 * 40;
//         // return result;
//         return (this.row + 1) * (this.col + 1) * this.k;
//     }
// }
