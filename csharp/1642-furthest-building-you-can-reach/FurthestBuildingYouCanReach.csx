public class Solution
{
    // Priority Queue
    // Time: O(N log L)
    // Space: O(L)
    public int FurthestBuilding(int[] heights, int bricks, int ladders)
    {
        var ladderPQ = new PriorityQueue<int, int>(); // <ladder length, ladder length>
        int n = heights.Length;
        for (int i = 0; i < n - 1; i++)
        {
            var currHeight = heights[i];
            var nextHeight = heights[i + 1];
            if (currHeight >= nextHeight) // jump
                continue;

            var climb = nextHeight - currHeight;
            ladderPQ.Enqueue(climb, climb);
            if (ladderPQ.Count <= ladders) // has enough ladders
                continue;

            // run out of ladders
            var bricksNeeded = ladderPQ.Dequeue();
            if (bricksNeeded > bricks)
            {
                return i;
            }
            else
            {
                bricks -= bricksNeeded;
            }
        }

        return n - 1;
    }
}
