
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

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    // Recursion | DFS Inorder traversal
    // Time: O(n)
    // Space: O(n)
    public TreeNode SortedListToBST(ListNode head)
    {
        if (head == null)
            return null;
        // covert to list of val
        var nums = new List<int>();
        var curr = head;
        while (curr != null)
        {
            nums.Add(curr.val);
            curr = curr.next;
        }

        return Helper(nums, 0, nums.Count - 1);
    }

    public TreeNode Helper(List<int> nums, int left, int right)
    {
        // base case
        if (left > right)
            return null;

        // recursive case
        int mid = left + (right - left) / 2;
        var root = new TreeNode(nums[mid]);
        root.left = Helper(nums, left, mid - 1);
        root.right = Helper(nums, mid + 1, right);
        return root;
    }

    // Recursion
    // Time: O(n log n)
    // Space: O(log n)
    public TreeNode SortedListToBST1(ListNode head)
    {
        // base case
        if (head == null)
            return null;

        // recursive case
        var midHead = FindMid(head);
        var rightHead = midHead.next;
        midHead.next = null;
        var root = new TreeNode(midHead.val);
        if (midHead == head)
            return root;
        root.left = SortedListToBST1(head);
        root.right = SortedListToBST1(rightHead);
        return root;
    }

    public ListNode FindMid(ListNode head)
    {
        ListNode prev = null;
        ListNode slow = head;
        ListNode fast = head;
        while (fast != null && fast.next != null)
        {
            prev = slow;
            slow = slow.next;
            fast = fast.next.next;
        }
        if (prev != null)
            prev.next = null;

        return slow;
    }
}
