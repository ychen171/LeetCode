public class Solution
{
    // DFS
    // Time: O(n)
    // Space: O(n)
    public bool CanReach(int[] arr, int start)
    {
        int n = arr.Length;
        var seen = new HashSet<int>();
        return DFS(arr, start, seen);
    }

    public bool DFS(int[] arr, int index, HashSet<int> seen)
    {
        // base case
        int n = arr.Length;
        if (index < 0 || index >= n)
            return false;
        if (arr[index] == 0)
            return true;

        if (seen.Contains(index))
            return false;

        seen.Add(index);
        // recursive case
        int len = arr[index];
        return DFS(arr, index - len, seen) || DFS(arr, index + len, seen);
    }

    // BFS
    // Time: O(n)
    // Space: O(n)
    public bool CanReach1(int[] arr, int start)
    {
        int n = arr.Length;
        int[] directions = new int[] { 1, -1 };
        var queue = new Queue<int>();
        int index = start;
        queue.Enqueue(index);
        var seen = new HashSet<int>();
        seen.Add(index);
        while (queue.Count != 0)
        {
            index = queue.Dequeue();
            if (arr[index] == 0)
                return true;
            int len = arr[index];
            foreach (int dir in directions)
            {
                int neiIndex = index + dir * len;
                if (neiIndex < 0 || neiIndex >= n) // invalid
                    continue;
                if (seen.Contains(neiIndex)) // visited
                    continue;
                queue.Enqueue(neiIndex);
                seen.Add(neiIndex);
            }
        }

        return false;
    }
}
