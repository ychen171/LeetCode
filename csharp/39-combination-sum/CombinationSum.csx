public class Solution
{
    // Backtracking | Recursion
    // Time: O(N^(T/M+1))
    // N = the number of candidates, T = the target value, M = the minimal value among candidates
    // Space: O(T/M)
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        Array.Sort(candidates);
        IList<IList<int>> result = new List<IList<int>>();
        var combo = new List<int>();
        Backtrack(candidates, target, combo, 0, result);

        return result;
    }

    private void Backtrack(int[] candidates, int remainder, List<int> combo, int nextStart, IList<IList<int>> result)
    {
        if (remainder == 0)
        {
            result.Add(new List<int>(combo));
            return;
        }
        else if (remainder < 0)
        {
            return;
        }

        for (int i = nextStart; i < candidates.Length; i++)
        {
            combo.Add(candidates[i]);
            Backtrack(candidates, remainder - candidates[i], combo, i, result);
            combo.RemoveAt(combo.Count - 1);
        }
    }

    // DP | Bottom-up | Tabulation | Iteration
    // Time: O()
    // Space: O()
    public IList<IList<int>> CombinationSumTabulation(int[] candidates, int target)
    {
        // Initialize the table with default value
        List<IList<IList<int>>> table = new List<IList<IList<int>>>();
        for (int i = 0; i <= target; i++)
        {
            table.Add(new List<IList<int>>());
        }
        // Seed the trivial answer into the table
        table[0].Add(new List<int>());
        // Fill further positions with default position
        Array.Sort(candidates);
        foreach (var candidate in candidates)
        {
            for (int j = candidate; j <= target; j++)
            {
                foreach (var combo in table[j-candidate])
                {
                    var newCombo = new List<int>(combo);
                    newCombo.Add(candidate);
                    table[j].Add(newCombo);
                }
            }
        }

        return table[target];
    }
}


var s = new Solution();
var result = s.CombinationSum(new int[] { 3, 4, 5 }, 8);
Console.WriteLine(result);