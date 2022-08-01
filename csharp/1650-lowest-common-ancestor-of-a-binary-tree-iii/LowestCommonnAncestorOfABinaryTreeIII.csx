
public class Node
{
    public int val;
    public Node left;
    public Node right;
    public Node parent;
}


public class Solution
{
    // Time: O(h)
    // Space: O(1)
    public Node LowestCommonAncestor(Node p, Node q)
    {
        Node a = p;
        Node b = q;

        while (a != b)
        {
            a = a == null ? q : a.parent;
            b = b == null ? p : b.parent;
        }

        return a;
    }
}
