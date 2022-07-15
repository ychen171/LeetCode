public class Solution
{
    // Backtracking
    // Time: O(2^N)
    // N = the number of candidates
    // Space: O(N)
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        // order doesn't matter
        // input has duplicates, output can have duplicates
        // num cannot be reused
        // combination is unique
        Array.Sort(candidates);
        var combo = new List<int>();
        var result = new List<IList<int>>();
        Backtrack(candidates, target, combo, 0, result);
        return result;
    }

    private void Backtrack(int[] candidates, int target, IList<int> combo, int nextStart, IList<IList<int>> result)
    {
        // base case
        if (target == 0)
        {
            result.Add(new List<int>(combo));
            return;
        }
        if (target < 0)
        {
            return;
        }

        // recursive case
        for (int i = nextStart; i < candidates.Length; i++)
        {
            // if (i > 0 && candidates[i - 1] == candidates[i])
            //     continue;
            if (i > nextStart && candidates[i - 1] == candidates[i])
                continue;
            var num = candidates[i];
            combo.Add(num);
            Backtrack(candidates, target - num, combo, i + 1, result);
            combo.RemoveAt(combo.Count - 1);
        }
    }
}
