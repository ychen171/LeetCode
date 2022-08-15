public class Solution
{
    // Bit Manipulation | Turn off the rightmost 1-bit
    public bool IsPowerOfTwo(int n)
    {
        if (n <= 0) return false;
        return (n & (n - 1)) == 0;
    }
}
