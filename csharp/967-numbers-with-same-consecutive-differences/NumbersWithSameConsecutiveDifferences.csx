public class Solution
{
    // Time: O(2^n) in worst (k = 1), O(n) in best (k = 0)
    // Space: O(2^n)
    public int[] NumsSameConsecDiff(int n, int k)
    {
        /*
            order matters / permutations
            input has no dups; output can have dups
            nums can be reused
            outputs are unique
        */
        var combo = new List<int>();
        var result = new List<List<int>>();
        Backtrack(n, k, combo, result);
        var nums = new int[result.Count];
        for (int i = 0; i < result.Count; i++)
        {
            int num = 0;
            foreach (var digit in result[i])
            {
                num = num * 10 + digit;
            }
            nums[i] = num;
        }

        return nums;
    }

    public void Backtrack(int n, int k, List<int> combo, List<List<int>> result)
    {
        // base case
        if (combo.Count == n)
        {
            result.Add(new List<int>(combo));
            return;
        }

        // recursive case
        if (combo.Count == 0)
        {
            for (int i = 1; i <= 9; i++)
            {
                combo.Add(i);
                Backtrack(n, k, combo, result);
                combo.RemoveAt(combo.Count - 1);
            }
        }
        else
        {
            for (int i = 0; i <= 9; i++)
            {
                if (Math.Abs(combo.Last() - i) != k)
                    continue;
                combo.Add(i);
                Backtrack(n, k, combo, result);
                combo.RemoveAt(combo.Count - 1);
            }
        }
    }
}
