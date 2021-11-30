
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution
{
    // two nested loop (brute force)
    // Time: O(m*n)
    // Space: O(m+n)
    public ListNode GetIntersectionNode1(ListNode headA, ListNode headB)
    {
        if (headA == null || headB == null) return null;
        var listA = new List<ListNode>();
        var listB = new List<ListNode>();
        while (headA != null)
        {
            listA.Add(headA);
            headA = headA.next;
        }
        while (headB != null)
        {
            listB.Add(headB);
            headB = headB.next;
        }

        foreach (var node in listA)
        {
            if (listB.Contains(node))
                return node;
        }

        return null;
    }

    // Stack
    // Time: O(m+n)
    // Space: O(m+n)
    public ListNode GetIntersectionNode2(ListNode headA, ListNode headB)
    {
        if (headA == null || headB == null) return null;
        var stackA = new Stack<ListNode>();
        var stackB = new Stack<ListNode>();
        while (headA != null)
        {
            stackA.Push(headA);
            headA = headA.next;
        }
        while (headB != null)
        {
            stackB.Push(headB);
            headB = headB.next;
        }

        ListNode intersection = null;
        while (stackA.Count > 0 && stackB.Count > 0)
        {
            var nodeA = stackA.Pop();
            var nodeB = stackB.Pop();
            if (nodeA == nodeB)
                intersection = nodeA;
            else
                break;
        }
        return intersection;
    }

    // HashSet
    // Time: O(m+n)
    // Space: O(n)
    public ListNode GetIntersectionNode3(ListNode headA, ListNode headB)
    {
        if (headA == null || headB == null) return null;
        var setB = new HashSet<ListNode>();
        while (headB != null)
        {
            setB.Add(headB);
            headB = headB.next;
        }

        while (headA != null)
        {
            if (setB.Contains(headA))
                return headA;
            headA = headA.next;
        }

        return null;
    }

    // Two-Pointer
    // Time: O(m+n)
    // Space: O(1)
    public ListNode GetIntersectionNode4(ListNode headA, ListNode headB)
    {
        ListNode p1 = headA;
        ListNode p2 = headB;
        while (p1 != p2)
        {
            p1 = p1 == null ? headB : p1.next;
            p2 = p2 == null ? headA : p2.next;
        }
        return p1;
    }

}


