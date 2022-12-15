public class Solution
{
    int ans;
    public int AssignBikes(int[][] workers, int[][] bikes)
    {
        /*
            permutation, order matters
            input (bikes) has no dups, output (bikes) has no dups
            bikes cannot be reused
            unique result

            find permutations of N bikes from M total bikes
        */
        int n = workers.Length;
        int m = bikes.Length;
        var used = new bool[m];
        ans = int.MaxValue;
        Backtrack(workers, bikes, used, 0, 0);
        return ans;
    }

    private void Backtrack(int[][] workers, int[][] bikes, bool[] used, int sum, int workerIndex)
    {
        // base case
        int n = workers.Length;
        int m = bikes.Length;
        if (workerIndex == n)
        {
            ans = Math.Min(ans, sum);
            return;
        }
        if (sum >= ans)
            return;

        // recursive case
        int[] worker = workers[workerIndex];
        for (int i = 0; i < m; i++)
        {
            if (used[i])
                continue;
            int[] bike = bikes[i];
            int distance = Math.Abs(worker[0] - bike[0]) + Math.Abs(worker[1] - bike[1]);
            used[i] = true;
            sum += distance;
            Backtrack(workers, bikes, used, sum, workerIndex + 1);
            sum -= distance;
            used[i] = false;
        }
    }
}
// Backtracking
// Time: O(m! / (m - n)!)
// Space: O(m + n)
