public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public int NthUglyNumber(int n)
    {
        var ugly = new int[n + 1];
        int product2 = 1, product3 = 1, product5 = 1;
        int p2 = 1, p3 = 1, p5 = 1;
        int p = 1;
        while (p <= n)
        {
            int min = Math.Min(Math.Min(product2, product3), product5);
            ugly[p] = min;
            p++;
            if (min == product2)
            {
                product2 = 2 * ugly[p2];
                p2++;
            }
            if (min == product3)
            {
                product3 = 3 * ugly[p3];
                p3++;
            }
            if (min == product5)
            {
                product5 = 5 * ugly[p5];
                p5++;
            }
        }

        return ugly[n];
    }
}

var sln = new Solution();
var result = sln.NthUglyNumber(10);
Console.WriteLine(result);

