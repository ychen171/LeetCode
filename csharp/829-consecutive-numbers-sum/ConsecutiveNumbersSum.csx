public class Solution
{
    public int ConsecutiveNumbersSum(int n)
    {
        int result = 0;
        int upperLimit = (int) (Math.Sqrt(2 * n + 0.25) - 0.5);
        for (int k = 1; k <= upperLimit; k++)
        {
            if ((n - k * (k + 1) / 2) % k == 0)
                result++;
        }
        return result;
    }
}
// Math
// Time: O(sqrt(n))
// Space: O(1)
