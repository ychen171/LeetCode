public class Solution
{
    // Bit Manipulation
    // Time: O(1)
    // Space: O(1)
    public int RangeBitwiseAnd(int left, int right)
    {
        while (left < right)
        {
            right &= (right - 1);
        }

        return left & right;
    }
}
