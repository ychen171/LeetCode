
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
    // Stack
    // Time: O(n)
    // Space: O(n)
    public ListNode ReverseList1(ListNode head)
    {
        var stack = new Stack<ListNode>();
        while (head != null)
        {
            stack.Push(head);
            head = head.next;
        }

        var reversedHead = stack.Pop();
        var curr = reversedHead;
        while (stack.Count != 0)
        {
            curr.next = stack.Pop();
            curr = curr.next;
        }

        return reversedHead;
    }

    // Iterative
    // Time: O(n)
    // Space: O(1)
    public ListNode ReverseList2(ListNode head)
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

    // Recursive
    // Time: O(n)
    // Space: O(n)
    public ListNode ReverseList3(ListNode head)
    {
        // base case
        if (head == null || head.next == null) return head;
        // recursive case
        var curr = ReverseList3(head.next);
        head.next.next = head;
        head.next = null;
        return curr;
    }
}

var head = new ListNode(1);
var curr = head;
curr.next = new ListNode(2);
curr = curr.next;
curr.next = new ListNode(3);
curr = curr.next;

var s = new Solution();
var newHead = s.ReverseList1(head);
var result = newHead;

