public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val)
    {
        this.val = val;
    }
}
public class DoublyListNode
{
    public int val;
    public DoublyListNode prev;
    public DoublyListNode next;
    public DoublyListNode(int val)
    {
        this.val = val;
    }
}

public class MyLinkedList
{
    private ListNode head;

    public MyLinkedList() { }

    public int Get(int index)
    {
        var curr = head;
        var count = 0;
        while (curr != null && count != index)
        {
            curr = curr.next;
            count++;
        }
        return curr == null ? -1 : curr.val;
    }

    public void AddAtHead(int val)
    {
        var curr = new ListNode(val);
        curr.next = head;
        head = curr;
        return;
    }

    public void AddAtTail(int val)
    {
        if (head == null)
        {
            head = new ListNode(val);
            return;
        }
        var curr = head;
        while (curr.next != null)
        {
            curr = curr.next;
        }
        var node = new ListNode(val);
        curr.next = node;
        return;
    }

    public void AddAtIndex(int index, int val)
    {
        if (index == 0)
        {
            AddAtHead(val);
            return;
        }
        var curr = head;
        var count = 0;
        while (curr != null && count < index - 1)
        {
            curr = curr.next;
            count++;
        }
        if (curr == null) return;
        var node = new ListNode(val);
        var tempNext = curr.next;
        curr.next = node;
        node.next = tempNext;
        return;
    }

    public void DeleteAtIndex(int index)
    {
        if (index == 0)
        {
            head = head.next;
            return;
        }
        var curr = head;
        var count = 0;
        while (curr.next != null && count < index - 1)
        {
            curr = curr.next;
            count++;
        }
        var tempNext = curr.next;
        if (tempNext != null)
            curr.next = curr.next.next;
        else
            curr.next = null;
        tempNext = null;
        return;
    }
}

public class MyDoublyLinkedList
{
    private DoublyListNode head;

    public MyDoublyLinkedList() { }

    public int Get(int index)
    {
        var curr = head;
        var count = 0;
        while (curr != null && count != index)
        {
            curr = curr.next;
            count++;
        }
        return curr == null ? -1 : curr.val;
    }

    public void AddAtHead(int val)
    {
        var curr = new DoublyListNode(val);
        curr.next = head;
        if (head != null)
            head.prev = curr;
        head = curr;
        return;
    }

    public void AddAtTail(int val)
    {
        if (head == null)
        {
            head = new DoublyListNode(val);
            return;
        }
        var curr = head;
        while (curr.next != null)
        {
            curr = curr.next;
        }
        var node = new DoublyListNode(val);
        curr.next = node;
        node.prev = curr;
        return;
    }

    public void AddAtIndex(int index, int val)
    {
        if (index == 0)
        {
            AddAtHead(val);
            return;
        }
        var curr = head;
        var count = 0;
        while (curr != null && count < index)
        {
            curr = curr.next;
            count++;
        }
        if (count != index)
            return;
        if (curr == null)
        {
            AddAtTail(val);
            return;
        }
        var prev = curr.prev;
        var node = new DoublyListNode(val);
        node.prev = prev;
        node.next = curr;
        prev.next = node;
        curr.prev = node;
        return;
    }

    public void DeleteAtIndex(int index)
    {
        if (index == 0)
        {
            head = head.next;
            if (head != null)
                head.prev = null;
            return;
        }
        var prev = head;
        var count = 0;
        while (prev != null && count < index - 1)
        {
            prev = prev.next;
            count++;
        }
        if (prev == null)
            return;
        var curr = prev.next;
        if (curr == null)
            return;
        var next = curr.next;
        prev.next = next;
        if (next != null)
            next.prev = prev;
        curr.prev = null;
        curr.next = null;
        return;
    }
}

/**
 * Your MyLinkedList object will be instantiated and called as such:
 * MyLinkedList obj = new MyLinkedList();
 * int param_1 = obj.Get(index);
 * obj.AddAtHead(val);
 * obj.AddAtTail(val);
 * obj.AddAtIndex(index,val);
 * obj.DeleteAtIndex(index);
 */


var obj = new MyDoublyLinkedList();
// obj.AddAtHead(4);
// obj.Get(1);
// obj.AddAtHead(1);
// obj.AddAtHead(5);
// obj.DeleteAtIndex(3);
// obj.AddAtHead(7);
// obj.Get(3);
// obj.Get(3);
// obj.Get(3);
// obj.AddAtHead(1);
// obj.DeleteAtIndex(4);

// obj.AddAtHead(1);
// obj.DeleteAtIndex(0);

// obj.AddAtHead(7);
// obj.AddAtHead(2);
// obj.AddAtHead(1);
// obj.AddAtIndex(3, 0);
// obj.DeleteAtIndex(2);
// obj.AddAtHead(6);
// obj.AddAtTail(4);
// obj.Get(4);
// obj.AddAtHead(4);
// obj.AddAtIndex(5, 0);
// obj.AddAtHead(6);

obj.AddAtIndex(1,0);
obj.Get(0);







