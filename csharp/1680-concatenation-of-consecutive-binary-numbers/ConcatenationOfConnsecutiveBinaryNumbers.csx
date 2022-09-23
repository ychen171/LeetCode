public class Solution
{
    // String Manipulation | Runtime Error
    public int ConcatenatedBinary(int n)
    {
        var sb = new StringBuilder();
        for (int i = 1; i <= n; i++)
        {
            var binaryStr = Convert.ToString(i, 2);
            sb.Append(binaryStr);
        }
        long val = Convert.ToInt64(sb.ToString(), 2);
        return (int)(val % 1000000007);
    }

    // Convert binary string to int
    // Time: (n log n)
    // Space: O(n)
    public int ConcatenatedBinary1(int n)
    {
        int result = 0;
        for (int i = 1; i <= n; i++)
        {
            var binaryStr = Convert.ToString(i, 2);
            for (int j = 0; j < binaryStr.Length; j++)
            {
                result = (result * 2 + binaryStr[j] - '0') % 1000000007;
            }
        }

        return result;
    }

    // Math
    // Time: O(n log n)
    // Space: O(1)
    public int ConcatenatedBinary2(int n)
    {
        long result = 0; // long accumulator
        int length = 0;  // bit length of addends
        for (int i = 1; i <= n; i++)
        {
            if (Math.Pow(2, (int)(Math.Log2(i))) == i) // it is power of 2
                length++;
            result = (result * (int)(Math.Pow(2, length)) + i) % 1000000007;
        }

        return (int)result;
    }

    // Math + Bitwise Operation
    // Time: O(n)
    // Space: O(1)
    public int ConcatenatedBinary3(int n)
    {
        long reuslt = 0; // long accumulator
        int length = 0;  // bit length of addends
        for (int i = 1; i <= n; i++)
        {
            if ((i & (i - 1)) == 0) // it is power of 2
                length++;
            reuslt = ((reuslt << length) | i) % 1000000007;
        }

        return (int)reuslt;
    }
}

var sln = new Solution();
var n = 42;
var result = sln.ConcatenatedBinary2(n);
Console.WriteLine(result);

