
public class Solution
{
    // Brute force
    // Time: O(n^2)
    // Space: O(1)
    public int[] TwoSum(int[] nums, int target)
    {
        var result = new int[2] { 0, 1 };
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    result[0] = i;
                    result[1] = j;
                    break;
                }
            }
        }

        return result;
    }

    // Dictionary
    // Time: O(n)
    // Space: O(n)
    public int[] TwoSumDict(int[] nums, int target)
    {
        var result = new int[2] { 0, 1 };
        var dict = new Dictionary<int, int>();
        
        for (int i = 0; i < nums.Length; i++)
        {
            var remainder = target - nums[i];
            if (dict.ContainsKey(remainder))
            {
                result[0] = dict[remainder];
                result[1] = i;
                break;
            }

            dict[nums[i]] = i;
        }

        return result;
    }
}

var s = new Solution();
Console.WriteLine(s.TwoSumDict(new int[]{3,2,4}, 6));

