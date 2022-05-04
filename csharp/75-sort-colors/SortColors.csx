public class Solution
{
    // Two Pointers | Three Pointers | One Pass
    // Time: O(n)
    // Space: O(1)
    public void SortColors(int[] nums)
    {
        //  2   0   2   1   1   0
        //  p0                  p2
        //  i
        //  0   0   2   1   1   2
        //  p0              p2
        //  i
        //      p0          p2
        //      i
        //          p0      p2
        //          i
        //  0   0   1   1   2   2
        //          p0  p2
        //          i
        //              i

        //  2   0   1
        //  p0      p2
        //  i
        //  1   0   2
        //  p0  p2
        //  i
        //      i

        int n = nums.Length;
        if (n == 1)
            return;
        int p0 = 0;
        int p2 = n - 1;
        int i = 0;

        while (i <= p2)
        {
            int num = nums[i];
            if (num == 0)
            {
                Swap(nums, p0, i);
                p0++;
                i++;
            }
            else if (num == 2)
            {
                Swap(nums, i, p2);
                p2--;
            }
            else
            {
                i++;
            }
        }
    }

    private void Swap(int[] nums, int i, int j)
    {
        var temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}
