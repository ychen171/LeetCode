
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
        // start from the same pointer
        var slow = head;
        var fast = head;

        while (slow != null && fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast)
                return true;
        }

        return false;
    }
    // two-pointer 
    // Time: O(n)
    // Space: O(1)
    public bool HasCycle4(ListNode head)
    {
        if (head == null) return false;
        // start from the different pointers
        var slow = head;
        var fast = head.next;
        
        while (slow != fast)
        {
            if (fast == null || fast.next == null)
                return false;
            slow = slow.next;
            fast = fast.next.next;
        }

        return true;
    }
}

