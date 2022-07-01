public class Solution
{
    // Binary Search
    // Time: O(n * log (n*m))
    // Space: O(1)
    // n is the number of weights
    // m is the maximum weight
    public int ShipWithinDays(int[] weights, int days)
    {
        // binary search to find the min capacity
        int n = weights.Length;
        int left = 0;
        int right = weights.Sum();
        while (left < right)
        {
            // [..., mid][mid + 1, ...]
            int mid = left + (right - left) / 2;
            if (CanShip(weights, days, mid))
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }

    public bool CanShip(int[] weights, int days, int capacity)
    {
        int n = weights.Length;
        int totalWeight = 0;
        int totalDays = 1;
        for (int i = 0; i < n; i++)
        {
            int weight = weights[i];
            if (totalWeight + weight <= capacity) // same day
            {
                totalWeight += weight;
            }
            else // new day
            {
                totalDays++;
                totalWeight = weight;
            }
            if (totalDays > days || totalWeight > capacity)
                return false;
        }

        return true;
    }
}

var s = new Solution();
var weights = new int[] { 1, 2, 3, 1, 1 };
var days = 4;
var result = s.ShipWithinDays(weights, days);
Console.WriteLine(result);
