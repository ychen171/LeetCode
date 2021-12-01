
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution
{
    // one-pointer, two pass
    // Time: O(L)
    // Space: O(1)
    public ListNode RemoveNthFromEnd1(ListNode head, int n)
    {
        var dummy = new ListNode(0);
        dummy.next = head;
        int length = 0;
        var curr = head;
        while (curr != null)
        {
            curr = curr.next;
            length++;
        }
        length -= n;
        curr = dummy;
        while (length > 0)
        {
            curr = curr.next;
            length--;
        }
        curr.next = curr.next.next;
        return dummy.next;
    }
    // two-pointer, one pass
    // Time: O(L)
    // Space: O(1)
    public ListNode RemoveNthFromEnd2(ListNode head, int n)
    {
        // create dummy node and link it to head node
        var dummy = new ListNode(0);
        dummy.next = head;
        var first = dummy;
        var second = dummy;
        // advance first pointer so that the gap between first and second is n
        for (int i = 0; i < n + 1; i++)
            first = first.next;
        // advance first and second pointers together, maintaining the gap
        // until first pointer reaches null
        while (first != null)
        {
            first = first.next;
            second = second.next;
        }
        // remove the node after second pointer
        second.next = second.next.next;
        // return the first non-dummy node
        return dummy.next;
    }
    // two-pointer
    // Time: O(L)
    // Space: O(1)
    public ListNode RemoveNthFromEnd3(ListNode head, int n)
    {
        // corner case
        if (head.next == null) return null;
        // advance fast pointer n steps
        ListNode fast = head;
        ListNode slow = null;
        int count = 0;
        while (fast != null && count <= n)
        {
            fast = fast.next;
            count++;
        }
        // if fast pointer stops before n steps, remove head node
        slow = head;
        if (count <= n)
        {
            slow = slow.next;
            return slow;
        }
        // advance slow and fast together until fast reaches null
        while (fast != null)
        {
            slow = slow.next;
            fast = fast.next;
        }
        // remove the node next to slow pointer
        slow.next = slow.next.next;
        return head;
    }
}






