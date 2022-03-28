public class Solution
{
    // two nested loops
    // Time: O(n^2)
    // Space: O(1)
    public void MoveZeroes1(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i; j < nums.Length; j++)
            {
                if (nums[j] != 0)
                {
                    var temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                    break;
                }
            }
        }
    }

    // two-pointer 
    // Time: O(n)
    // Space: O(1)
    public void MoveZeroes2(int[] nums)
    {
        int i = 0;
        int j = 0;
        // find non-0 element and populate them from the beginning
        while (j < nums.Length)
        {
            if (nums[j] != 0)
            {
                nums[i] = nums[j];
                i++;
            }
            j++;
        }
        // set the rest to be 0
        while (i < nums.Length)
        {
            nums[i] = 0;
            i++;
        }
    }
}

public void Print(int[] nums)
{
    var sb = new StringBuilder();
    sb.Append("[");
    foreach (var num in nums)
        sb.Append(num + ", ");
    sb.Remove(sb.Length - 2, 2);
    sb.Append("]");
    Console.WriteLine(sb.ToString());
}

var s = new Solution();
var nums = new int[] { 0, 1, 0, 3, 12 };
Print(nums);
s.MoveZeroes2(nums);
Print(nums);









