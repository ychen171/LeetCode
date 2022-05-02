
// Definition for a Node.
public class Node
{
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next)
    {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}


public class Solution
{
    // Time: O(n)
    // Space: O(1)
    public Node Connect(Node root)
    {
        if (root == null) return null;

        Node leftMost = root;
        Node curr = root;

        while (leftMost.left != null)
        {
            curr = leftMost;
            while (curr != null)
            {
                curr.left.next = curr.right;

                if (curr.next != null)
                    curr.right.next = curr.next.left;

                curr = curr.next;
            }

            leftMost = leftMost.left;
        }

        return root;
    }
}
