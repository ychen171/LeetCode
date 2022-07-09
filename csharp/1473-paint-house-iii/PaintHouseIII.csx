public class Solution
{
    int globalMinCost = int.MaxValue;
    int[] houses;
    int[][] cost;
    int m;
    int n;
    int targetCount;
    // DP | Top-down | Recursion
    // Time: O(n^m)
    // Space: O(m)
    public int MinCost(int[] houses, int[][] cost, int m, int n, int target)
    {
        this.houses = houses;
        this.cost = cost;
        this.m = m;
        this.n = n;
        this.targetCount = target;
        Helper(0, 0, 0, 0);
        return globalMinCost == int.MaxValue ? -1 : globalMinCost;
    }

    public void Helper(int nextIndex, int currColor, int neighborCount, int totalCost)
    {
        // base case
        if (nextIndex == m && neighborCount == targetCount)
        {
            globalMinCost = Math.Min(globalMinCost, totalCost);
            return;
        }
        if (nextIndex >= m)
            return;
        if (neighborCount > targetCount)
            return;

        // recursive case
        int nextColor = 0;
        int nextCost = 0;
        if (houses[nextIndex] != 0) // already painted
        {
            nextColor = houses[nextIndex];
            if (currColor == nextColor)
                Helper(nextIndex + 1, nextColor, neighborCount, totalCost);
            else
                Helper(nextIndex + 1, nextColor, neighborCount + 1, totalCost);
        }
        else // not painted yet
        {
            int[] costPerColor = cost[nextIndex];
            for (int j = 0; j < n; j++)
            {
                nextColor = j + 1;
                nextCost = costPerColor[j];
                if (currColor == nextColor)
                    Helper(nextIndex + 1, nextColor, neighborCount, totalCost + nextCost);
                else
                    Helper(nextIndex + 1, nextColor, neighborCount + 1, totalCost + nextCost);
            }
        }
    }

    // DP | Top-down | Memoization | Recursion
    // Time: O(m * n * t)
    // Space: O(m * n * t)
    public int MinCost1(int[] houses, int[][] cost, int m, int n, int target)
    {
        this.houses = houses;
        this.cost = cost;
        this.m = m;
        this.n = n;
        this.targetCount = target;
        var memo = new int[m, n + 1, target + 1];
        var ans = MinCostR(0, 0, 0, memo);
        return ans == int.MaxValue ? -1 : ans;
    }

    public int MinCostR(int currIndex, int prevColor, int prevNeiCount, int[,,] memo)
    {
        // base case
        if (currIndex == m)
            return prevNeiCount == targetCount ? 0 : int.MaxValue;
        if (prevNeiCount > targetCount)
            return int.MaxValue;

        if (memo[currIndex, prevColor, prevNeiCount] != 0)
            return memo[currIndex, prevColor, prevNeiCount];

        // recursive case
        int currColor = 0;
        int currCost = 0;
        int currSum = int.MaxValue;
        if (houses[currIndex] != 0) // already painted
        {
            currColor = houses[currIndex];
            if (prevColor == currColor)
                currSum = MinCostR(currIndex + 1, currColor, prevNeiCount, memo);
            else
                currSum = MinCostR(currIndex + 1, currColor, prevNeiCount + 1, memo);
        }
        else // not painted yet
        {
            int[] costPerColor = cost[currIndex];
            for (int j = 0; j < n; j++)
            {
                currColor = j + 1;
                currCost = costPerColor[j];
                int nextSum = 0;
                if (prevColor == currColor)
                    nextSum = MinCostR(currIndex + 1, currColor, prevNeiCount, memo);
                else
                    nextSum = MinCostR(currIndex + 1, currColor, prevNeiCount + 1, memo);
                if (nextSum == int.MaxValue)
                    continue;
                currSum = Math.Min(currSum, currCost + nextSum);
            }
        }

        memo[currIndex, prevColor, prevNeiCount] = currSum;
        return currSum;
    }
}

var s = new Solution();
var houses = new int[] { 0, 0, 0, 0, 0 };
var cost = new int[][] { new int[] { 1, 10 }, new int[] { 10, 1 }, new int[] { 10, 1 }, new int[] { 1, 10 }, new int[] { 5, 1 } };
var m = 5;
var n = 2;
var target = 3;
var result = s.MinCost1(houses, cost, m, n, target);
Console.WriteLine(result);


