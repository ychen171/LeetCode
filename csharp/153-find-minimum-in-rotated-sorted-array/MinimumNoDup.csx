public class Solution
{
    public int FindMin(int[] nums)
    {
        if (nums[0] <= nums[nums.Length - 1])
            return nums[0];
        var left = 0;
        var right = nums.Length - 1;

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

    public int FindMin2(int[] nums)
    {
        int left = 0;
        int right = nums.Length - 1;
        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (nums[mid] > nums[right])
                left = mid + 1;
            else
                right = mid;
        }

        return nums[left];
    }
}

var s = new Solution();
Console.WriteLine(s.FindMin(new int[] { 0 }));
Console.WriteLine(s.FindMin(new int[] { 3, 4, 5, 1, 2 }));
Console.WriteLine(s.FindMin(new int[] { 11, 13, 15, 17 }));
Console.WriteLine(s.FindMin(new int[] { 2, 1 }));
Console.WriteLine();

Console.WriteLine(s.FindMin(new int[] { 0 }));
Console.WriteLine(s.FindMin2(new int[] { 3, 4, 5, 1, 2 }));
Console.WriteLine(s.FindMin2(new int[] { 11, 13, 15, 17 }));
Console.WriteLine(s.FindMin2(new int[] { 2, 1 }));
Console.WriteLine();




