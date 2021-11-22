
public class Solution
{
    public int[] SearchRange(int[] nums, int target)
    {
        var result = new int[] { -1, -1 };
        if (nums.Length == 0) return result;

        // search for the left one
        int left = 0;
        int right = nums.Length - 1;
        while (left < right)
        {
            var mid = (left + right) / 2;
            if (target > nums[mid])
                left = mid + 1;
            else
                right = mid;
        }
        if (nums[left] != target) return result;
        result[0] = left;

        // search for the right one
        right = nums.Length - 1;
        while (left < right)
        {
            var mid = (left + right) / 2 + 1;
            if (target < nums[mid])
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




