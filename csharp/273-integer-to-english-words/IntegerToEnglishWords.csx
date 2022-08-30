public class Solution
{
    // Divide and Conquer
    // Time: O(n)
    // Space: O(1)
    Dictionary<int, string> lessThan10 = new Dictionary<int, string>()
    {
        [1] = "One",
        [2] = "Two",
        [3] = "Three",
        [4] = "Four",
        [5] = "Five",
        [6] = "Six",
        [7] = "Seven",
        [8] = "Eight",
        [9] = "Nine",
    };
    Dictionary<int, string> lessThan20 = new Dictionary<int, string>()
    {
        [10] = "Ten",
        [11] = "Eleven",
        [12] = "Twelve",
        [13] = "Thirteen",
        [14] = "Fourteen",
        [15] = "Fifteen",
        [16] = "Sixteen",
        [17] = "Seventeen",
        [18] = "Eighteen",
        [19] = "Nineteen",
    };
    Dictionary<int, string> tens = new Dictionary<int, string>()
    {
        [2] = "Twenty",
        [3] = "Thirty",
        [4] = "Forty",
        [5] = "Fifty",
        [6] = "Sixty",
        [7] = "Seventy",
        [8] = "Eighty",
        [9] = "Ninety",
    };
    public string NumberToWords(int num)
    {
        if (num == 0)
            return "Zero";

        int billion = num / 1000000000;
        int million = (num % 1000000000) / 1000000;
        int thousand = (num % 1000000) / 1000;
        int rest = num % 1000;

        var sb = new StringBuilder();
        if (billion != 0)
            sb.Append($"{Three(billion)} Billion");
        if (million != 0)
        {
            if (sb.Length != 0)
                sb.Append(' ');
            sb.Append($"{Three(million)} Million");
        }
        if (thousand != 0)
        {
            if (sb.Length != 0)
                sb.Append(' ');
            sb.Append($"{Three(thousand)} Thousand");
        }
        if (rest != 0)
        {
            if (sb.Length != 0)
                sb.Append(' ');
            sb.Append(Three(rest));
        }

        return sb.ToString();
    }

    private string Two(int num)
    {
        if (num == 0)
            return "";
        else if (num < 10)
            return lessThan10[num];
        else if (num < 20)
            return lessThan20[num];
        else
        {
            int tenner = num / 10;
            int rest = num % 10;
            if (rest != 0)
                return $"{tens[tenner]} {lessThan10[rest]}";
            else
                return tens[tenner];
        }
    }

    private string Three(int num)
    {
        int hundred = num / 100;
        int rest = num % 100;
        string result;
        if (hundred * rest != 0)
            result = $"{lessThan10[hundred]} Hundred {Two(rest)}";
        else if ((hundred == 0) && (rest != 0))
            result = Two(rest);
        else if ((hundred != 0) && (rest == 0))
            result = $"{lessThan10[hundred]} Hundred";
        else
            result = "";

        return result;
    }
}

var sln = new Solution();
var num = 123;
var result = sln.NumberToWords(num);
Console.WriteLine(result);

