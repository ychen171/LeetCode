public class Solution
{
    // Two pointers
    // Time: O(n)
    // Space: O(1)
    public int[] SortArrayByParity(int[] nums)
    {
        int i = 0;
        int j = 0;
        while (j < nums.Length)
        {
            if (nums[j] % 2 == 0)
            {
                var temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
                i++;
            }
            j++;
        }

        return nums;
    }
}

