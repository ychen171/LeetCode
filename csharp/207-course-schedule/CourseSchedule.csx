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

    // DFS 
    // Time: O(V + E)
    // Space: O(V + E)
    public bool CanFinish1(int numCourses, int[][] prerequisites)
    {
        // build the graph
        var prereqDict = new Dictionary<int, List<int>>();
        foreach (var pair in prerequisites)
        {
            int curr = pair[0];
            int prereq = pair[1];
            if (!prereqDict.ContainsKey(curr))
                prereqDict[curr] = new List<int>();
            prereqDict[curr].Add(prereq);
        }
        // DFS, starting from every node
        var visited = new HashSet<int>();
        for (int i = 0; i < numCourses; i++)
        {
            if (!DFS(prereqDict, visited, i))
                return false;
        }

        return true;
    }

    private bool DFS(Dictionary<int, List<int>> prereqDict, HashSet<int> visited, int course)
    {
        if (!prereqDict.ContainsKey(course)) // no prerequisites
            return true;
        if (visited.Contains(course)) // detect a cycle
            return false;
        
        visited.Add(course);
        foreach (var pre in prereqDict[course])
        {
            if (!DFS(prereqDict, visited, pre))
                return false;
        }
        prereqDict.Remove(course);
        return true;
    }
}
