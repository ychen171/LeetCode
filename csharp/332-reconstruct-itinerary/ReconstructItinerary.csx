public class Solution
{
    // Graph | DFS | Bottom-up | Postorder
    // Time: O(E log (E/V)) in average, O(E log E) in worst
    // Space: O(V + E)
    public IList<string> FindItinerary(IList<IList<string>> tickets)
    {
        // construct graph from tickets list: departure -> destinations in ascending order
        var graph = ConstructGraph(tickets);
        // DFS, begin with JFK
        string airport = "JFK";
        var result = new List<string>{airport};
        var stack = new Stack<string>();
        DFS(graph, airport, stack);
        while (stack.Count != 0)
            result.Add(stack.Pop());
        return result;
    }

    // Time: O(E log (E/V)) in average, O(E log E) in worst
    // Space: O(V + E)
    private Dictionary<string, PriorityQueue<string, string>> ConstructGraph(IList<IList<string>> tickets)
    {
        var graph = new Dictionary<string, PriorityQueue<string, string>>();
        foreach (var ticket in tickets)
        {
            var from = ticket[0];
            var to = ticket[1];
            if (!graph.ContainsKey(from))
                graph[from] = new PriorityQueue<string, string>();
            graph[from].Enqueue(to, to);
        }

        return graph;
    }

    // Time: O(E)
    // Space: O(E)
    private void DFS(Dictionary<string, PriorityQueue<string, string>> graph, string airport, Stack<string> stack)
    {
        // base case
        if (!graph.ContainsKey(airport)) return;
        var pq = graph[airport];
        // recusive case
        while (pq.Count != 0)
        {
            var nextAirport = pq.Dequeue();
            DFS(graph, nextAirport, stack);
            stack.Push(nextAirport);
        }
    }
}
