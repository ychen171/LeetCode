public class Solution
{
    // Brute force | TLE
    // Time: O(n^2)
    // Space: O(1)
    public int[] SmallestSubarrays(int[] nums)
    {
        /*
            1       0       2       1       3
            001     000     010     001     011
        */

        int n = nums.Length;
        var result = new int[n];
        int max = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            max |= nums[i];
            int curr = 0;
            for (int j = i; j < n; j++)
            {
                curr |= nums[j];
                if (curr == max)
                {
                    result[i] = j - i + 1;
                    break;
                }
            }
        }

        return result;
    }

    // Bit Manipulation
    // Time: O(30n)
    // Space: O(30)
    public int[] SmallestSubarrays1(int[] nums)
    {
        int n = nums.Length;
        var last = new int[30];
        var result = new int[n];
        for (int i = n - 1; i >= 0; i--)
        {
            result[i] = 1;
            for (int j = 0; j < 30; j++)
            {
                if ((nums[i] & (1 << j)) > 0) // find the position of each '1' bit
                    last[j] = i;
                result[i] = Math.Max(result[i], last[j] - i + 1);
            }
        }

        return result;
    }
}
