public class Solution
{
    // DFS + Dictionary + HashSet
    // Time: O(N * K * log (N*K))
    // Time: O(N*K)
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
    {
        // build graph, only create edge between first email and the rest emails
        // STAR graph, don't need the full graph
        var graph = new Dictionary<string, HashSet<string>>();
        foreach (List<string> accountInfo in accounts)
        {
            string name = accountInfo[0];
            string firstEmail = accountInfo[1];
            if (!graph.ContainsKey(firstEmail))
                graph[firstEmail] = new HashSet<string>();
            
            for (int i = 2; i < accountInfo.Count; i++)
            {
                string otherEmail = accountInfo[i];
                if (!graph.ContainsKey(otherEmail))
                    graph[otherEmail] = new HashSet<string>();

                graph[firstEmail].Add(otherEmail);
                graph[otherEmail].Add(firstEmail);
            }
        }

        // itrate through accounts
        // foreach account, do DFS on the first email if it is not visited
        // add sorted emails to result
        var visited = new HashSet<string>();
        var result = new List<IList<string>>();
        foreach (List<string> accountInfo in accounts)
        {
            string name = accountInfo[0];
            string firstEmail = accountInfo[1];
            if (visited.Contains(firstEmail))
                continue;
            
            var currEmailSet = new HashSet<string>();
            DFS(graph, visited, name, firstEmail, currEmailSet);
            var emailList = currEmailSet.ToList();
            emailList.Sort(StringComparer.Ordinal);

            var mergedList = new List<string>();
            mergedList.Add(name);
            mergedList.AddRange(emailList);

            result.Add(mergedList);
        }
        
        return result;
    }

    private void DFS(Dictionary<string, HashSet<string>> graph, HashSet<string> visited, string name, string email, HashSet<string> currEmailSet)
    {
        // base case
        if (visited.Contains(email))
            return;

        visited.Add(email);
        currEmailSet.Add(email);
        
        if (!graph.ContainsKey(email))
            return;
        // recursive case
        foreach (var neiEmail in graph[email])
        {
            DFS(graph, visited, name, neiEmail, currEmailSet);
        }
    }
}
