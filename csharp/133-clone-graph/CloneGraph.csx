
// Definition for a Node.
public class Node
{
    public int val;
    public IList<Node> neighbors;

    public Node()
    {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val)
    {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }
}

public class Solution
{
    // DFS | Copy as we go
    // Time: O(V + E)
    // Space: O(V)
    public Node CloneGraph(Node node)
    {
        // Dictionary<visted node, clone node>
        // Traverse original nodes, copy as we go
        // base case: it reaches a deadend or cycle, stop and return the clone node
        // recursive case: create the clone node and add to the visited dict
        // foreach neighbor, do the recursive call, build the neigbor list for the clone node
        // When everything is done, pass the clone node back to parent
        var visited = new Dictionary<Node, Node>();
        return DFS(node, visited);
    }

    // input: node
    // populate clone node
    // output: clone node
    private Node DFS(Node node, Dictionary<Node, Node> visited)
    {
        // base case
        if (node == null)
            return null;
        if (visited.ContainsKey(node))
            return visited[node];
        // recursive case
        // initialize clone node at current level
        // add node at current level to the visited dict
        // populate clone node at current level using the answer at children level
        var cloneNode = new Node(node.val, new List<Node>());
        visited.Add(node, cloneNode);
        foreach (Node nei in node.neighbors)
        {
            cloneNode.neighbors.Add(DFS(nei, visited));
        }

        return cloneNode;
    }

    // BFS
    // Time: O(V + E)
    // Space: O(V)
    public Node CloneGraph1(Node node)
    {
        if (node == null) return null;
        var queue = new Queue<Node>();
        var visited = new Dictionary<Node, Node>();
        Node currNode = node;
        queue.Enqueue(currNode);
        visited.Add(currNode, new Node(currNode.val, new List<Node>()));

        while (queue.Count != 0)
        {
            currNode = queue.Dequeue();
            foreach (Node nei in currNode.neighbors)
            {
                if (!visited.ContainsKey(nei))
                {
                    visited.Add(nei, new Node(nei.val, new List<Node>()));
                    queue.Enqueue(nei);
                }
                visited[currNode].neighbors.Add(visited[nei]);
            }
        }

        return visited[node];
    }
}
