public class Solution
{
    private static readonly int[] numbers = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
    private static readonly string[] symbols = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
    // Time: O(1)
    // Space: O(1)
    public int RomanToInt(string s)
    {
        int num = 0;
        for (int i=0; i<symbols.Length; i++)
        {
            while (s.StartsWith(symbols[i]))
            {
                num += numbers[i];
                s = s.Substring(symbols[i].Length);
            }
        }

        return num;
    }
}

