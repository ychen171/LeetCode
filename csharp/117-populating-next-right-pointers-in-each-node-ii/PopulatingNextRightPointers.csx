
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
    // BFS using Queue
    // Time: O(N)
    // Space: O(N)
    public Node Connect(Node root)
    {
        if (root == null) return null;
        var queue = new Queue<Node>();
        Node prev = null;
        Node curr = null;
        queue.Enqueue(root);
        int levelLength = 1;
        while (queue.Count != 0)
        {
            // go through nodes at the same level
            levelLength = queue.Count;
            for (int i=0; i<levelLength; i++)
            {
                prev = curr;
                curr = queue.Dequeue();
                // point prev to the next right node
                if (prev != null) prev.next = curr;
                // push the nodes of next level into queue
                if (curr.left != null) queue.Enqueue(curr.left);
                if (curr.right != null) queue.Enqueue(curr.right);
            }
            // reach the end of the current level
            curr = null;
        }
        return root;
    }

    // using previously established next pointers (two loops and two pointers) 
    // Time: O(N)
    // Space: O(1)
    public Node Connect2(Node root)
    {
        if (root == null) return null;
        Node leftMost = root;
        // reach the leaf level, stop the loop
        while (leftMost != null)
        {
            Node rightMostChild = null;
            Node curr = leftMost;
            leftMost = null;

            while (curr != null)
            {
                // build connections at the child level
                // process left child
                if (curr.left != null)
                {
                    if (rightMostChild != null)
                        rightMostChild.next = curr.left;
                    rightMostChild = curr.left;
                }
                // process right child
                if (curr.right != null)
                {
                    if (rightMostChild != null)
                        rightMostChild.next = curr.right;
                    rightMostChild = curr.right;
                }
                // find leftMost at child level
                if (leftMost == null)
                    leftMost = curr.left ?? curr.right;
                // move right at the same level
                curr = curr.next;
            }
        }
        return root;
    }
}








