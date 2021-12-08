
public class Node
{
    public int val;
    public Node next;
    public Node random;

    public Node(int _val)
    {
        val = _val;
        next = null;
        random = null;
    }
}


public class Solution
{
    // Dictionary holds old nodes as keys and new nodes as values
    Dictionary<Node, Node> visitedDict = new Dictionary<Node, Node>();
    // Recursive
    // Time: O(n)
    // Space: O(n)
    public Node CopyRandomListRecursive(Node head)
    {
        if (head == null) return null;
        // if the current node has already been processed, returns the new node
        if (visitedDict.ContainsKey(head))
            return visitedDict[head];
        
        var newNode = new Node(head.val);
        visitedDict[head] = newNode;
        newNode.next = CopyRandomListRecursive(head.next);
        newNode.random = CopyRandomListRecursive(head.random);

        return newNode;
    }
    // Iterative
    // Time: O(n)
    // Space: O(n)
    public Node CopyRandomListIterative(Node head)
    {
        if (head == null) return null;
        var oldNode = head;
        var newNode = new Node(oldNode.val);
        visitedDict[oldNode] = newNode;
        while (oldNode != null)
        {
            // get the clones of the nodes referenced by random and next pointers
            newNode.random = GetClonedNode(oldNode.random);
            newNode.next = GetClonedNode(oldNode.next);
            // move forward in the linked list
            oldNode = oldNode.next;
            newNode = newNode.next;
        }
        // return new head node
        return visitedDict[head];
    }
    private Node GetClonedNode(Node node)
    {
        if (node == null) return null;
        if (visitedDict.ContainsKey(node)) 
            return visitedDict[node];
        else
        {
            var newNode = new Node(node.val);
            visitedDict[node] = newNode;
            return newNode;
        }
    }
}







