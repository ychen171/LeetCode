public class Solution
{
    // Backtracking
    // Time: O()
    // Space: O()
    public IList<IList<int>> Permute(int[] nums)
    {
        var result = new List<IList<int>>();
        var remain = new HashSet<int>(nums);
        var perm = new List<int>();
        var n = nums.Length;
        Backtrack(n, remain, perm, result);
        return result;
    }

    private void Backtrack(int n, HashSet<int> remain, IList<int> perm, IList<IList<int>> result)
    {
        // base case
        if (perm.Count == n)
        {
            result.Add(new List<int>(perm));
            Console.WriteLine("add to result");
            return;
        }

        var remainList = new List<int>(remain);
        foreach (var candidate in remainList)
        {
            perm.Add(candidate);
            remain.Remove(candidate);
            PrintList(perm);
            Backtrack(n, remain, perm, result);
            perm.Remove(candidate);
            remain.Add(candidate);
            PrintList(perm);
        }
    }

    // Doesn't work!!!
    public IList<IList<int>> Permute1(int[] nums)
    {
        var candidates = new List<int>(nums);
        var perm = new List<int>();
        var result = new List<IList<int>>();
        Backtrack1(nums, candidates, perm, 0, result);
        return result;
    }

    // Doesn't work!!!
    private void Backtrack1(int[] nums, IList<int> candidates, IList<int> perm, int nextStart, IList<IList<int>> result)
    {
        if (perm.Count == nums.Length)
        {
            result.Add(new List<int>(perm));
            Console.WriteLine("add to result");
            return;
        }

        for (int i = nextStart; i < nums.Length; i++)
        {
            if (candidates.Contains(nums[i]))
            {
                perm.Add(nums[i]);
                candidates.Remove(nums[i]);
                PrintList(perm);
                Backtrack1(nums, candidates, perm, i + 1, result);
                perm.Remove(nums[i]);
                candidates.Add(nums[i]);
                PrintList(perm);
            }
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
var result = s.Permute(new int[] { 1, 2, 3 });
Console.WriteLine(result);

result = s.Permute1(new int[] {1,2,3});
Console.WriteLine(result);