public class Solution
{
    // Topological Sort | DFS
    // Time: O(V + E)
    // Space: O(V + E)
    public int[] FindOrder(int numCourses, int[][] prerequisites)
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
        // DFS, staring from each node
        var cycleSet = new HashSet<int>();
        var visitSet = new HashSet<int>();
        var result = new List<int>();
        for (int i = 0; i < numCourses; i++)
        {
            if (!DFS(prereqDict, cycleSet, visitSet, i, result))
                return new int[] { };
        }

        return result.ToArray();
    }

    private bool DFS(Dictionary<int, List<int>> prereqDict, HashSet<int> cycleSet, HashSet<int> visitSet, int course, List<int> result)
    {
        // base case
        if (cycleSet.Contains(course))
            return false;
        if (visitSet.Contains(course))
            return true;

        // a course has 3 possible states:
        // visited -> course has been added to the result list
        // visiting -> course has not been added to the result list, but added to cycle set
        // univisited -> course has not been added to the result list or cycle set

        cycleSet.Add(course);
        if (prereqDict.ContainsKey(course))
        {
            foreach (var pre in prereqDict[course])
            {
                if (!DFS(prereqDict, cycleSet, visitSet, pre, result))
                    return false;
            }
        }
        cycleSet.Remove(course);
        visitSet.Add(course);
        result.Add(course);
        return true;
    }
}
