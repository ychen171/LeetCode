
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
    // Recursive | two pointers
    // Time: O(n)
    // Space: O(n)
    public ListNode SwapPairs(ListNode head)
    {
        if (head == null || head.next == null) return head;
        var prev = head;
        var curr = head.next;
        // swapping
        prev.next = SwapPairs(curr.next);
        curr.next = prev;
        return curr;
    }

    // Iterative | two pointers
    // Time: O(n)
    // Space: O(1)
    public ListNode SwapPairsIterative(ListNode head)
    {
        var dummy = new ListNode();
        dummy.next = head;
        var prev = dummy;
        var first = head;
        while (first != null && first.next != null)
        {
            // swap
            var second = first.next;
            var nextTemp = second.next;
            prev.next = second;
            second.next = first;
            first.next = nextTemp;

            // move forward
            prev = first;
            first = first.next;
        }

        // return the new head
        return dummy.next;
    }
}




