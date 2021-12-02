
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
    // copy into array/list and use two pointer technique
    // Time: O(n)
    // Space: O(n)
    public bool IsPalindrome1(ListNode head)
    {
        var list = new List<int>();
        var curr = head;
        while (curr != null)
        {
            list.Add(curr.val);
            curr = curr.next;
        }

        var reversedList = new List<int>(list);
        reversedList.Reverse();
        for (int i=0; i < list.Count; i++)
        {
            if (list[i] != reversedList[i])
                return false;
        }

        return true;
    }

    // Iterative (Stack)
    // Time: O(n)
    // Space: O(n)
    public bool IsPalindrome2(ListNode head)
    {
        var stack = new Stack<int>();
        var curr = head;
        while (curr != null)
        {
            stack.Push(curr.val);
            curr = curr.next;
        }

        curr = head;
        while (stack.Count != 0)
        {
            if (stack.Pop() != curr.val)
                return false;
            curr = curr.next;
        }

        return true;
    }

    // Recursive (Stack)
    // Time: O(n)
    // Space: O(n)
    private ListNode frontPointer;
    public bool IsPalindrome3(ListNode head)
    {
        frontPointer = head;
        return RecursivelyCheck(head);
    }

    private bool RecursivelyCheck(ListNode node)
    {
        if (node != null)
        {
            if (!RecursivelyCheck(node.next))
                return false;
            if (node.val != frontPointer.val)
                return false;
            frontPointer = frontPointer.next;
        }

        return true;
    }

    // Reverse Second Half in-place (two runners pointer technique)
    // Time: O(n)
    // Space: O(1)
    public bool IsPalindrome4(ListNode head)
    {
        if (head == null) return true;

        // find the end of first half
        var firstHalfEnd = EndOfFirstHalf(head);
        // reverse second half
        var secondHalfStart = ReverseList(firstHalfEnd.next);
        // the length of first half >= the length of second half
        // check whether or not there is a palindrome
        ListNode p1 = head;
        ListNode p2 = secondHalfStart;
        bool result = true;
        while (result && p2 != null) // second reaches null earlier
        {
            if (p1.val != p2.val)
                result = false;
            p1 = p1.next;
            p2 = p2.next;
        }
        // restore second half and return result
        firstHalfEnd.next = ReverseList(secondHalfStart);
        return result;
    }

    private ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        ListNode curr = head;
        while (curr != null)
        {
            ListNode nextTemp = curr.next;
            curr.next = prev;
            prev = curr;
            curr = nextTemp;
        }

        return prev;
    }

    private ListNode EndOfFirstHalf(ListNode head)
    {
        var fast = head;
        var slow = head;
        while (fast.next != null && fast.next.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
        }

        return slow;
    }
}






