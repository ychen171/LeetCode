public class Solution
{
    public int PreimageSizeFZF(int k)
    {
        long min = 0;
        long max = long.MaxValue - 1;
        var lb = BinarySearchLeftBound(min, max, k);
        if (lb == -1)
            return 0;

        var rb = BinarySearchRightBound(lb, max, k);
        if (rb == -1)
            return 0;

        // [lb, rb]
        return (int)(rb - lb + 1);
    }

    private long TrailingZeros(long n)
    {
        long count = 0;
        long divisor = 5;
        while (divisor <= n)
        {
            count += n / divisor;
            divisor *= 5;
        }

        return count;
    }

    private long BinarySearchLeftBound(long min, long max, long k)
    {
        var left = min;
        var right = max;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            var count = TrailingZeros(mid);
            if (count < k)
                left = mid + 1;
            else if (count > k)
                right = mid - 1;
            else // ==
                right = mid - 1;
        }

        if (left == max + 1) return -1;
        var leftCount = TrailingZeros(left);
        return leftCount == k ? left : -1;
    }
    private long BinarySearchRightBound(long min, long max, long k)
    {
        var left = min;
        var right = max;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            var count = TrailingZeros(mid);
            if (count < k)
                left = mid + 1;
            else if (count > k)
                right = mid - 1;
            else // ==
                left = mid + 1;
        }

        if (right == -1) return -1;
        var rightCount = TrailingZeros(right);
        return rightCount == k ? right : -1;
    }
}

var sln = new Solution();
int result = 0;
result = sln.PreimageSizeFZF(0);
Console.WriteLine(result);
result = sln.PreimageSizeFZF(5);
Console.WriteLine(result);
result = sln.PreimageSizeFZF(3);
Console.WriteLine(result);

