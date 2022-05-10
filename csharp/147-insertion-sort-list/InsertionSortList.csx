
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
    // Time: O(n^2)
    // Space: O(1)
    public ListNode InsertionSortList(ListNode head)
    {
        //  0   4   2   1   3
        //  dm  pv  cr
        //  0   2   4   1   3
        //          pv  cr
        //  0   1   2   4   3
        //              pv  cr
        //  0   1   2   3   4
        //                  pv  cr

        //  min -1  5   3   4   0
        //      pr  cr
        //  min -1  5   3   4   0
        //      
        if (head.next == null)
            return head;
        
        var dummy = new ListNode(int.MinValue, head);
        ListNode prev = head;
        ListNode curr = head.next;

        while (curr != null)
        {
            // already sorted
            if (prev.val <= curr.val)
            {
                prev = curr;
                curr = curr.next;
                continue;
            }
            
            // find the node before the insertion
            ListNode beforeNode = dummy;
            while (beforeNode != curr)
            {
                if (beforeNode.val <= curr.val && curr.val <= beforeNode.next.val)
                    break;
                beforeNode = beforeNode.next;
            }
            
            // insert curr node next to beforeNode
            prev.next = curr.next;
            curr.next = beforeNode.next;
            beforeNode.next = curr;
            curr = prev.next;
        }

        return dummy.next;
    }
}

