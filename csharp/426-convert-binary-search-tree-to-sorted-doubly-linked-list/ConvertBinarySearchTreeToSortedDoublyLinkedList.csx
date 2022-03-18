
public class Node
{
    public int val;
    public Node left;
    public Node right;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
        left = null;
        right = null;
    }

    public Node(int _val, Node _left, Node _right)
    {
        val = _val;
        left = _left;
        right = _right;
    }
}


public class Solution
{
    // DFS Inorder
    // Time: O(n)
    // Space: O(n)
    public Node TreeToDoublyList(Node root)
    {
        if (root == null) return null;
        var stack = new Stack<Node>();
        var dummy = new Node();
        Node prev = dummy;
        Node curr = root;
        while (curr != null || stack.Count != 0)
        {
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.left;
            }
            curr = stack.Pop();
            curr.left = prev;
            prev.right = curr;
            prev = curr;
            curr = curr.right;
        }
        var firstNode = dummy.right;
        var lastNode = prev;
        firstNode.left = lastNode;
        lastNode.right = firstNode;
        return firstNode;
    }
}

var node1 = new Node(1);
var node2 = new Node(2);
var node3 = new Node(3);
var node4 = new Node(4);
var node5 = new Node(5);
node4.left = node2;
node4.right = node5;
node2.left = node1;
node2.right = node3;

var s = new Solution();
var firstNode = s.TreeToDoublyList(node4);
Console.WriteLine(firstNode.val);
