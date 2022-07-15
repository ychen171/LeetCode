public class Solution
{
    // Backtracking
    // use string to represent unique combo
    // Time: O(N * N!)
    // Space: O(N * N!)
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        // output order matters
        // input has duplicates, permutation can have duplicates
        // num cannot be reused
        // permutation is unique
        var usedIndexes = new HashSet<int>();
        var combo = new List<int>();
        var resultDict = new Dictionary<string, IList<int>>();
        Backtrack(nums, usedIndexes, "", combo, resultDict);
        return resultDict.Values.ToList();
    }

    private void Backtrack(int[] nums, HashSet<int> usedIndexes, string permString, IList<int> perm, Dictionary<string, IList<int>> resultDict)
    {
        // base case
        if (perm.Count == nums.Length)
        {
            if (!resultDict.ContainsKey(permString)) // not a duplicate combo
                resultDict[permString] = new List<int>(perm);
            return;
        }
        // recursive case
        for (int i = 0; i < nums.Length; i++)
        {
            if (usedIndexes.Contains(i))
                continue;
            perm.Add(nums[i]);
            usedIndexes.Add(i);
            Backtrack(nums, usedIndexes, permString + nums[i], perm, resultDict);
            perm.RemoveAt(perm.Count - 1);
            usedIndexes.Remove(i);
        }
    }


    // Time: O(N * N!)
    // Space: O(N * N!)
    public IList<IList<int>> PermuteUnique1(int[] nums)
    {
        // output order matters
        // input has duplicates, permutation can have duplicates
        // num cannot be reused
        // permutation is unique
        int n = nums.Length;
        var numCountDict = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            numCountDict[num] = numCountDict.GetValueOrDefault(num, 0) + 1;
        }

        var combo = new List<int>();
        var result = new List<IList<int>>();
        Backtrack(n, numCountDict, combo, result);
        return result;
    }

    private void Backtrack(int n, Dictionary<int, int> numCountDict, IList<int> perm, IList<IList<int>> result)
    {
        // base case
        if (perm.Count == n)
        {
            result.Add(new List<int>(perm));
            return;
        }

        // recursive case
        // we skip the duplicate nums on the current level
        // only take one in the same duplicate nums
        foreach (int num in numCountDict.Keys)
        {
            if (numCountDict[num] == 0)
                continue;
            perm.Add(num);
            numCountDict[num]--;
            PrintList(perm);
            Backtrack(n, numCountDict, perm, result);
            numCountDict[num]++;
            perm.RemoveAt(perm.Count - 1);
        }
    }
    
    public IList<IList<int>> PermuteUnique2(int[] nums)
    {
        // output order matters
        // input has duplicates, permutation can have duplicates
        // num cannot be reused
        // permutation is unique
        Array.Sort(nums);
        int n = nums.Length;
        var used = new bool[n];
        var perm = new List<int>();
        var result = new List<IList<int>>();
        Backtrack(nums, used, perm, result);
        return result;
    }

    private void Backtrack(int[] nums, bool[] used, IList<int> perm, IList<IList<int>> result)
    {
        // base case
        int n = nums.Length;
        if (perm.Count == n)
        {
            result.Add(new List<int>(perm));
            return;
        }

        // recursive case
        for (int i = 0; i < n; i++)
        {
            if (used[i])
                continue;
            // maintains the relative positions of every group of dups
            // skip the num if the prev dup num has not been used
            if (i != 0 && nums[i] == nums[i - 1] && !used[i - 1])
                continue;

            used[i] = true;
            perm.Add(nums[i]);
            PrintList(perm);
            Backtrack(nums, used, perm, result);
            perm.RemoveAt(perm.Count - 1);
            used[i] = false;
            // PrintList(perm);
        }
    }

    private void PrintList(IList<int> perm)
    {
        var sb = new StringBuilder();
        sb.Append("[");
        for (int i = 0; i < perm.Count; i++)
        {
            sb.Append(perm[i] + ", ");
        }
        if (sb.Length >= 2) sb.Remove(sb.Length - 2, 2);
        sb.Append("]");
        Console.WriteLine(sb.ToString());
    }
}

var s = new Solution();
var nums = new int[] { 1,1,2 };
Console.WriteLine("PermuteUnique1");
s.PermuteUnique1(nums);
Console.WriteLine("PermuteUnique2");
s.PermuteUnique2(nums);