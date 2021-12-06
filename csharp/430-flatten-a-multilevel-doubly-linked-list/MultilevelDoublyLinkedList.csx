
public class Node
{
    public int val;
    public Node prev;
    public Node next;
    public Node child;
    public Node() { }
    public Node(int val)
    {
        this.val = val;
    }
}


public class Solution
{
    // DFS Preorder Recursive
    // Time: O(n)
    // Space: O(n)
    public Node FlattenRecursive(Node head)
    {
        if (head == null) return head;
        Node dummy = new Node();
        // connect dummy head with the real head
        dummy.next = head;
        // recursive function
        FlattenDFS(dummy, dummy.next);

        // detach the dummy head from the real head
        dummy.next.prev = null;
        return dummy.next;
    }
    private Node FlattenDFS(Node prev, Node curr)
    {
        if (curr == null) return prev; // base case
        // Preorder traversal
        prev.next = curr;
        curr.prev = prev;
        // keep curr.next for latter recursive call
        var tempNext = curr.next;
        // former recursive call
        var tail = FlattenDFS(curr, curr.child);
        curr.child = null; // tail == curr
        // latter recursive call
        return FlattenDFS(tail, tempNext);
    }

    // DFS Preorder Iterative
    // Time: O(n)
    // Space: O(n)
    public Node FlattenIterative1(Node head)
    {
        if (head == null) return null;
        var dummy = new Node();
        dummy.next = head;
        Node prev = dummy;
        Node curr = dummy.next;
        var stack = new Stack<Node>();

        while (curr != null || stack.Count > 0)
        {
            while (curr != null)
            {
                stack.Push(curr.next);
                prev.next = curr;
                curr.prev = prev;
                prev = curr;
                curr = curr.child;
                prev.child = null;
            }
            curr = stack.Pop();
        }
        // detach the dummy head from the real head
        dummy.next.prev = null;
        return dummy.next;
    }
    public Node FlattenIterative2(Node head)
    {
        if (head == null) return null;
        var dummy = new Node();
        dummy.next = head;
        Node prev = dummy;
        Node curr = dummy.next;
        var stack = new Stack<Node>();
        stack.Push(curr);
        // Preorder traversal
        while (stack.Count > 0)
        {
            curr = stack.Pop();
            // parent node, perform the operation
            prev.next = curr;
            curr.prev = prev;
            // push right node
            if (curr.next != null) stack.Push(curr.next);
            // push left node
            if (curr.child != null)
            {
                stack.Push(curr.child);
                curr.child = null; // clean up child
            }
            prev = curr;
        }
        // detach the dummy head from the real head
        dummy.next.prev = null;
        return dummy.next;
    }
}


var s = new Solution();
var node1 = new Node(1);
var node2 = new Node(2);
var node3 = new Node(3);
var node4 = new Node(4);
node1.next = node2;
node2.prev = node1;
node2.child = node3;
node2.next = node4;
node4.prev = node2;

var head = node1;

var newHead = s.FlattenIterative1(head);
var result = newHead;










