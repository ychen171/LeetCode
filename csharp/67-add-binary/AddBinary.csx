public class Solution
{
    // Brute force | bit by bit
    // Time: O(max(m,n))
    // Space: O(max(m,n))
    public string AddBinary(string a, string b)
    {
        int aLen = a.Length;
        int bLen = b.Length;
        int len = Math.Min(aLen, bLen);
        var sb = new StringBuilder();
        bool carry = false;
        for (int i = 0; i < len; i++)
        {
            char c1 = a[aLen - 1 - i];
            char c2 = b[bLen - 1 - i];
            bool c1IsOne = c1 == '1';
            bool c2IsOne = c2 == '1';
            if (carry)
            {
                if (c1IsOne && c2IsOne)
                {
                    sb.Append('1');
                }
                else if (!c1IsOne && !c2IsOne)
                {
                    sb.Append('1');
                    carry = false;
                }
                else
                {
                    sb.Append('0');
                }
            }
            else
            {
                if (c1IsOne && c2IsOne)
                {
                    sb.Append('0');
                    carry = true;
                }
                else if (!c1IsOne && !c2IsOne)
                {
                    sb.Append('0');
                }
                else
                {
                    sb.Append('1');
                }
            }
        }

        if (aLen > len)
        {
            for (int i = len; i < aLen; i++)
            {
                char c1 = a[aLen - 1 - i];
                if (carry)
                {
                    if (c1 == '1')
                    {
                        sb.Append('0');
                    }
                    else
                    {
                        sb.Append('1');
                        carry = false;
                    }
                }
                else
                {
                    sb.Append(c1);
                }
            }
        }
        if (bLen > len)
        {
            for (int i = len; i < bLen; i++)
            {
                char c2 = b[bLen - 1 - i];
                if (carry)
                {
                    if (c2 == '1')
                    {
                        sb.Append('0');
                    }
                    else
                    {
                        sb.Append('1');
                        carry = false;
                    }
                }
                else
                {
                    sb.Append(c2);
                }
            }
        }

        if (carry)
            sb.Append('1');

        return new string(sb.ToString().Reverse().ToArray());
    }
}