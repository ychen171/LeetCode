public class Solution
{
    public int MirrorReflection(int p, int q)
    {
        // m * p = n * q
        // m is even && n is odd,  return 0
        // m is odd  && n is odd,  return 1
        // m is odd  && n is even, return 2
        while (p % 2 == 0 && q % 2 == 0)
        {
            p /= 2;
            q /= 2;
        }

        return 1 - p % 2 + q % 2;
    }
}
