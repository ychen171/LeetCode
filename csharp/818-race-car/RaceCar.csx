public class Solution
{
    // BFS
    // Time: O(2^h)
    // Space: O(2^h)
    public int Racecar(int target)
    {
        var queue = new Queue<int[]>(); // [position, speed]
        var curr = new int[] { 0, 1 };
        queue.Enqueue(curr);
        var visited = new HashSet<string>();
        visited.Add("0,1"); // "position,speed"
        int level = 0;
        while (queue.Count != 0)
        {
            int levelLength = queue.Count;
            for (int i = 0; i < levelLength; i++)
            {
                curr = queue.Dequeue();
                int pos = curr[0];
                int spd = curr[1];
                if (pos == target) // reach the target
                    return level;

                // accelerate
                int nextPos = pos + spd;
                int nextSpd = spd * 2;
                string key = $"{nextPos},{nextSpd}";
                // valid and unvisited
                if (nextPos > 0 && nextPos < target * 2 && !visited.Contains(key))
                {
                    queue.Enqueue(new int[] { nextPos, nextSpd });
                    visited.Add(key);
                }

                // reverse
                nextPos = pos;
                nextSpd = spd > 0 ? -1 : 1;
                key = $"{nextPos},{nextSpd}";
                // valid and unvisited
                if (nextPos > 0 || nextPos < target * 2 && !visited.Contains(key))
                {
                    queue.Enqueue(new int[] { nextPos, nextSpd });
                    visited.Add(key);
                }
            }
            level++;
        }

        return -1;
    }
}
