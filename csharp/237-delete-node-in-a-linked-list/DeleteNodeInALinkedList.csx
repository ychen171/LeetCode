
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}


public class Solution
{
    // delete next node
    // Time: O(1)
    // Space: O(1)
    public void DeleteNode(ListNode node)
    {
        ListNode curr = node;
        ListNode next = node.next;
        curr.val = next.val;
        curr.next = next.next;
    }
    // Two Pointers
    // Time: O(n)
    // Space: O(1)
    public void DeleteNode1(ListNode node)
    {
        // starting from node, shift the values to left by 1
        // copy the value of next node over to replace the value of curr node
        ListNode prev = null;
        ListNode curr = node;
        ListNode next = node.next;
        while (next != null)
        {
            curr.val = next.val;
            prev = curr;
            curr = curr.next;
            next = next.next;
        }
        // remove the last node
        prev.next = next;
    }
}
