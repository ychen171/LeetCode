public class Solution
{
    // Priority Queue
    // Time: O(M)
    // Space: O(1)
    // M is the total number of tasks
    public int LeastInterval(char[] tasks, int n)
    {
        // create task count dictionary
        var taskCountDict = new Dictionary<char, int>();
        foreach (char task in tasks)
        {
            taskCountDict[task] = taskCountDict.GetValueOrDefault(task, 0) + 1;
        }
        // add all tasks to PriorityQueue (comparator == count)
        var pq = new PriorityQueue<KeyValuePair<char, int>, int>();
        foreach (var kv in taskCountDict)
        {
            var count = kv.Value;
            pq.Enqueue(kv, -count);
        }
        // keep poping task from pq till the num of tasks == n
        int result = 0;
        while (pq.Count != 0)
        {
            int interval = n + 1;
            var finishedTaskList = new List<KeyValuePair<char, int>>();
            while (interval > 0 && pq.Count != 0)
            {
                var kv = pq.Dequeue();
                finishedTaskList.Add(kv);
                interval--;
                result++;
            }
            // update task count pair and add valid pairs back to pq
            foreach (var kv in finishedTaskList)
            {
                int count = kv.Value;
                if (count != 1)
                {
                    var newCount = count - 1;
                    var newKv = new KeyValuePair<char, int>(kv.Key, newCount); // count >= 1
                    pq.Enqueue(newKv, -newCount);
                }
            }
            if (pq.Count != 0) // there are still tasks left for next interval
                result += interval; // if interval > 0, it means we need to idle for current interval
        }

        return result;
    }
}
