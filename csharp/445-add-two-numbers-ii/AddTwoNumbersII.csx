
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
    // Reverse + Two Pointers
    // Time: O(n1 + n2)
    // Space: O(1)
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) 
    {
        ListNode r1 = ReverseList(l1);
        ListNode r2 = ReverseList(l2);
        
        ListNode dummy = new ListNode();
        ListNode curr = dummy;
        int carry = 0;
        
        while (r1 != null || r2 != null)
        {
            bool hasR1 = r1 != null;
            bool hasR2 = r2 != null;
            int sum = (hasR1 ? r1.val : 0) + (hasR2 ? r2.val : 0) + carry;
            carry = sum / 10;
            sum %= 10;
            curr.next = new ListNode(sum);
            curr = curr.next;
            
            r1 = hasR1 ? r1.next : r1;
            r2 = hasR2 ? r2.next : r2;
        }
        
        if (carry != 0)
        {
            curr.next = new ListNode(carry);
        }
        
        return ReverseList(dummy.next);
    }
    
    private ListNode ReverseList(ListNode head)
    {
        if (head == null || head.next == null)
            return head;
        
        ListNode prev = null;
        ListNode curr = head;
        
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