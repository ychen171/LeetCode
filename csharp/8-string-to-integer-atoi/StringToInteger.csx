public class Solution
{
    // Follow the Rules
    // Time: O(n)
    // Space: O(1)
    public int MyAtoi(string s)
    {
        int sign = 1;
        int number = 0;
        int i = 0;
        int n = s.Length;

        while (i < n && s[i] == ' ')
            i++;
        
        if (i < n && s[i] == '-')
        {
            sign = -1;
            i++;
        }
        else if (i < n && s[i] == '+')
        {
            sign = 1;
            i++;
        }
        while (i < n && char.IsDigit(s[i]))
        {
            int digit = int.Parse(s[i].ToString());
            if (number > int.MaxValue / 10 || (number == int.MaxValue / 10 && digit > int.MaxValue % 10))
                return sign == 1 ? int.MaxValue : int.MinValue;
            
            number = 10 * number + digit;
            i++;
        }

        return sign * number;
    }
}

var s = new Solution();
Console.WriteLine(s.MyAtoi("   -42"));

