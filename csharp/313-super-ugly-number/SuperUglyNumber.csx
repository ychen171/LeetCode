public class Solution
{
    public int NthSuperUglyNumber(int n, int[] primes)
    {
        var ugly = new long[n + 1];
        int k = primes.Length;
        var products = new long[k];
        var ps = new int[k];
        for (int i = 0; i < k; i++)
        {
            products[i] = 1;
            ps[i] = 1;
        }

        int p = 1;
        while (p <= n)
        {
            // find the min head val and add to the merged list
            var min = long.MaxValue;
            for (int i = 0; i < k; i++)
            {
                min = Math.Min(min, products[i]);
            }
            ugly[p] = min;
            p++;

            // move head forward for each source list
            for (int i = 0; i < k; i++)
            {
                if (products[i] == min)
                {
                    products[i] = primes[i] * ugly[ps[i]];
                    ps[i]++;
                }
            }
        }

        return (int)ugly[n];
    }
}
