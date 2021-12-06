
public class Node
{
    public int val;
    public Node next;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
        next = null;
    }

    public Node(int _val, Node _next)
    {
        val = _val;
        next = _next;
    }
}


public class Solution
{
    // two-pointers
    // Time: O(n)
    // Space: O(1)
    public Node Insert(Node head, int insertVal)
    {
        if (head == null)
        {
            var newNode = new Node(insertVal);
            newNode.next = newNode;
            return newNode;
        }
        Node prev = head;
        Node curr = head.next;

        while (curr != head)
        {
            if (prev.val <= curr.val) // insertVal is in the middle
            {
                if (prev.val <= insertVal && insertVal <= curr.val)
                    break;
            }
            else // insertVal is either in the end or in the beginning
            {
                if (insertVal >= prev.val || insertVal <= curr.val)
                    break;
            }
            prev = curr;
            curr = curr.next;
        }
        var insertNode = new Node(insertVal);
        prev.next = insertNode;
        insertNode.next = curr;
        return head;
    }
}







