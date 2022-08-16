public class Solution
{
    // Divide and Conquer | Recursion
    // Time: O(n)
    // Space: O(n)
    int divisor = 1337;
    public int SuperPow(int a, int[] b)
    {
        /*
            a^[4,3,3,8,5,2]
            (a^[4,3,3,8,5])^10 * a^2
        */
        a %= divisor;
        return (int)Helper(a, b.ToList());
    }

    private int Helper(int a, List<int> b)
    {
        // base case
        if (b.Count == 0)
            return 1;
        // recursive case
        int last = b.Last();
        b.RemoveAt(b.Count - 1);
        return ((MyPow(Helper(a, b), 10) % divisor) * (MyPow(a, last) % divisor)) % divisor;
    }

    private int MyPow(int a, int k)
    {
        a %= divisor;
        int ans = 1;
        for (int i = 1; i <= k; i++)
        {
            ans *= a;
            ans %= divisor;
        }

        return ans;
    }
}
