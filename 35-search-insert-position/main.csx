public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;
        while (left < right)
        {
            var mid = (left + right) / 2;
            if (target < nums[mid])
            {
                right = mid - 1;
            }
            else if (target > nums[mid])
            {
                left = mid + 1;
            }
            else
                return mid;
        }
        if (target <= nums[left])
            return left;
        else
            return left + 1;
    }
}

var s = new Solution();
Console.WriteLine(s.SearchInsert(new int[] { 1, 3, 5, 6 }, 5));
Console.WriteLine(s.SearchInsert(new int[] { 1, 3, 5, 6 }, 2));
Console.WriteLine(s.SearchInsert(new int[] { 1, 3, 5, 6 }, 7));
Console.WriteLine(s.SearchInsert(new int[] { 1, 3, 5, 6 }, 0));
Console.WriteLine(s.SearchInsert(new int[] { 1 }, 0));




