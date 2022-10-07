
// Definition for a Node.
public class Node
{
    public int val;
    public IList<Node> children;

    public Node()
    {
        val = 0;
        children = new List<Node>();
    }

    public Node(int _val)
    {
        val = _val;
        children = new List<Node>();
    }

    public Node(int _val, List<Node> _children)
    {
        val = _val;
        children = _children;
    }
}


public class Solution
{
    // DFS Recursion | Distance with Height
    // Time: O(n)
    // Space: O(n)
    int result;
    public int Diameter(Node root)
    {
        result = 0;
        if (root == null)
            return result;
        DFS(root);
        return result;
    }

    // return the max distance from curr node
    public int DFS(Node curr)
    {
        // base case: 
        // if it is leaf node, distance is 0; 
        // or if it is null node, distance is -1
        if (curr == null)
            return -1;
        // recursive case
        // topDist1 >= topDist2
        int topDist1 = 0, topDist2 = 0;
        foreach (var child in curr.children)
        {
            int dist = 1 + DFS(child);
            if (dist > topDist1)
            {
                topDist2 = topDist1;
                topDist1 = dist;
            }
            else if (dist > topDist2)
            {
                topDist2 = dist;
            }
        }
        result = Math.Max(result, topDist1 + topDist2);
        return topDist1;
    }
}
