
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
    // Two Pointers
    // Time: O(n)
    // Space: O(n)
    public ListNode DeleteDuplicates(ListNode head)
    {
        var dummy = new ListNode(0, head);
        ListNode slow = dummy, fast = head;
        while (fast != null)
        {
            if (fast.next != null && fast.val == fast.next.val)
            {
                while (fast.next != null && fast.val == fast.next.val)
                {
                    fast = fast.next;
                }
                fast = fast.next;
                if (fast == null)
                {
                    slow.next = null;
                }
            }
            else
            {
                slow.next = fast;
                slow = slow.next;
                fast = fast.next;
            }

        }

        return dummy.next;
    }
}
