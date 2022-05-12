public class Solution
{
    // Math
    // Time: O(1)
    // Space: O(1)
    public long[] SumOfThree(long num)
    {
        long remainder = num % 3;
        long quotient = num / 3;
        // 33,  
        // 11, 0,       [10,11,12]
        if (remainder == 0)
        {
            return new long[] { quotient - 1, quotient, quotient + 1 };
        }
        // 4,
        // 1, 1
        // 5
        // 1, 2

        return new long[] { };
    }
}
