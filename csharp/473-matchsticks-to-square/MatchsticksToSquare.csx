public class Solution
{
    // DFS | Recursion
    // Time: O(4^n)
    // Space: O(n)
    public bool Makesquare(int[] matchsticks)
    {
        int n = matchsticks.Length;
        if (n < 4)
            return false;

        int sum = matchsticks.Sum();
        if (sum % 4 != 0)
            return false;

        int target = sum / 4;
        Array.Sort(matchsticks, (a, b) => b - a);
        var lengths = new int[4];
        return Helper(matchsticks, target, 0, lengths);
    }

    public bool Helper(int[] nums, int target, int index, int[] lengths)
    {
        int n = nums.Length;
        // base case
        if (index == n)
        {
            for (int k = 0; k < 4; k++)
            {
                if (lengths[k] != target)
                    return false;
            }
            return true;
        }
        for (int k = 0; k < 4; k++)
        {
            if (lengths[k] > target)
                return false;
        }

        // recursive case
        bool ans = false;
        for (int k = 0; k < 4; k++)
        {
            lengths[k] += nums[index];
            if (Helper(nums, target, index + 1, lengths))
            {
                ans = true;
                break;
            }
            lengths[k] -= nums[index];
        }

        return ans;
    }
}

var s = new Solution();
bool result;
// result = s.Makesquare(new int[] { 2, 2, 2, 2, 2, 6 });
// Console.WriteLine(result);
//[5,5,5,5,4,4,4,4,3,3,3,3]
result = s.Makesquare(new int[] { 5, 5, 5, 5, 4, 4, 4, 4, 3, 3, 3, 3 });
Console.WriteLine(result);

