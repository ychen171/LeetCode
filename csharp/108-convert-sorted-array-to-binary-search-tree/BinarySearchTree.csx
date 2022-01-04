
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
    // Binary Search | DFS Preorder traversal | Top-down
    // Time: O(n)
    // Space: O(log n)
    public TreeNode SortedArrayToBST(int[] nums)
    {
        return Helper(nums, 0, nums.Length - 1);
    }

    private TreeNode Helper(int[] nums, int left, int right)
    {
        if (left > right) return null;
        // always choose left middle node as a root
        int mid = left + (right - left) / 2;
        // preorder traversal
        var root = new TreeNode(nums[mid]);
        root.left = Helper(nums, left, mid - 1);
        root.right = Helper(nums, mid + 1, right);
        return root;
    }
}




