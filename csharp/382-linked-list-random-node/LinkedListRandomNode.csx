
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
    List<ListNode> list;
    ListNode head;
    Random rand;
    public Solution(ListNode head)
    {
        list = new List<ListNode>();
        this.head = head;
        var curr = head;
        while (curr != null)
        {
            list.Add(curr);
            curr = curr.next;
        }
        rand = new Random();
    }

    public int GetRandom()
    {
        // [0, Count)
        int index = rand.Next(list.Count);
        return list[index].val;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(head);
 * int param_1 = obj.GetRandom();
 */
