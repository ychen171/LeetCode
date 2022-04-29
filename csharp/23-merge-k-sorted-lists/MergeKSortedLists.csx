
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
    // divide and conquer
    // Time: O(n log k)
    // Space: O(1)
    public ListNode MergeKLists(ListNode[] lists)
    {
        return Helper(lists, 0, lists.Length - 1);
    }

    public ListNode Helper(ListNode[] lists, int start, int end)
    {
        // base case
        if (start == end)
            return lists[start];
        if (start > end)
            return null;
        
        // recursive case
        // divide
        int mid = start + (end - start) / 2;
        var left = Helper(lists, start, mid);
        var right = Helper(lists, mid + 1, end);
        // conquer
        return Merge(left, right);
    }

    public ListNode Merge(ListNode l1, ListNode l2)
    {
        ListNode dummy = new ListNode();
        ListNode curr = dummy;

        while (l1 != null && l2 != null)
        {
            if (l1.val < l2.val)
            {
                curr.next = l1;
                l1 = l1.next;
            }
            else
            {
                curr.next = l2;
                l2 = l2.next;
            }

            curr = curr.next;
        }

        curr.next = l1 == null ? l2 : l1;
        return dummy.next;
    }

    // Priority Queue
    // Time: O(n log k)
    // Space: O(k)
    public ListNode MergeKLists1(ListNode[] lists)
    {
        var pq = new PriorityQueue<ListNode, int>();
        foreach (ListNode node in lists)
        {
            if (node != null)
                pq.Enqueue(node, node.val);
        }
        ListNode dummy = new ListNode();
        ListNode curr = dummy;
        while (pq.Count != 0)
        {
            ListNode node = pq.Dequeue();
            curr.next = node;
            curr = curr.next;
            node = node.next;
            if (node != null)
                pq.Enqueue(node, node.val);
        }

        return dummy.next;
    }
}
