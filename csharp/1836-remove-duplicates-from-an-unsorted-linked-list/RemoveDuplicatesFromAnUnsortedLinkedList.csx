
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
    public ListNode DeleteDuplicatesUnsorted(ListNode head)
    {
        // count the vals
        var countDict = new Dictionary<int, int>();
        ListNode curr = head;
        while (curr != null)
        {
            countDict[curr.val] = countDict.GetValueOrDefault(curr.val, 0) + 1;
            curr = curr.next;
        }
        // use two pointers to iterate
        var dummy = new ListNode(0, head);
        ListNode slow = dummy, fast = head;
        while (fast != null)
        {
            if (countDict[fast.val] == 1)
            {
                slow.next = fast;
                slow = slow.next;
                fast = fast.next;
            }
            else
            {
                fast = fast.next;
            }
        }
        slow.next = fast;

        return dummy.next;
    }
}
