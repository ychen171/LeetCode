
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
    // Time: O(Max(m,n))
    // Space: O(Max(m,n))
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        // iterate through l1 and l2
        // at each iteration, (l1.val + l2.val) % 10 and (l1.val + l2.val) / 10
        if (l1 == null) return l2;
        if (l2 == null) return l1;
        var dummy = new ListNode(0);
        var curr = dummy;
        int carry = 0;
        while (l1 != null || l2 != null)
        {
            int sum = (l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0) + carry;
            carry = 0;
            if (sum < 10)
            {
                curr.next = new ListNode(sum);
            }
            else
            {
                int remainder = sum % 10;
                carry = 1;
                curr.next = new ListNode(remainder);
            }
            curr = curr.next;
            l1 = l1 == null ? l1 : l1.next;
            l2 = l2 == null ? l2 : l2.next;
        }
        if (carry == 1) curr.next = new ListNode(carry);
        return dummy.next;
    }
}

var s = new Solution();
var l1 = new ListNode(9);
var curr = l1;
curr.next = new ListNode(9);
curr = curr.next;
curr.next = new ListNode(9);
curr = curr.next;

var l2 = new ListNode(9);
curr = l2;
curr.next = new ListNode(9);

var result = s.AddTwoNumbers(l1, l2);
Console.WriteLine(result);




