public class Solution
{
    // BFS | Topological Sort
    // Time: O(V + E)
    // Space: O(V + E)
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        // [[1,0]]
        // 0 ---> 1     acyclic

        // [[1,0],[0,1]]
        // 0 ---> 1
        //   <---         cyclic

        // build graph and incoming edge count for each node
        var graph = new Dictionary<int, List<int>>();
        var incomingCount = new Dictionary<int, int>();
        foreach (var pair in prerequisites)
        {
            var des = pair[0];
            var src = pair[1];
            if (!graph.ContainsKey(src))
                graph[src] = new List<int>();
            graph[src].Add(des);

            incomingCount[des] = incomingCount.GetValueOrDefault(des, 0) + 1;
        }

        // add all entry nodes into queue
        var queue = new Queue<int>();
        for (int i = 0; i < numCourses; i++)
        {
            if (incomingCount.ContainsKey(i))
                continue;
            queue.Enqueue(i);
        }

        // BFS to traverse all nodes and add to list/ count
        int finishedCount = 0;
        while (queue.Count != 0)
        {
            var curr = queue.Dequeue();
            finishedCount++;
            if (!graph.ContainsKey(curr)) // curr is not a prerequisite
                continue;
            foreach (int nei in graph[curr])
            {
                incomingCount[nei]--; // curr is finished, decrease the incoming count for nei
                if (incomingCount[nei] == 0) // all prerequisites are finished
                {
                    queue.Enqueue(nei);
                }
            }
        }

        return finishedCount == numCourses;
    }
}
