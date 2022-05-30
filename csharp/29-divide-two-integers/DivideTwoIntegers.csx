public class Solution
{
    // Brute force | Repeated Subtraction
    // Time: O(n)
    // Space: O(1)
    public int Divide(int dividend, int divisor)
    {
        if (dividend == 0)
            return 0;

        int quotient = 0;
        if (dividend < 0 && divisor < 0)
        {
            while (dividend <= divisor)
            {
                if (quotient == int.MaxValue)
                    break;
                quotient += 1;
                dividend -= divisor;
            }
        }
        else if (dividend > 0 && divisor > 0)
        {
            while (dividend >= divisor)
            {
                if (quotient == int.MaxValue)
                    break;
                quotient += 1;
                dividend -= divisor;
            }
        }
        else if (dividend < 0 && divisor > 0)
        {
            while (dividend + divisor <= 0)
            {
                if (quotient == int.MinValue)
                    break;
                quotient -= 1;
                dividend += divisor;
            }
        }
        else // dividend > 0 && divisor < 0
        {
            while (dividend + divisor >= 0)
            {
                if (quotient == int.MinValue)
                    break;
                quotient -= 1;
                dividend += divisor;
            }
        }

        return quotient;
    }

    // Repeated Exponential Searches
    // Time: O(log^2 n)
    // Space: O(1)
    public int Divide1(int dividend, int divisor)
    {
        // special case: overflow
        if (dividend == int.MinValue && divisor == -1)
            return int.MaxValue;

        // covert both numbers to negatives
        // count the number of negatives signs
        int negatives = 2;
        if (dividend > 0)
        {
            negatives--;
            dividend = -dividend;
        }
        if (divisor > 0)
        {
            negatives--;
            divisor = -divisor;
        }

        int quotient = 0;
        // once the divisor is bigger thant the current dividend, 
        // we can't fit any more copies of the divisor into it
        while (divisor >= dividend)
        {
            int powerOfTwo = -1;
            int value = divisor;
            while (value >= int.MinValue - value && value + value >= dividend)
            {
                value += value;
                powerOfTwo += powerOfTwo;
            }

            quotient += powerOfTwo;
            dividend -= value;
        }

        if (negatives != 1)
            return -quotient;
        
        return quotient;
    }
}
