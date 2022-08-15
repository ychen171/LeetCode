public class Solution
{
    // factorial is too big
    public int TrailingZeroes(int n)
    {
        if (n == 0) return 0;
        long factorial = 1;
        for (int i = 1; i <= n; i++)
            factorial *= i;

        int ans = 0;
        while (factorial % 10 == 0)
        {
            ans++;
            factorial /= 10;
        }

        return ans;
    }

    public int TrailingZeroes1(int n)
    {
        long ans = 0;
        long divisor = 5;
        while (divisor <= n)
        {
            ans += n / divisor;
            divisor *= 5;
        }

        return (int)ans;
    }
}
