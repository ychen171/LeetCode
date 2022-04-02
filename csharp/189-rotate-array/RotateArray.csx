public class Solution
{
    // Two Pointers
    // Time: O(n)
    // Space: O(k % n)
    public void Rotate(int[] nums, int k)
    {
        int n = nums.Length;
        k = k % n;
        int right = n - k;
        if (right == 0) return;

        // copy second part
        int[] second = new int[k];
        for (int i = 0; i < k; i++)
            second[i] = nums[right + i];
        
        // shift first part to right by secondLen
        for (int i = right - 1; i >= 0; i--)
        {
            nums[i + k] = nums[i];
        }

        // write the copy of second part to the beginning
        for (int i = 0; i < k; i++)
        {
            nums[i] = second[i];
        }

    }
}