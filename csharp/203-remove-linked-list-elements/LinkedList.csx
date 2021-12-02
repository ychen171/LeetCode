
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
    // two-pointer
    // Time: O(n)
    // Space: O(1)
    public ListNode RemoveElements(ListNode head, int val)
    {
        var dummy = new ListNode(0, head);
        ListNode prev = dummy;
        ListNode curr = dummy.next;
        while (curr != null)
        {
            if (curr.val == val)
            {
                curr = curr.next;
                prev.next = curr;
            }
            else
            {
                prev = curr;
                curr = curr.next;
            }

        }
        return dummy.next;
    }
}




