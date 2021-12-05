
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
    // two-pointer (Iterative)
    // Time: O(m+n)
    // Space: O(1)
    public ListNode MergeTwoListsIterative(ListNode list1, ListNode list2)
    {
        ListNode dummy = new ListNode(0);
        ListNode curr = dummy;
        ListNode tempNext = null;
        // both lists still have nodes
        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                tempNext = list1;
                list1 = list1.next;
            }
            else
            {
                tempNext = list2;
                list2 = list2.next;
            }
            curr.next = tempNext;
            curr = curr.next;
        }
        // at least one list still have nodes
        curr.next = list1 == null ? list2 : list1;

        return dummy.next;
    }

    // Recursive
    // Time: O(m+n)
    // Space: O(m+n)
    public ListNode MergeTwoListsRecursive(ListNode list1, ListNode list2)
    {
        if (list1 == null) return list2;
        if (list2 == null) return list1;
        if (list1.val < list2.val)
        {
            list1.next = MergeTwoListsRecursive(list1.next, list2);
            return list1;
        }
        else
        {
            list2.next = MergeTwoListsRecursive(list1, list2.next);
            return list2;
        }
    }
}








