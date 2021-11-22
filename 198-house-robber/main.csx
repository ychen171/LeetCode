using System.Runtime.Intrinsics.X86;
public class Solution
{
    public int Rob(int[] nums)
    {
        if (nums.Length == 1) return nums[0];

        int sum1 = 0;
        for (int i = 0; i < nums.Length; i += 2)
        {
            sum1 += nums[i];
        }
        int sum2 = 0;
        for (int j = 1; j < nums.Length; j += 2)
        {
            sum2 += nums[j];
        }

        return sum1 > sum2 ? sum1 : sum2;
    }
}

var nums = new int[] { 1, 2, 3, 1 };
var s = new Solution();
var result = s.Rob(nums);
Console.WriteLine(result);

nums = new int[] { 2, 7, 9, 3, 1 };
result = s.Rob(nums);
Console.WriteLine(result);

nums = new int[] { 2, 1, 1, 2 };
result = s.Rob(nums);
Console.WriteLine(result);

