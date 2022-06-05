
// Definition for a Node.
public class Node
{
    public int val;
    public IList<Node> children;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, IList<Node> _children)
    {
        val = _val;
        children = _children;
    }
}


public class Solution
{
    // Bottom-up | Recursion
    // Time: O(n)
    // Space: O(h), n in worst, log n in best
    public int MaxDepth(Node root)
    {
        // base case
        if (root == null)
            return 0;
        
        // recursive case
        int ans = 0;
        foreach (var child in root.children)
        {
            ans = Math.Max(ans, MaxDepth(child));
        }

        return ans + 1;
    }
}

