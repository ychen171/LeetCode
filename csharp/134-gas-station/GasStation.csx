public class Solution
{
    // Brute force
    // Time: O(n^2)
    // Space: O(1)
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        int n = gas.Length;
        for (int start = 0; start < n; start++)
        {
            int curr = 0;
            int i = start;
            int k = 0;
            while (k < n)
            {
                curr += gas[i] - cost[i];
                if (curr < 0)
                    break;
                k++;
                i = (i + 1) % n;
            }
            if (k == n)
                return start;
        }

        return -1;
    }

    // Greedy
    // Time: O(n)
    // Space: O(1)
    public int CanCompleteCircuit1(int[] gas, int[] cost)
    {
        int n = gas.Length;
        int sum = 0, minSum = 0;
        int start = 0;
        for (int i = 0; i < n; i++)
        {
            sum += gas[i] - cost[i];
            // find the new min sum
            // the next index is the new start point
            if (sum < minSum)
            {
                start = i + 1;
                minSum = sum;
            }
        }
        // total sum < 0, can never finish the loop
        if (sum < 0)
            return -1;

        return start == n ? 0 : start;
    }
}
