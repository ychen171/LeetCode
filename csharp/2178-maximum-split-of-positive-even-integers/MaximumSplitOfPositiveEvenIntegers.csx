public class Solution
{
    // Greedy
    // Time: O(n)
    // Space: O(1)
    public IList<long> MaximumEvenSplit(long finalSum)
    {
        // if finalSum % 2 != 0, return []
        // finalSum = 12
        // 2                sum = 2
        // 2 4              sum = 6          
        // 2 4 6            sum = 12
        // finalSum 28
        // 2                sum = 2
        // 2 4              sum = 6
        // 2 4 6            sum = 12
        // 2 4 6 8          sum = 20 < 28, diff = 8
        // 2 4 6 8 10       sum = 30 > 28, diff = -2
        // 2 6 8 8+8

        var result = new List<long>();
        if (finalSum % 2 != 0) return result;
        long sum = 0;
        long i = 1;
        while (sum + 2 * i <= finalSum)
        {
            var num = 2 * i;
            result.Add(num);
            sum += 2 * i;
            i++;
        }
        long diff = finalSum - sum;
        result[result.Count - 1] += diff;

        return result;
    }
}
