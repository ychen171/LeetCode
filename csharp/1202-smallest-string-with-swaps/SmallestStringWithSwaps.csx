public class Solution
{
    // Brute force | BAD!!!
    // Time: O(k log k)
    // n = s.Length, k = pairs.Count
    // Space: O(n + k)
    public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
    {
        //          d c a b          [0,3],[1,2]
        //  [0,3]   b c a d
        //  [1,2]   b a c d
        
        //          d c a b         [0,3],[1,2],[0,2]
        //  [0,3]   b c a d
        //  [0,2]   a c b d
        //  [1,2]   a b c d
        var orderdPairs = pairs.OrderBy((x) => x[0]);
        char[] cs = s.ToCharArray();
        bool flag = true;
        while (flag)
        {
            flag = false;
            foreach (List<int> pair in orderdPairs)
            {
                int left = pair[0];
                int right = pair[1];
                if (cs[left] > cs[right])
                {
                    Swap(cs, left, right);
                    flag = true;
                }
            }
        }

        return new string(cs);
    }

    private void Swap(char[] s, int left, int right)
    {
        char temp = s[left];
        s[left] = s[right];
        s[right] = temp;
    }

    // Graph | DFS | Recursion
    // Time: O(E + V log V)
    // Space: O(V + E)
    public string SmallestStringWithSwaps1(string s, IList<IList<int>> pairs)
    {
        int n = s.Length;
        // 1. Build the graph / adjacency list
        var graph = new List<List<int>>();
        for (int i = 0; i < s.Length; i++)
            graph.Add(new List<int>());

        foreach (List<int> edge in pairs)
        {
            int src = edge[0];
            int dst = edge[1];
            // undirected unweighed edge
            graph[src].Add(dst);
            graph[dst].Add(src);
        }

        // 2. iterate through vertices in graph and perform DFS
        bool[] visited = new bool[n];
        char[] ans = new char[s.Length];
        for (int vertex = 0; vertex < s.Length; vertex++)
        {
            var chars = new List<char>();
            var indices = new List<int>();
            DFS(s, graph, visited, vertex, chars, indices);
            
            // do something 

            // a. sort the array of characters and indices
            chars.Sort();
            indices.Sort();

            // b. store the sorted characters corresponding to the index
            for (int k = 0; k < chars.Count; k++)
                ans[indices[k]] = chars[k];
        }

        return new string(ans);
    }

    private void DFS(string s, List<List<int>> graph, bool[] visited, int vertex, List<char> chars, List<int> indices)
    {
        // base case
        if (visited[vertex])
            return;
        // recursive case
        // add the character and index to the list
        chars.Add(s[vertex]);
        indices.Add(vertex);
        // set to visited
        visited[vertex] = true;

        // traverse the adjacents
        foreach (int neiVertex in graph[vertex])
        {
            DFS(s, graph, visited, neiVertex, chars, indices);
        }
    }

    // Union Find
    // Time: O(E + V + V log V)
    // Space: O(V)
    public string SmallestStringWithSwaps2(string s, IList<IList<int>> pairs)
    {
        int n = s.Length;
        // 1. find all edegs (unweighed) (already provided by pairs)
        // 2. iterate through edges (direction doesn't matter) and perform union find to build Union graph
        var uf = new UnionFind(n);
        foreach (var edge in pairs)
        {
            var src = edge[0];
            var dst = edge[1];
            uf.Union(src, dst);
        }

        // do something

        // a. convert Union Graph into dictionary
        var groupDict = new Dictionary<int, List<int>>();
        for (int vertex = 0; vertex < n; vertex++)
        {
            int group = uf.Find(vertex);
            if (!groupDict.ContainsKey(group))
                groupDict[group] = new List<int>();
            groupDict[group].Add(vertex);
        }

        char[] ans = new char[n];
        // b. iterate through groups/unions
        foreach (List<int> indices in groupDict.Values)
        {
            // iterate through indices in each group
            // c. find the chars and sort
            var chars = new List<char>();
            foreach (int index in indices)
                chars.Add(s[index]);
            
            chars.Sort();
            // d. store the sorted chars
            for (int k = 0; k < indices.Count; k++)
                ans[indices[k]] = chars[k];
        }

        return new string(ans);
    }
}


public class UnionFind
{
    int[] group;
    int[] rank;
    public UnionFind(int size)
    {
        group = new int[size];
        rank = new int[size];
        for (int i = 0; i < size; i++)
            group[i] = i;
    }

    public int Find(int vertex)
    {
        // cycle detection
        if (group[vertex] != vertex)
        {
            group[vertex] = Find(group[vertex]);
        }

        return group[vertex];
    }

    public bool Union(int vertex1, int vertex2)
    {
        int group1 = Find(vertex1);
        int group2 = Find(vertex2);

        if (group1 == group2)
            return false;
        
        if (rank[group1] > rank[group2])
        {
            group[group2] = group1;
        }
        else if (rank[group1] < rank[group2])
        {
            group[group1] = group2;
        }
        else
        {
            group[group1] = group2;
            rank[group2] ++;
        }

        return true;
    }
}