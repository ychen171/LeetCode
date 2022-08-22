public class Solution
{
    // Naive
    // Time: O(log n)
    // Space: O(1)
    public bool IsPowerOfFour(int n)
    {
        if (n <= 0)
            return false;

        while (n > 1)
        {
            int remainder = n % 4;
            if (remainder != 0)
                return false;
            n /= 4;
        }

        return n == 1;
    }

    // Brute Force + Precomputations
    // Time: O(1)
    // Space: O(1)
    public bool IsPowerOfFour1(int n)
    {
        var nums = new HashSet<int>();
        int lastNum = 1;
        nums.Add(lastNum);
        for (int i = 1; i < 16; i++)
        {
            lastNum = lastNum * 4;
            nums.Add(lastNum);
        }

        return nums.Contains(n);
    }

    // Math
    // Time: O(1)
    // Space: O(1)
    public bool IsPowerOfFour2(int n)
    {
        return (n > 0) && (Math.Log(n) / Math.Log(2) % 2 == 0);
    }

    // Bit Manipulation
    // Time: O(1)
    // Space: O(1)
    public bool IsPowerOfFour3(int n)
    {
        return (n > 0) && ((n & (n - 1)) == 0) && ((n & 0xaaaaaaaa) == 0);
    }

    // Bit Manipulation + Math
    // Time: O(1)
    // Space: O(1)
    public bool IsPowerOfFour4(int n)
    {
        return (n > 0) && ((n & (n - 1)) == 0) && (n % 3 == 1);
    }
}
