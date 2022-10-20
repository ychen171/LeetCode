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

    // Dictionary
    // Time: O(1)
    // Space: O(1)
    public string IntToRoman1(int num)
    {
        /*
            I,V,X,L,C,D,M,      1,5,10,50,100,500,1000
            IV,IX,              4,9
            XL,XC               40,90
            CD,CM               400,900
        */
        var dict = new Dictionary<int, string>()
        {
            [1] = "I", [5] = "V", [10] = "X", [50] = "L", [100] = "C", [500] = "D", [1000] = "M", 
            [4] = "IV", [9] = "IX", [40] = "XL", [90] = "XC", [400] = "CD", [900] = "CM", 
        };
        var sb = new StringBuilder();
        while (num > 0)
        {
            int remainder = num;
            int candidate = 0;
            foreach (int key in dict.Keys)
            {
                if (key > num)
                    continue;
                if (num - key < remainder)
                {
                    remainder = num - key;
                    candidate = key;
                }
            }
            num -= candidate;
            sb.Append(dict[candidate]);
        }
        return sb.ToString();
    }
}

