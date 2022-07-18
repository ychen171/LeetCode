
public class Solution
{
    public int[] SearchRange(int[] nums, int target)
    {
        var ans = new int[] { -1, -1 };
        int n = nums.Length;
        if (n == 0)
            return ans;

        ans[0] = BinarySearchLeftBound1(nums, target);
        ans[1] = BinarySearchRightBound1(nums, target);

        return ans;
    }

    public int BinarySearchLeftBound(int[] nums, int target)
    {
        int n = nums.Length;
        int left = 0;
        int right = n - 1;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            // [..., mid][mid + 1, ...]
            if (nums[mid] < target)
                left = mid + 1;
            else // nums[mid] >= target
                right = mid;
        }

        return nums[left] == target ? left : -1;
    }

    public int BinarySearchLeftBound1(int[] nums, int target)
    {
        int n = nums.Length;
        int left = 0;
        int right = n - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] < target)
                left = mid + 1;
            else if (nums[mid] > target)
                right = mid - 1;
            else
                right = mid - 1;
        }

        // left = right + 1
        if (left == n) return -1;
        return nums[left] == target ? left : -1;
    }

    public int BinarySearchRightBound(int[] nums, int target)
    {
        int n = nums.Length;
        int left = 0;
        int right = n - 1;
        while (left < right)
        {
            int mid = left + (right - left + 1) / 2;
            // [..., mid - 1][mid, ...]
            if (nums[mid] > target)
                right = mid - 1;
            else // nums[mid] <= target
                left = mid;
        }

        return nums[right] == target ? right : -1;
    }

    public int BinarySearchRightBound1(int[] nums, int target)
    {
        int n = nums.Length;
        int left = 0;
        int right = n - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] < target)
                left = mid + 1;
            else if (nums[mid] > target)
                right = mid - 1;
            else
                left = mid + 1;
        }

        // left = right + 1
        if (right == -1) return -1;
        return nums[right] == target ? right : -1;
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




