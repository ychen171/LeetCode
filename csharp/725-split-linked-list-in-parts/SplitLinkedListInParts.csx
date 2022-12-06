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
    public ListNode[] SplitListToParts(ListNode head, int k)
    {
        // edge case
        var result = new ListNode[k];
        if (head == null) return result;
        // calculate total size and each size
        ListNode curr = head;
        int n = 0;
        while (curr != null)
        {
            curr = curr.next;
            n++;
        }
        int q = n / k;
        int m = n % k;
        var size = new int[k];
        for (int i = 0; i < k; i++)
        {
            size[i] = q;
            if (i < m)
                size[i]++;
        }
        // split list to parts
        curr = head;
        ListNode prev = null;
        for (int i = 0; i < k; i++)
        {
            result[i] = curr;
            int count = size[i];
            while (count > 0)
            {
                prev = curr;
                curr = curr.next;
                count--;
            }
            prev.next = null;
        }
        return result;
    }
}
// Two Pointers
// Time: O(n + k)
// Space: O(k)
