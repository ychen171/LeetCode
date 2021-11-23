public class Solution
{
    public int Search(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length;
        while (left < right)
        {
            var mid = left + (right - left) / 2;
            // nums[mid] and target are "on the same side of nums[0]", takes nums[mid] as selected value
            // Otherwise do the revert side
            //      if target < nums[0], takes Min as selected value
            //      else, takes Max as selected value
            int selectedValue;
            if ((nums[mid] < nums[0] && target < nums[0]) || (nums[mid] > nums[0] && target > nums[0]))
                selectedValue = nums[mid];
            else
            {
                if (target < nums[0])
                    selectedValue = int.MinValue;
                else
                    selectedValue = int.MaxValue;
            }
            if (selectedValue < target)
                left = mid + 1;
            else if (selectedValue > target)
                right = mid;
            else
                return mid;
        }

        if (left != nums.Length && nums[left] == target) return left;
        else return -1;
    }
    
}


var s = new Solution();

Console.WriteLine(s.Search(new int[] { 0, 1, 2 }, 0));
Console.WriteLine(s.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0));
Console.WriteLine(s.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3));
Console.WriteLine(s.Search(new int[] { 1 }, 0));

Console.WriteLine(s.Search(new int[] { 3, 5, 1 }, 3));
Console.WriteLine(s.Search(new int[] { 1, 3 }, 2));
Console.WriteLine(s.Search(new int[] { 4, 5, 6, 7, 8, 1, 2, 3 }, 8));
Console.WriteLine(s.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0));
Console.WriteLine(s.Search(new int[] { 1, 3 }, 1));
Console.WriteLine(s.Search(new int[] { 3, 1 }, 1));
Console.WriteLine(s.Search(new int[] { 1, 3 }, 3));







