public class Solution
{
    public int FindMin(int[] nums)
    {
        int left = 0;
        int right = nums.Length - 1;
        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (nums[mid] > nums[right])
                left = mid + 1;
            else if (nums[mid] < nums[right])
                right = mid;
            else // nums[mid] == nums[right]
                right--;
        }

        return nums[left];
    }
}



var s = new Solution();
Console.WriteLine(s.FindMin(new int[] { 3, 4, 5, 1, 2 }));
Console.WriteLine(s.FindMin(new int[] { 11, 13, 15, 17 }));
Console.WriteLine(s.FindMin(new int[] { 2, 1 }));
Console.WriteLine(s.FindMin(new int[] { 2, 2, 1 }));
Console.WriteLine(s.FindMin(new int[] { 3, 1, 3 }));
Console.WriteLine(s.FindMin(new int[] { 3, 3, 1, 3 }));
Console.WriteLine(s.FindMin(new int[] { 1, 0, 1, 1, 1 }));
Console.WriteLine(s.FindMin(new int[] { 1, 1, 1, 0, 1 }));


