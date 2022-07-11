public class Solution
{
    // BFS
    // Time: O(n)
    // Space: O(n)
    public int MinJumps(int[] arr)
    {
        int n = arr.Length;
        if (n <= 1)
            return 0;

        var numToIndex = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; i++)
        {
            int num = arr[i];
            if (!numToIndex.ContainsKey(num))
                numToIndex[num] = new List<int>();
            numToIndex[num].Add(i);
        }

        var queue = new Queue<int>();
        var seen = new HashSet<int>();
        int index = n - 1;
        queue.Enqueue(index);
        seen.Add(index);

        int steps = 0;
        while (queue.Count != 0)
        {
            int levelLen = queue.Count;
            for (int i = 0; i < levelLen; i++)
            {
                index = queue.Dequeue();
                if (index == 0) // found target, return steps
                    return steps;

                int num = arr[index];
                if (numToIndex.ContainsKey(num))
                {
                    foreach (var neiIndex in numToIndex[num])
                    {
                        if (seen.Contains(neiIndex))
                            continue;
                        queue.Enqueue(neiIndex);
                        seen.Add(neiIndex);
                    }
                }
                // clear the list to prevent redundant search in dict
                numToIndex.Remove(num);

                if (index - 1 >= 0 && !seen.Contains(index - 1))
                {
                    queue.Enqueue(index - 1);
                    seen.Add(index - 1);
                }
                if (index + 1 < n && !seen.Contains(index + 1))
                {
                    queue.Enqueue(index + 1);
                    seen.Add(index + 1);
                }

            }
            steps++;
        }

        return -1;
    }
}
