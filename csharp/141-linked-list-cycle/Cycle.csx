
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x)
    {
        val = x;
        next = null;
    }
}

public class Solution
{
    // HashSet
    // Time: O(n)
    // Space: O(n)
    public bool HasCycle1(ListNode head)
    {
        if (head == null) return false;
        var set = new HashSet<ListNode>();
        var curr = head;
        while (curr != null)
        {
            if (set.Contains(curr))
                return true;
            set.Add(curr);
            curr = curr.next;
        }

        return false;
    }

    // two-pointer 
    // Time: O(n)
    // Space: O(1)
    public bool HasCycle2(ListNode head)
    {
        if (head == null) return false;
        var slow = head;
        var fast = head;

        while (fast.next != null && fast.next.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;

            if (fast.val == slow.val)
                return true;
        }

        return false;
    }
}

