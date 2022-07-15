
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    // Two Pointers
    // Time: O(n)
    // Space: O(1)
    public ListNode Partition(ListNode head, int x)
    {
        if (head == null || head.next == null)
            return head;
        
        var dummy1 = new ListNode(0);
        var dummy2 = new ListNode(0);
        ListNode p1 = dummy1;
        ListNode p2 = dummy2;
        ListNode p = head;
        while (p != null)
        {
            if (p.val < x) // add to p1
            {
                p1.next = p;
                p1 = p1.next;
            }
            else // add to p2
            {
                p2.next = p;
                p2 = p2.next;
            }
            // break the link
            ListNode nextTemp = p.next;
            p.next = null;
            p = nextTemp;
        }
        // dummy1 -> h1 ----> p1
        // dummy2 -> h2 ----> p2
        p1.next = dummy2.next;

        return dummy1.next;
    }
}
