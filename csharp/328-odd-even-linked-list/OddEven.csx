
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
    // four-pointer
    // Time: O(n)
    // Space: O(1)
    public ListNode OddEvenList(ListNode head)
    {
        if (head == null) return head;
        var oddHead = head;
        var oddTail = head;
        var evenHead = head.next;
        var evenTail = head.next;
        while (evenTail != null && evenTail.next != null)
        {
            var oddNext = evenTail.next;
            var evenNext = oddNext.next;
            oddTail.next = oddNext;
            oddNext.next = evenHead;
            evenTail.next = evenNext;

            oddTail = oddTail.next;
            evenTail = evenTail.next;
        }
        return head;
    }

    // simplified version
    public ListNode OddEvenList2(ListNode head)
    {
        if (head == null) return head;
        var odd = head;
        var even = head.next;
        var evenHead = head.next;

        while (even != null && even.next != null)
        {
            odd.next = even.next;
            odd = odd.next;
            even.next = odd.next;
            even = even.next;
        }
        odd.next = evenHead;
        return head;
    }
}


var s = new Solution();
var head = new ListNode(1);
var curr = head;
curr.next = new ListNode(2);
curr = curr.next;
curr.next = new ListNode(3);
curr = curr.next;
curr.next = new ListNode(4);
curr = curr.next;
curr.next = new ListNode(5);
curr = curr.next;

var newHead = s.OddEvenList(head);
var result = newHead;

