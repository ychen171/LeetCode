public class Solution
{
    // DFS
    // Time: O(M * N)
    // M = the number of queries
    // N = the number of equations
    // Space: O(N)
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        // 1. build the graph with weighted edges
        var graph = new Dictionary<string, Dictionary<string, double>>();
        for (int i = 0; i < equations.Count; i++)
        {
            var equation = equations[i];
            string dividend = equation[0];
            string divisor = equation[1];
            double quotient = values[i];

            if (!graph.ContainsKey(dividend))
                graph[dividend] = new Dictionary<string, double>();
            if (!graph.ContainsKey(divisor))
                graph[divisor] = new Dictionary<string, double>();
            
            graph[dividend][divisor] = quotient;
            graph[divisor][dividend] = 1 / quotient;
        }

        // 2. evaluate each query via DFS
        int n = queries.Count;
        var ans = new double[n];
        for (int i = 0; i < n; i++)
        {
            string curr = queries[i][0];
            string target = queries[i][1];        
            ans[i] = DFS(graph, target, curr, 1, new HashSet<string>());
        }

        return ans;
    }

    private double DFS(Dictionary<string, Dictionary<string, double>> graph, string targetNode, string currNode, double currProduct, HashSet<string> visited)
    {
        // base case
        if (!graph.ContainsKey(currNode))
            return -1;
        if (currNode == targetNode)
            return currProduct;
        if (visited.Count == graph.Keys.Count)
            return -1;
        
        // recursive case
        double result = -1;
        if (visited.Add(currNode))
        {
            Dictionary<string, double> neighbors = graph[currNode];
            foreach (var nei in neighbors)
            {
                string neiNode = nei.Key;
                double neiWeight = nei.Value;
                result = DFS(graph, targetNode, neiNode, currProduct * neiWeight, visited);
                if (result != -1) // found the path, return result
                    break;
            }
        }

        return result;
    }
}
