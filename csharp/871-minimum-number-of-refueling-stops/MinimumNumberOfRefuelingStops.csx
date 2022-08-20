public class Solution
{
    // DP | Tabulation
    // Time: O(n^2)
    // Space: O(n)
    public int MinRefuelStops(int target, int startFuel, int[][] stations)
    {
        /*
            states: dp[s], s: stop [0, n], dp: maxDistance
            options: refuel, not refuel
            goal: find min s where dp[s] >= target

            dp[s+1] = Math.Max(dp[s+1], dp[s] + stations[i][1])

            base case:
            dp[0] = startFuel
        */
        int n = stations.Length;
        var dp = new int[n + 1];
        dp[0] = startFuel;
        for (int i = 0; i < n; i++)
        {
            var station = stations[i];
            var position = station[0];
            var fuel = station[1];
            for (int s = 0; s <= i; s++)
            {
                if (dp[s] >= position)
                    dp[s + 1] = Math.Max(dp[s + 1], dp[s] + fuel);
            }
        }
        for (int s = 0; s <= n; s++)
        {
            if (dp[s] >= target)
                return s;
        }

        return -1;
    }

    // Greedy + Priority Queue
    // Time: O(n log n)
    // Space: O(n)
    public int MinRefuelStops1(int target, int startFuel, int[][] stations)
    {
        if (startFuel >= target) return 0;
        var pq = new PriorityQueue<int, int>();
        int i = 0;
        int n = stations.Length;
        int stops = 0;
        int maxDistance = startFuel;
        while (maxDistance < target)
        {
            // for the station that is reachable, find the max fuel we can get
            while (i < n && stations[i][0] <= maxDistance)
            {
                var fuel = stations[i][1];
                pq.Enqueue(fuel, -fuel);
                i++;
            }
            // if there is no fuel we can get before reaching target, return -1
            if (pq.Count == 0)
                return -1;
            // refuel and update maxDistance and stops
            maxDistance += pq.Dequeue();
            stops++;
        }

        return stops;
    }
}
