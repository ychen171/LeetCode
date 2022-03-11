public class Solution
{
    // Single Pass | Two Pointers
    // Time: O(N)
    // Space: O(1)
    public void NextPermutation(int[] nums)
    {
        int n = nums.Length;
        int i = n - 1;
        while (i != 0)
        {
            if (nums[i - 1] < nums[i]) break;
            i--;
        }
        if (i != 0)
        {
            int j = n - 1;
            while (nums[j] <= nums[i - 1])
            {
                j--;
            }
            Swap(nums, i - 1, j);
        }
        Reverse(nums, i);
    }

    private void Swap(int[] nums, int i, int j)
    {
        var temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
    private void Reverse(int[] nums, int start)
    {
        int i = start;
        int j = nums.Length - 1;
        while (i < j)
        {
            Swap(nums, i, j);
            i++;
            j--;
        }
    }
}
