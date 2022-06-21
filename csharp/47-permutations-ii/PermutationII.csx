public class Solution
{
    // Backtracking
    // use string to represent unique combo
    // Time: O(N * N!)
    // Space: O(N * N!)
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        // the order matters
        // num cannot be reused, but there are duplicates
        var usedIndexes = new HashSet<int>();
        var combo = new List<int>();
        var resultDict = new Dictionary<string, IList<int>>();
        Backtrack(nums, usedIndexes, "", combo, resultDict);     
        return resultDict.Values.ToList();
    }

    private void Backtrack(int[] nums, HashSet<int> usedIndexes, string comboString, IList<int> combo, Dictionary<string, IList<int>> resultDict)
    {
        // base case
        if (combo.Count == nums.Length)
        {
            if (!resultDict.ContainsKey(comboString)) // not a duplicate combo
                resultDict[comboString] = new List<int>(combo);
            return;
        }
        // recursive case
        for (int i = 0; i < nums.Length; i++)
        {
            if (usedIndexes.Contains(i))
                continue;
            combo.Add(nums[i]);
            usedIndexes.Add(i);
            Backtrack(nums, usedIndexes, comboString + nums[i], combo, resultDict);
            combo.RemoveAt(combo.Count - 1);
            usedIndexes.Remove(i);
        }
    }

    
    // Time: O(N * N!)
    // Space: O(N * N!)
    public IList<IList<int>> PermuteUnique1(int[] nums)
    {
        // the order matters
        // num cannot be reused, but there are duplicates

        // create unique num and count dict
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

    private void Backtrack(int n, Dictionary<int, int> numCountDict, IList<int> combo, IList<IList<int>> result)
    {
        // base case
        if (combo.Count == n)
        {
            result.Add(new List<int>(combo));
            return;
        }

        // recursive case
        // we skip the duplicate nums on the current level
        // only take one in the same duplicate nums
        foreach (int num in numCountDict.Keys)
        {
            if (numCountDict[num] == 0)
                continue;
            combo.Add(num);
            numCountDict[num]--;
            Backtrack(n, numCountDict, combo, result);
            numCountDict[num]++;
            combo.RemoveAt(combo.Count - 1);
        }
    }
}


