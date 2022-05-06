public class Solution
{
    public int Reverse(int x)
    {
        int ans = 0;
        while (x != 0)
        {
            int modulo = x % 10;
            if ((ans > 0 && ans > (int.MaxValue - modulo) / 10) || (ans < 0 && ans < (int.MinValue - modulo) / 10))
                return 0;
            ans = ans * 10 + modulo;
            x /= 10;
        }

        return ans;
    }
}
