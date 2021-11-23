public class Solution
{
    public int FindMin(int[] nums)
    {
        if (nums[0] <= nums[nums.Length - 1])
            return nums[0];
        var left = 0;
        var right = nums.Length;
        
        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (nums[mid] < nums[0])
                right = mid;
            else
                left = mid + 1;
        }

        return nums[left];
    }
}



var s = new Solution();
Console.WriteLine(s.FindMin(new int[] { 3, 4, 5, 1, 2 }));
Console.WriteLine(s.FindMin(new int[] { 11, 13, 15, 17 }));
