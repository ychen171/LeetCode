
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    // Two Pointers | Fast Slow Pointers
    // Time: O(n)
    // Space: O(1)
    public ListNode DeleteMiddle(ListNode head)
    {
        var dummy = new ListNode(0, head);
        ListNode slow = dummy, fast = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        // slow -> midde -> 
        slow.next = slow.next.next;
        return dummy.next;
    }
}
