
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
    public ListNode DetectCycle1(ListNode head)
    {
        if (head == null) return null;
        var set = new HashSet<ListNode>();
        var curr = head;
        while (curr != null)
        {
            if (set.Contains(curr))
                return curr;
            set.Add(curr);
            curr = curr.next;
        }
        return null;
    }

    // two-pointer
    // Time: O(n)
    // Space: O(1)
    public ListNode DetectCycle2(ListNode head)
    {
        // find the intersection
        if (head == null) return null;
        var slow = head;
        var fast = head;
        ListNode intersection = null;
        while (fast.next != null && fast.next.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
            if (slow == fast) 
            {
                intersection = slow;
                break;
            }
        }
        // find the entrance
        if (intersection == null) return null;
        slow = head;
        fast = intersection;
        while (slow != fast)
        {
            slow = slow.next;
            fast = fast.next;
        }

        return slow;
    }
}





