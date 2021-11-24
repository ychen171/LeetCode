public class Solution
{
    // Brute force
    public double MyPow(double x, int n)
    {
        if (n == 0) return 1.0;
        if (n < 0)
        {
            x = 1 / x;
            n = -n;
        }
        double result = 1.0;
        for (int i = 0; i < n; i++)
            result *= x;
        return result;
    }

    // fast power algorithm recursive
    public double MyPowRecursive(double x, int n)
    {
        // TODO
        return 0;
    }

    // fast power algorithm iterative
    public double MyPowIterative(double x, int n)
    {
        if (n == 0) return 1.0;
        long longN = n;
        if (longN < 0)
        {
            x = 1 / x;
            longN = -longN;
        }
        double result = 1;
        double currentValue = x;
        for (long i = longN; i > 0; i >>= 1)
        {
            if (i % 2 == 1) // i is odd
                result = result * currentValue;
            currentValue = currentValue * currentValue;
        }

        return result;
    }
}

var s = new Solution();
Console.WriteLine(s.MyPow(2.0, 10));
Console.WriteLine(s.MyPow(2.1, 3));
Console.WriteLine(s.MyPow(2.0, -2));
Console.WriteLine(s.MyPowIterative(2.0, 5));
Console.WriteLine(s.MyPowIterative(2.0, 10));
Console.WriteLine(s.MyPowIterative(2.1, 3));
Console.WriteLine(s.MyPowIterative(2.0, -2));
Console.WriteLine(s.MyPowIterative(2.0, -2147483648));
