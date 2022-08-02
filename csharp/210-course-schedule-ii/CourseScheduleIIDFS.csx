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
            if (!CanFinish(prereqDict, cycleSet, visitSet, i, result))
                return new int[] { };
        }

        return result.ToArray();
    }

    // return whether or not the course can be finished
    private bool CanFinish(Dictionary<int, List<int>> prereqDict, HashSet<int> onPath, HashSet<int> visited, int course, List<int> result)
    {
        // base case
        if (onPath.Contains(course)) // found cycle
            return false;
        if (visited.Contains(course)) // it is finished
            return true;

        // a course has 3 possible states:
        // visited -> course has been added to the result list
        // visiting -> course has not been added to the result list, but added to onPath set
        // univisited -> course has not been added to the result list or onPath set

        onPath.Add(course);
        if (prereqDict.ContainsKey(course))
        {
            foreach (var pre in prereqDict[course])
            {
                if (!CanFinish(prereqDict, onPath, visited, pre, result))
                    return false;
            }
        }
        onPath.Remove(course);
        visited.Add(course);
        result.Add(course);
        return true;
    }
}
