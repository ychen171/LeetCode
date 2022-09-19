public class Solution
{
    public int SmallestEvenMultiple(int n)
    {
        return LCM(2, n);
    }

    private int LCM(int a, int b)
    {
        return a * b / GCD(a, b);
    }

    private int GCD(int a, int b)
    {
        if (a < b)
            return GCD(b, a);
        if (b == 0)
            return a;
        return GCD(b, a % b);
    }
}
