
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
    // Four Pointers + Iteration or Recursion
    // Time: O(n)
    // Space: O(1)
    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        if (head == null || head.next == null)
            return head;

        var dummy = new ListNode();
        dummy.next = head;
        ListNode firstEnd = null;
        ListNode secondEnd = null;
        ListNode curr = dummy;
        int i = 0;
        while (i < left - 1)
        {
            curr = curr.next;
            i++;
        }
        firstEnd = curr;
        Console.WriteLine(firstEnd.val);

        while (i < right)
        {
            curr = curr.next;
            i++;
        }
        secondEnd = curr;
        Console.WriteLine(secondEnd.val);

        var secondHead = firstEnd.next;
        var thirdHead = secondEnd.next;
        firstEnd.next = null;
        secondEnd.next = null;

        // reverse second linked list
        var reversedHead = ReverseI(secondHead);

        firstEnd.next = reversedHead;
        secondHead.next = thirdHead;
        return dummy.next;
    }

    private ListNode ReverseR(ListNode head)
    {
        // base case
        if (head == null || head.next == null)
            return head;

        // recursive case
        // 1 --> 2 --> null
        // 1 <-- 2 <-- null
        var reversedHead = ReverseR(head.next);
        head.next.next = head;
        head.next = null;
        return reversedHead;
    }

    private ListNode ReverseI(ListNode head)
    {
        if (head == null || head.next == null)
            return head;
        ListNode curr = head;
        ListNode prev = null;
        while (curr != null)
        {
            var tempNext = curr.next;
            curr.next = prev;
            prev = curr;
            curr = tempNext;
        }

        return prev;
    }
}
