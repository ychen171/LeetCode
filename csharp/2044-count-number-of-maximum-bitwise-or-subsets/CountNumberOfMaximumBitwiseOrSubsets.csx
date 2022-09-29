public class Solution
{
    // Backtracking + Bitwise
    // Time: O(2^n)
    // Space: O(2^n)
    int count = 0;
    public int CountMaxOrSubsets(int[] nums)
    {
        /*
            3       2       1       5
            011     010     001     101  
        */

        int max = 0;
        foreach (var num in nums)
            max |= num;

        Backtrack(nums, max, new List<int>(), 0);
        return count;
    }

    public void Backtrack(int[] nums, int target, List<int> path, int start)
    {
        /*
            find subsets
            input has dups, output can have dups
            num can not be reused
            result subsets can be duplicated
        */
        int n = nums.Length;
        // base case
        int ans = 0;
        foreach (var element in path)
            ans |= element;
        if (ans == target)
            count++;

        // recursive case
        for (int i = start; i < n; i++)
        {
            path.Add(nums[i]);
            Backtrack(nums, target, path, i + 1);
            path.RemoveAt(path.Count - 1);
        }
    }
}

var sln = new Solution();
// var nums = new int[] { 3, 2, 1, 5 };
var nums = new int[] { 2, 2, 2 };
Console.WriteLine(sln.CountMaxOrSubsets(nums));
