public class Solution
{
    private static readonly int[] numbers = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
    private static readonly string[] symbols = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
    // Time: O(1)
    // Space: O(1)
    public int RomanToInt(string s)
    {
        int num = 0;
        for (int i = 0; i < symbols.Length; i++)
        {
            while (s.StartsWith(symbols[i]))
            {
                num += numbers[i];
                s = s.Substring(symbols[i].Length);
            }
        }

        return num;
    }

    // left to right pass
    // Time: O(1)
    // Space: O(1)
    public int RomanToInt1(string s)
    {
        var dict = new Dictionary<string, int>()
        {
            ["M"] = 1000,
            ["CM"] = 900,
            ["D"] = 500,
            ["CD"] = 400,
            ["C"] = 100,
            ["XC"] = 90,
            ["L"] = 50,
            ["XL"] = 40,
            ["X"] = 10,
            ["IX"] = 9,
            ["V"] = 5,
            ["IV"] = 4,
            ["I"] = 1,
        };

        int ans = 0;
        while (s != string.Empty)
        {
            foreach (var symbol in dict.Keys)
            {
                if (s.StartsWith(symbol))
                {
                    ans += dict[symbol];
                    s = s.Substring(symbol.Length);
                    break;
                }
            }
        }

        return ans;
    }
}

