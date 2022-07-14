public class Solution
{
    // Backtracking
    // Time: O(N * N!)
    // Space: O(N * N!)
    public IList<IList<int>> Permute(int[] nums)
    {
        var n = nums.Length;
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
            int num = nums[i];
            if (used[i]) // skip the used num
                continue;
            used[i] = true;
            perm.Add(num);
            Backtrack(nums, used, perm, result);
            used[i] = false;
            perm.RemoveAt(perm.Count - 1);
        }
    }

    public IList<IList<int>> Permute1(int[] nums)
    {
        var result = new List<IList<int>>();
        Backtrack1(nums, 0, result);
        return result;
    }

    private void Backtrack1(int[] nums, int nextStart, IList<IList<int>> result)
    {
        if (nextStart >= nums.Length)
        {
            result.Add(new List<int>(nums));
            Console.WriteLine("add to result");
            return;
        }

        for (int i = nextStart; i < nums.Length; i++)
        {
            Swap(nums, i, nextStart);
            PrintList(nums);
            Backtrack1(nums, nextStart + 1, result);
            Swap(nums, i, nextStart);
            PrintList(nums);
        }
    }

    private void Swap(int[] nums, int i, int j)
    {
        var temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
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

result = s.Permute1(new int[] { 1, 2, 3 });
Console.WriteLine(result);
