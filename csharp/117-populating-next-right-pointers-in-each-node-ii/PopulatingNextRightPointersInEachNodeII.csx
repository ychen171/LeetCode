
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
    // BFS
    // Time: O(n)
    // Space: O(n)
    public Node Connect(Node root)
    {
        if (root == null) return null;

        var queue = new Queue<Node>();
        Node curr = root;
        Node prev = null;
        queue.Enqueue(curr);

        while (queue.Count != 0)
        {
            int levelLen = queue.Count;
            for (int i = 0; i < levelLen; i++)
            {
                curr = queue.Dequeue();
                if (prev != null)
                    prev.next = curr;
                
                prev = curr;
                
                if (curr.left != null)
                    queue.Enqueue(curr.left);
                if (curr.right != null)
                    queue.Enqueue(curr.right);

            }
        }

        return root;
    }

    // using previously established next pointers
    // Time: O(n)
    // Space: O(1)
    public Node Connect1(Node root)
    {
        if (root == null) return null;

        Node leftMost = root;
        Node curr = root;

        while (leftMost != null)
        {
            curr = leftMost;
            leftMost = null;
            Node rightMostChild = null;

            while (curr != null)
            {
                // connect left child
                if (curr.left != null)
                {
                    if (rightMostChild != null)
                        rightMostChild.next = curr.left;
                    rightMostChild = curr.left;
                }

                // connect right child
                if (curr.right != null)
                {
                    if (rightMostChild != null)
                        rightMostChild.next = curr.right;
                    rightMostChild = curr.right;
                }

                // find leftMost for the next level
                if (leftMost == null)
                    leftMost = curr.left ?? curr.right;
                
                curr = curr.next;
            }
        }

        return root;
    }
}

