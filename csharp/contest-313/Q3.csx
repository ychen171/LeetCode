public class Solution
{
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

        if (setbits1 > setbits2)
        {
            int count = 0;
            int i = 0;
            var sb = new StringBuilder();
            for (; i < cs1.Length && count < setbits2; i++)
            {
                if (cs1[i] == '1')
                {
                    sb.Append('1');
                    count++;
                }
            }
            for (; i < cs1.Length; i++)
            {
                sb.Append('0');
            }
            var str1 = sb.ToString();
            return Convert.ToInt32(str1, 2);
        }
        else if (setbits1 < setbits2)
        {
            int count = 0;
            int i = cs1.Length - 1;
            for (; i >= 0; i--)
            {
                if (count < setbits2 - setbits1)
                {
                    if (cs1[i] == '0')
                    {
                        cs1[i] = '1';
                        count++;
                    }
                }
            }
            var sb = new StringBuilder();
            while (count < setbits2 - setbits1)
            {
                sb.Append('1');
                count++;
            }
            sb.Append(cs1);
            var str1 = sb.ToString();
            return Convert.ToInt32(str1, 2);
        }
        else // ==
        {
            return num1;
        }
    }
}

var sln = new Solution();
// 1110 1100    -> 1100   12
Console.WriteLine(sln.MinimizeXor(14, 12));
// 1100 1110    -> 1101   13
Console.WriteLine(sln.MinimizeXor(12, 14));
// 1110 1110    -> 1110   14
Console.WriteLine(sln.MinimizeXor(14, 14));
// 0001 1100    -> 0011    3
Console.WriteLine(sln.MinimizeXor(1, 12));
// 