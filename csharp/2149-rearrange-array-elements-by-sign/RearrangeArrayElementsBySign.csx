public class Solution
{
    // Simulation
    // Time: O(n)
    // Space: O(n)
    public int[] RearrangeArray(int[] nums)
    {
        int n = nums.Length;
        var positives = new List<int>();
        var negatives = new List<int>();
        for (int i = 0; i < n; i++)
        {
            int num = nums[i];
            if (num > 0)
                positives.Add(num);
            else
                negatives.Add(num);
        }

        var result = new List<int>();
        for (int i = 0; i < n / 2; i++)
        {
            result.Add(positives[i]);
            result.Add(negatives[i]);
        }

        return result.ToArray();
    }
}

var s = new Solution();
var nums = new int[] { 3, 1, -2, -5, 2, -4 };
var result = s.RearrangeArray(nums);
Console.WriteLine(result);
