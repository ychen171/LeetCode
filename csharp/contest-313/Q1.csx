public class Solution
{
    public int CommonFactors(int a, int b)
    {
        /*
            30  25
            25  5
            5   0
            5

            12  6
            6   0
            6
        */
        int d = GCD(a, b);
        int count = 0;
        for (int i = 1; i <= d; i++)
        {
            if (d % i == 0)
                count++;
        }

        return count;
    }

    public int GCD(int a, int b)
    {
        if (a < b)
            return GCD(b, a);
        if (b == 0)
            return a;
        return GCD(b, a % b);
    }
}
