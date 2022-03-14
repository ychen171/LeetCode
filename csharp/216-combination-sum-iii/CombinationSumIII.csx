public class Solution
{
    // Backtracking | Recursion
    // Time: O(9! * K / (9-K)!)
    // Space: O(K)
    public IList<IList<int>> CombinationSum3(int k, int n)
    {
        IList<IList<int>> result = new List<IList<int>>();
        var combo = new List<int>();
        Backtrack(k, n, combo, 1, result);
        return result;
    }

    private void Backtrack(int k, int remainder, List<int> combo, int nextStart, IList<IList<int>> result)
    {
        if (remainder == 0 && combo.Count == k)
        {
            // It's import to make a deep copy
            // Otherwise the combination would be reverted in other branch of backtracking
            result.Add(new List<int>(combo));
            return;
        }
        else if (remainder < 0 || combo.Count == k)
        {
            return;
        }

        for (int i = nextStart; i <= 9; i++)
        {
            combo.Add(i);
            Backtrack(k, remainder - i, combo, i + 1, result);
            // remove last element to explore other possible combo
            // go back one step so that it can go to other branch
            combo.RemoveAt(combo.Count - 1);
        }
    }
}
