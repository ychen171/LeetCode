public class Solution
{
    public int[] AssignTasks(int[] servers, int[] tasks)
    {
        int n = servers.Length;
        int m = tasks.Length;
        // 1. [weight, index, availTime]
        // freeServerQ: sort by weight, then index
        // usedServerQ: sort by availTime, then weight, then index
        var freeServerQ = new PriorityQueue<int[], int[]>(Comparer<int[]>.Create((a, b) => a[0] == b[0] ? a[1] - b[1] : a[0] - b[0]));
        var usedServerQ = new PriorityQueue<int[], int[]>(Comparer<int[]>.Create((a, b) => a[2] == b[2] ? a[0] == b[0] ? a[1] - b[1] : a[0] - b[0] : a[2] - b[2]));
        // 2. add servers into freeServerQ
        for (int i = 0; i < n; i++)
        {
            var item = new int[]{servers[i], i, 0};
            freeServerQ.Enqueue(item, item);
        }
        // 3. iterate through tasks and assign server
        int[] result = new int[m];
        for (int k = 0; k < m; k++)
        {
            var task = tasks[k];
            while (usedServerQ.Count != 0 && usedServerQ.Peek()[2] <= k)
            {
                var curr = usedServerQ.Dequeue();
                freeServerQ.Enqueue(curr, curr);
            }
            if (freeServerQ.Count == 0)
            {
                var curr = usedServerQ.Dequeue();
                result[k] = curr[1];
                curr[2] += task;
                usedServerQ.Enqueue(curr, curr);
            }
            else 
            {
                var curr = freeServerQ.Dequeue();
                result[k] = curr[1];
                curr[2] = k + task;
                usedServerQ.Enqueue(curr, curr);
            }
        }
        return result;
    }
}
// Priority Queue
// Time: O(n log n + m log n)
// Space: O(n)
