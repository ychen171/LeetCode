public class Solution
{
    private static readonly int[] numbers = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
    private static readonly string[] symbols = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
    
    // Time: O(1)
    // Space: O(1)
    public string IntToRoman(int num)
    {
        var sb = new StringBuilder();
        // Loop through each symbol, stopping if num becomes 0
        for (int i = 0; i < numbers.Length && num > 0; i++)
        {
            // Repeat while the current symbol still fits into num
            while (numbers[i] <= num)
            {
                num -= numbers[i];
                sb.Append(symbols[i]);
            }
        }
        return sb.ToString();
    }
}

