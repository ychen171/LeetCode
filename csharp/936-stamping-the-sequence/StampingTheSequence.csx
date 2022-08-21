public class Solution
{
    // Work Backward
    // Time: O(n*(n-m))
    // Space: O(n*(n-m))
    public int[] MovesToStamp(string stamp, string target)
    {
        int m = stamp.Length;
        int n = target.Length;
        var queue = new Queue<int>();
        var done = new bool[n];
        var stack = new Stack<int>();
        var list = new List<HashSet<int>[]>();

        for (int i = 0; i <= n - m; i++)
        {
            // for window [i, i+m), 
            // list will contain info on what needs to change before
            // we can reverse stamp at this window
            var made = new HashSet<int>();
            var todo = new HashSet<int>();
            for (int k = 0; k < m; k++)
            {
                if (target[i + k] == stamp[k])
                    made.Add(i + k);
                else
                    todo.Add(i + k);
            }
            list.Add(new HashSet<int>[] { made, todo });

            // if we can reverse stamp at i immediately, 
            // enqueue letters from this window
            if (todo.Count == 0)
            {
                stack.Push(i);
                for (int j = i; j < i + m; j++)
                {
                    if (!done[j])
                    {
                        queue.Enqueue(j);
                        done[j] = true;
                    }
                }
            }
        }

        while (queue.Count != 0)
        {
            int i = queue.Dequeue();
            // for each window that is potentially affected, 
            // j: start of window
            for (int j = Math.Max(0, i - m + 1); j <= Math.Min(n - m, i); j++)
            {
                var made = list[j][0];
                var todo = list[j][1];
                if (todo.Contains(i))
                {
                    todo.Remove(i);
                    if (todo.Count == 0)
                    {
                        stack.Push(j);
                        foreach (var index in made)
                        {
                            if (!done[index])
                            {
                                queue.Enqueue(index);
                                done[index] = true;
                            }
                        }
                    }
                }
            }
        }

        foreach (var item in done)
        {
            if (!item)
                return new int[0];
        }

        var result = new int[stack.Count];
        int t = 0;
        while (stack.Count != 0)
        {
            result[t++] = stack.Pop();
        }

        return result;
    }
}
