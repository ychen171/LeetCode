public class Solution
{
    public int FindPeakElement(int[] nums)
    {
        var left = 0;
        var right = nums.Length;

        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (mid < nums.Length - 1 && nums[mid] < nums[mid + 1])
                left = mid + 1;
            else
                right = mid;
        }

        return left;
    }
}


var s = new Solution();
Console.WriteLine(s.FindPeakElement(new int[]{1}));



