public class Solution
{
    // Built-in convert to string representation
    // Time: O(1)
    // Space: O(1)
    public int HammingWeight(uint n)
    {
        int count = 0;
        string binary = Convert.ToString(n, 2);
        foreach (var c in binary)
        {
            if (c == '1')
                count++;
        }

        return count;
    }

    // Bit Manipulation
    // Time: O(1)
    // Space: O(1)
    public int HammingWeight1(uint n)
    {
        int count = 0;

        while (n > 0)
        {
            if (n % 2 == 1)
                count++;
            n >>= 1;
        }

        return count;
    }
}
