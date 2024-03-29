public class Solution
{
    // Math
    // Time: O(sqrt(n) * log log n)
    // Space: O(n)
    public int CountPrimes(int n)
    {
        // edge case
        if (n <= 2)
            return 0;
        var isPrime = new bool[n];
        for (int i = 2; i < n; i++)
            isPrime[i] = true;
        for (int i = 2; i * i < n; i++)
        {
            if (isPrime[i])
            {
                for (int j = i * i; j < n; j += i)
                    isPrime[j] = false;
            }
        }

        int count = 0;
        for (int i = 2; i < n; i++)
        {
            if (isPrime[i])
                count++;
        }

        return count;
    }
}
