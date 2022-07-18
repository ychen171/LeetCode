
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
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null || head.next == null)
            return head;

        var slow = head;
        var fast = head;
        while (fast != null)
        {
            if (slow.val != fast.val)
            {
                slow.next = fast;
                slow = slow.next;
            }
            fast = fast.next;
        }
        slow.next = null;

        return head;
    }
}
