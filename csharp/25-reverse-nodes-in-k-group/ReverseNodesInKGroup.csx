
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
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        // edge case
        if (head == null) return null;

        ListNode a = head;
        ListNode b = head;
        // base case
        for (int i = 0; i < k; i++)
        {
            if (b == null)
                return head;
            b = b.next;
        }
        // recursive case
        var currReversedHead = Reverse(a, b);
        var nextReversedHead = ReverseKGroup(b, k);
        a.next = nextReversedHead;
        return currReversedHead;
    }

    public ListNode Reverse(ListNode head)
    {
        ListNode prev = null;
        ListNode curr = head;
        while (curr != null)
        {
            var nextTemp = curr.next;
            curr.next = prev;
            prev = curr;
            curr = nextTemp;
        }

        return prev;
    }

    public ListNode Reverse(ListNode a, ListNode b)
    {
        // [a, b)
        ListNode prev = null;
        ListNode curr = a;

        while (curr != b)
        {
            var nextTemp = curr.next;
            curr.next = prev;
            prev = curr;
            curr = nextTemp;
        }

        return prev;
    }
}
