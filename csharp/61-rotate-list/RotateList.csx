
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
    // two-pointers
    // Time: O(n)
    // Space: O(1)
    public ListNode RotateRight(ListNode head, int k)
    {
        if (head == null || head.next == null || k == 0) return head;
        var curr = head;
        int length = 0;
        while (curr != null)
        {
            length++;
            curr = curr.next;
        }
        if (length == k) return head;

        ListNode first = head;
        ListNode second = head;
        for (int i = 0; i < k % length; i++)
            first = first.next;
        
        if (first == second) return head;

        while (first.next != null)
        {
            first = first.next;
            second = second.next;
        }
        var newHead = second.next;
        second.next = null;
        first.next = head;

        return newHead;
    }
}






