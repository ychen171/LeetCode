public class Solution
{
    // bitwise operation
    // Time: O(n^2)
    // Space: O(n)
    public int MinimizeXor(int num1, int num2)
    {
        var cs1 = Convert.ToString(num1, 2).ToCharArray();
        var cs2 = Convert.ToString(num2, 2).ToCharArray();
        int setbits2 = 0;
        foreach (var c in cs2)
        {
            if (c == '1')
                setbits2++;
        }
        int setbits1 = 0;
        foreach (var c in cs1)
        {
            if (c == '1')
                setbits1++;
        }
        // setbits1 > setbits2
        // setbits1 < setbits2
        // setbits1 == setbits2
        int result = num1;
        for (int i = 0; i < 32; i++)
        {
            if (setbits1 > setbits2 && ((1 << i) & num1) > 0)
            {
                result ^= 1 << i;
                setbits1--;
            }
            if (setbits1 < setbits2 && ((1 << i) & num1) == 0)
            {
                result ^= 1 << i;
                setbits1++;
            }
        }

        return result;
    }
}
