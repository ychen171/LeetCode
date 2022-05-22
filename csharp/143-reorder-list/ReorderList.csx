
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}

// Time: O(n)
// Space: O(1)
public class Solution
{
    public void ReorderList(ListNode head)
    {
        if (head.next == null)
            return;
        // have the head of first half
        ListNode firstHead = head;
        // find the tail of first half
        ListNode firstTail = FindFirstTail(head);
        // reverse the second half 
        ListNode secondHead = Reverse(firstTail.next);
        firstTail.next = null;
        // merge two halves (first half length >= second half length)
        ListNode firstCurr = firstHead;
        ListNode secondCurr = secondHead;
        while (secondCurr != null)
        {
            var nextTemp = firstCurr.next;
            firstCurr.next = secondCurr;
            firstCurr = nextTemp;

            nextTemp = secondCurr.next;
            secondCurr.next = firstCurr;
            secondCurr = nextTemp;
        }
    }

    private ListNode FindFirstTail(ListNode head)
    {
        var slow = head;
        var fast = head;
        while (fast != null && fast.next != null && fast.next.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        return slow;
    }

    private ListNode Reverse(ListNode head)
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
}
