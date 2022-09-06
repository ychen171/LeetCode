
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
    // Two Pointers | Find Middle + Reverse
    // Time: O(n)
    // Space: O(1)
    public int PairSum(ListNode head)
    {
        var firstTail = EndOfFirstHalf(head);
        var secondHead = ReverseR(firstTail.next);
        int maxSum = 0;
        ListNode p1 = head;
        ListNode p2 = secondHead;
        while (p1 != null && p2 != null)
        {
            maxSum = Math.Max(maxSum, p1.val + p2.val);
            p1 = p1.next;
            p2 = p2.next;
        }
        return maxSum;
    }

    private ListNode EndOfFirstHalf(ListNode head)
    {
        ListNode slow = head, fast = head;
        while (fast.next != null && fast.next.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        return slow;
    }

    private ListNode ReverseI(ListNode head)
    {
        ListNode prev = null, curr = head;
        while (curr != null)
        {
            var tempNext = curr.next;
            curr.next = prev;
            prev = curr;
            curr = tempNext;
        }

        return prev;
    }

    private ListNode ReverseR(ListNode head)
    {
        // base case
        if (head == null || head.next == null)
            return head;

        // recursive case
        var reversedHead = ReverseR(head.next);
        head.next.next = head;
        head.next = null;
        return reversedHead;
    }
}
