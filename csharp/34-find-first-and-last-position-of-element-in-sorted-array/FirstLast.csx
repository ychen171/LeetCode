
public class Solution
{
    public int[] SearchRange(int[] nums, int target)
    {
        var result = new int[] { -1, -1 };
        if (nums.Length == 0) return result;

        // search for the left most one
        int left = 0;
        int right = nums.Length - 1;
        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (nums[mid] < target)
                left = mid + 1;
            else
                right = mid;
        }
        if (nums[left] != target) return result;
        result[0] = left;

        // search for the right most one
        right = nums.Length - 1;
        while (left < right)
        {
            var mid = left + (right - left) / 2 + 1;
            if (nums[mid] > target)
                right = mid - 1;
            else
                left = mid;
        }
        result[1] = right;

        return result;
    }
}

public void PrintResult(int[] input)
{
    var sb = new StringBuilder();
    sb.Append("[");
    foreach (var item in input)
        sb.Append(item + ", ");
    sb.Remove(sb.Length - 2, 2);
    sb.Append("]");

    Console.WriteLine(sb.ToString());
}


var s = new Solution();

PrintResult(s.SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 8));
PrintResult(s.SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 6));
PrintResult(s.SearchRange(new int[] { }, 0));
PrintResult(s.SearchRange(new int[] { 1 }, 1));
PrintResult(s.SearchRange(new int[] { 0, 1, 1, 1, 1, 1, 2, 2, 3, 4 }, 1));
PrintResult(s.SearchRange(new int[] { 0, 1, 1, 1, 1, 1, 2, 2, 3, 4 }, 4));
PrintResult(s.SearchRange(new int[] { 0, 1, 1, 1, 1, 1, 2, 2, 3, 4, 4, 4 }, 4));
PrintResult(s.SearchRange(new int[] { 2, 2 }, 3));
PrintResult(s.SearchRange(new int[] { 0, 1 }, 1));




