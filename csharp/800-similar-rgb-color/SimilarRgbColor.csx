public class Solution
{
    // string manipulation
    // Time: O(16 * 3) => O(1)
    // Space: O(1)
    public string SimilarRGB(string color)
    {
        var sb = new StringBuilder();
        sb.Append('#');

        for (int i = 1; i < 6; i += 2)
        {
            var target = FindTarget(color.Substring(i, 2));
            sb.Append(target);
        }
        return sb.ToString();
    }
    /*
        given string "colorSection" representing a two-digit
        base 16 number "AB", find out the number "XX" that 
        has the highest similarity to "AB"
    */
    public string FindTarget(string colorSection)
    {
        // convert 16 base string representation to 10 base int
        int num = Convert.ToInt32(colorSection, 16);
        int ans = -1, minDiff = 1000;

        for (int i = 0; i < 16; i++)
        {
            // (XX)16 = 16 * X + X = 17 * X
            var currDiff = (int)Math.Pow(i * 17 - num, 2);
            if (currDiff < minDiff)
            {
                minDiff = currDiff;
                ans = i;
            }
        }
        // convert 10 base int to single digit 16 base lower case string (shorthand)
        var str = ans.ToString("x");
        // double the shorthand
        return str + str;
    }
}

var sln = new Solution();
var color = "#09f166";
var result = sln.SimilarRGB(color);
Console.WriteLine(result);
