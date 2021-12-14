
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
        int levelLength = 1;
        queue.Enqueue(root);
        while (queue.Count != 0)
        {
            // go through the node at the same level
            for (int i = 0; i < levelLength; i++)
            {
                prev = curr;
                curr = queue.Dequeue();
                // point prev to the next right node
                if (prev != null) prev.next = curr;
                // push the nodes of next level into the queue
                if (curr.left != null) queue.Enqueue(curr.left);
                if (curr.right != null) queue.Enqueue(curr.right);
            }
            // reach the end of the level
            curr = null;
            levelLength *= 2;
        }
        return root;
    }

    // Using previously established next pointers
    // Time: O(N)
    // Space: O(N)
    public Node Connect2(Node root)
    {
        if (root == null) return null;
        var leftMost = root;
        // if leftMost reaches the final level, stop the loop
        while (leftMost.left != null)
        {
            var head = leftMost;
            while (head != null)
            {
                // connection 1
                head.left.next = head.right;
                // connection 2
                if (head.next != null)
                    head.right.next = head.next.left;
                // move to right at the same level
                head = head.next;
            }
            // move down one level
            leftMost = leftMost.left;
        }
        return root;
    }
}








