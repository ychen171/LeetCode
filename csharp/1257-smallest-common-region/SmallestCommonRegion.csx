public class Solution
{
    // Graph + LCA | DFS
    // Time: O(V + E)
    // Space: O(V + E)
    Dictionary<string, HashSet<string>> graph;
    Dictionary<string, int> indegree;
    public string FindSmallestRegion(IList<IList<string>> regions, string region1, string region2)
    {
        // given n-ary tree, two nodes, find LCA
        // build graph using adjacency list
        // build indegreeMap
        graph = new Dictionary<string, HashSet<string>>();
        indegree = new Dictionary<string, int>();
        foreach (var list in regions)
        {
            var parent = list[0];
            if (!graph.ContainsKey(parent))
            {
                graph[parent] = new HashSet<string>();
                indegree[parent] = 0;
            }
            for (int i = 1; i < list.Count; i++)
            {
                var child = list[i];
                graph[parent].Add(child);
                indegree[child] = indegree.GetValueOrDefault(child, 0) + 1;
            }
        }
        // DFS
        foreach (var root in indegree.Keys)
        {
            if (indegree[root] == 0)
                return LCA(root, region1, region2);
        }
        return null;
    }

    public string LCA(string root, string p, string q)
    {
        // base case
        if (root == null)
            return null;
        if (root == p || root == q)
            return root;
        if (!graph.ContainsKey(root))
            return null;
        // recursive case
        string result = null;
        int count = 0;
        foreach (var child in graph[root])
        {
            var sub = LCA(child, p, q);
            if (sub != null)
            {
                count++;
                result = sub;
            }
            if (count == 2)
                return root;
        }

        return result;
    }
}

/*
regions = [["Earth","North America","South America"],
["North America","United States","Canada"],
["United States","New York","Boston"],
["Canada","Ontario","Quebec"],
["South America","Brazil"]],
region1 = "Quebec",
region2 = "New York"
Output: "North America"
*/

var sln = new Solution();
var regions = new List<IList<string>>()
{
    new List<string>{"Earth","North America","South America"},
    new List<string>{"North America","United States","Canada"},
    new List<string>{"United States","New York","Boston"},
    new List<string>{"Canada","Ontario","Quebec"},
    new List<string>{"South America","Brazil"},
};
var region1 = "Quebec";
var region2 = "New York";
var result = sln.FindSmallestRegion(regions, region1, region2);
Console.WriteLine(result);
